using BackUpSystem.Services.Auth.Contracts;
using BackUpSystem.Utilities.Contracts;
using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BackUpSystem.Services.Auth
{
    public class OAuthCreationService : IOAuthCreationService
    {
        private readonly string oAuthTimestamp;
        private readonly string oAuthNonce;
        private readonly string oAuthSignatureMethod = "HMAC-SHA1";
        private readonly string oAuthVersion = "1.0";
        private string oAuthHeader;
        private readonly IStreamReader streamReaderWrapper;
        private readonly ITwitterCredentials twitterCredentials;

        private const string HeaderFormat =
            "OAuth " +
            "oauth_consumer_key=\"{0}\", " +
            "oauth_nonce=\"{1}\", " +
            "oauth_signature=\"{2}\", " +
            "oauth_signature_method=\"{3}\", " +
            "oauth_timestamp=\"{4}\", " +
            "oauth_token=\"{5}\", " +
            "oauth_version=\"{6}\"";

        public OAuthCreationService(
            IStreamReader streamReaderWrapper, 
            ITwitterCredentials twitterCredentials)
        {

            Guard.WhenArgument(streamReaderWrapper, "StreamReader Wrapper").IsNull().Throw();
            Guard.WhenArgument(twitterCredentials, "Twitter Credentials").IsNull().Throw();

            this.oAuthNonce = GenerateOAuthNonce();
            this.oAuthTimestamp = GenerateOAuthTimestamp();
            this.streamReaderWrapper = streamReaderWrapper;
            this.twitterCredentials = twitterCredentials;
        }

        public string OAuthTimestamp => this.oAuthTimestamp;

        public string OAuthSignatureMethod => this.oAuthSignatureMethod;

        public string OAuthConsumerKey => this.twitterCredentials.ConsumerKey;

        public string OAuthConsumerSecret => this.twitterCredentials.ConsumerSecret;

        public string OAuthAccessToken => this.twitterCredentials.AccessToken;

        public string OAuthTokenSecret => this.twitterCredentials.TokenSecret;

        public string OAuthVersion => this.oAuthVersion;

        public string OAuthNonce => this.oAuthNonce;

        public string OAuthHeader => this.oAuthHeader;

        private string GenerateOAuthTimestamp()
        {
            var unixStart = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var timeSpan = DateTime.UtcNow - unixStart;
            return Convert.ToInt64(timeSpan.TotalSeconds).ToString();
        }

        private string GenerateOAuthNonce()
        {
            return Convert.ToBase64String(new ASCIIEncoding().GetBytes(DateTime.Now.Ticks.ToString()));
        }

        public async Task<string> GetTwitterApiCallData(string resourceUrl, List<string> parametersList = null)
        {
            if (resourceUrl.Contains("?"))
            {
                parametersList = GetParametersFromUrl(resourceUrl);
                resourceUrl = resourceUrl.Substring(0, resourceUrl.IndexOf('?'));
            }

            this.oAuthHeader = GenerateAuthorizationHeader(resourceUrl, parametersList);

            var response = await TwitterApiRequest(resourceUrl, parametersList);

            return response;
        }

        private List<string> GetParametersFromUrl(string resourceUrl)
        {
            var queryString = resourceUrl.Substring(resourceUrl.IndexOf('?') + 1);

            List<string> parameters = new List<string>();

            var queryValuePair = HttpUtility.ParseQueryString(queryString);

            foreach (string parameter in queryValuePair)
            {
                parameters.Add(parameter + "=" + Uri.EscapeDataString(queryValuePair[parameter]));
            }

            return parameters;
        }

        private string GenerateAuthorizationHeader(string resourceUrl, List<string> parameterlist)
        {
            var signature = GenerateSignature(resourceUrl, parameterlist);

            var authHeader = string.Format(HeaderFormat,
            Uri.EscapeDataString(this.OAuthConsumerKey),
            Uri.EscapeDataString(this.OAuthNonce),
            Uri.EscapeDataString(signature),
            Uri.EscapeDataString(this.OAuthSignatureMethod),
            Uri.EscapeDataString(this.OAuthTimestamp),
            Uri.EscapeDataString(this.OAuthAccessToken),
            Uri.EscapeDataString(this.OAuthVersion)
            );

            return authHeader;
        }

        private string GenerateSignature(string resourceUrl, List<string> parameterlist)
        {
            var baseString = GenerateBaseString(parameterlist);

            baseString = string.Concat("GET&", Uri.EscapeDataString(resourceUrl), "&", Uri.EscapeDataString(baseString));

            var signingKey = string.Concat(Uri.EscapeDataString(this.OAuthConsumerSecret), "&", Uri.EscapeDataString(this.OAuthTokenSecret));
            string signature;

            var hasher = new HMACSHA1(Encoding.ASCII.GetBytes(signingKey));

            signature = Convert.ToBase64String(hasher.ComputeHash(Encoding.ASCII.GetBytes(baseString)));

            return signature;
        }

        private string GenerateBaseString(List<string> parametersList)
        {
            var basestring = string.Empty;
            var baseformat = new List<string>
            {
                "oauth_consumer_key=" + this.OAuthConsumerKey,
                "oauth_nonce=" + this.OAuthNonce,
                "oauth_signature_method=" + this.OAuthSignatureMethod,
                "oauth_timestamp=" + this.OAuthTimestamp,
                "oauth_token=" + this.OAuthAccessToken,
                "oauth_version=" + this.OAuthVersion
            };

            if (parametersList != null)
            {
                baseformat.AddRange(parametersList);
            }

            baseformat.Sort();

            foreach (string value in baseformat)
            {
                basestring += value + "&";
            }

            basestring = basestring.TrimEnd('&');

            return basestring;
        }

        private async Task<string> TwitterApiRequest(string resourceUrl, List<string> parameterlist)
        {
            ServicePointManager.Expect100Continue = false;

            string postBody;

            if (parameterlist != null)
            {
                postBody = GetPostBody(parameterlist);
            }
            else
            {
                postBody = string.Empty;
            }

            resourceUrl += "?" + postBody;

            var request = (HttpWebRequest)WebRequest.Create(resourceUrl);
            request.Headers.Add("Authorization", this.OAuthHeader);
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";

            var response = await request.GetResponseAsync();
            var responseData = streamReaderWrapper.GetStreamReader(response);

            return responseData;
        }

        private string GetPostBody(List<string> parameterlist)
        {
            var result = string.Empty;

            foreach (string item in parameterlist)
            {
                result += item + "&";
            }

            result = result.TrimEnd('&');

            return result;
        }

    }
}
