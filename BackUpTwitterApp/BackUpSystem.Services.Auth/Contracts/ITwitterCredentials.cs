using System;
using System.Collections.Generic;
using System.Text;

namespace BackUpSystem.Services.Auth.Contracts
{
    public interface ITwitterCredentials
    {
        /// <summary>
        /// Stores ConumerKey parameter, required for authorization
        /// </summary>
        string ConsumerKey { get; }

        /// <summary>
        /// Stores ConsumerSecret parameter, required for authorization
        /// </summary>
        string ConsumerSecret { get; }

        /// <summary>
        /// Stores AccessToken parameter, required for authorization
        /// </summary>
        string AccessToken { get; }

        /// <summary>
        /// Stores TokenSecret parameter, required for authorization
        /// </summary>
        string TokenSecret { get; }
    }
}
