using BackUpSystem.Services.Auth.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace BackUpSystem.Services.Auth
{
    public class OAuthCreationService : IOAuthCreationService
    {
        private readonly string oAuthConsumerKey = "JqCNpm5IWxdcINEXj4Gqfy7Gs";
        private readonly string oAuthConsumerSecret = "BIinS5zKgFgDDbwmLMvRkK68v5OJg6NKEmstQzhlbQg9rqFk4f";
        private readonly string oAuthAccessToken = "983817456639791104-tGONAc1ALf4VTsYWdnuIzm7bgrjH8UR";
        private readonly string oAuthTokenSecret = "1CeMn1Q2B79EmdDbIF3PB6B7AnHyDQRkBFVYSVFPeUV9S";
        private readonly string oAuthTimestamp;
        private readonly string oAuthNonce;
        private readonly string oAuthSignatureMethod = "HMAC-SHA1";
        private readonly string oAuthVersion = "1.0";
        private string oAuthHeader;

        private const string HeaderFormat =
            "OAuth " +
            "oauth_consumer_key=\"{0}\", " +
            "oauth_nonce=\"{1}\", " +
            "oauth_signature=\"{2}\", " +
            "oauth_signature_method=\"{3}\", " +
            "oauth_timestamp=\"{4}\", " +
            "oauth_token=\"{5}\", " +
            "oauth_version=\"{6}\"";

        public OAuthCreationService()
        {
            this.oAuthNonce = GenerateOAuthNonce();
            this.oAuthTimestamp = GenerateOAuthTimestamp();
        }

        public string OAuthTimestamp => this.oAuthTimestamp;

        public string OAuthSignatureMethod => this.oAuthSignatureMethod;

        public string OAuthConsumerKey => this.oAuthConsumerKey;

        public string OAuthConsumerSecret => this.oAuthConsumerSecret;

        public string OAuthAccessToken => this.oAuthAccessToken;

        public string OAuthTokenSecret => this.oAuthTokenSecret ?? string.Empty;

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

        public string GetTwitterApiCallData(string resourceUrl, List<string> parametersList = null)
        {
            if (resourceUrl.Contains("?"))
            {
                parametersList = GetParametersFromUrl(resourceUrl);
                resourceUrl = resourceUrl.Substring(0, resourceUrl.IndexOf('?'));
            }

            this.oAuthHeader = GenerateAuthorizationHeader(resourceUrl, parametersList);

            var response = TwitterApiRequest(resourceUrl, parametersList);

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
            List<string> baseformat = new List<string>();

            baseformat.Add("oauth_consumer_key=" + this.OAuthConsumerKey);
            baseformat.Add("oauth_nonce=" + this.OAuthNonce);
            baseformat.Add("oauth_signature_method=" + this.OAuthSignatureMethod);
            baseformat.Add("oauth_timestamp=" + this.OAuthTimestamp);
            baseformat.Add("oauth_token=" + this.OAuthAccessToken);
            baseformat.Add("oauth_version=" + this.OAuthVersion);

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

        private string TwitterApiRequest(string resourceUrl, List<string> parameterlist)
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

            var response = request.GetResponse();

            var responseData = new StreamReader(response.GetResponseStream()).ReadToEnd();

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
