using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackUpSystem.Services.Auth.Contracts
{
    public interface IOAuthCreationService
    {
        /// <summary>
        /// Stores Timestamp parameter, required for authorization
        /// </summary>
        string OAuthTimestamp { get; }

        /// <summary>
        /// Stores SingatureMethod parameter, required for authorization
        /// </summary>
        string OAuthSignatureMethod { get; }

        /// <summary>
        /// Stores ConumerKey parameter, required for authorization
        /// </summary>
        string OAuthConsumerKey { get; }

        /// <summary>
        /// Stores ConsumerSecret parameter, required for authorization
        /// </summary>
        string OAuthConsumerSecret { get; }

        /// <summary>
        /// Stores AccessToken parameter, required for authorization
        /// </summary>
        string OAuthAccessToken { get; }

        /// <summary>
        /// Stores TokenSecret parameter, required for authorization
        /// </summary>
        string OAuthTokenSecret { get; }

        /// <summary>
        /// Stores Version parameter, required for authorization
        /// </summary>
        string OAuthVersion { get; }

        /// <summary>
        /// Stores Nonce parameter, required for authorization
        /// </summary>
        string OAuthNonce { get; }

        /// <summary>
        /// Stores Header parameter, required for authorization
        /// </summary>
        string OAuthHeader { get; }

        /// <summary>
        /// Creates the Api call
        /// </summary>
        Task<string> GetTwitterApiCallData(string resourceUrl, List<string> parametersList = null);
    }
}
