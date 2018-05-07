using BackUpSystem.Services.Auth.Contracts;
using System;

namespace BackUpSystem.Services.Auth
{
    public class TwitterCredentials : ITwitterCredentials
    {
        public string ConsumerKey => Environment.GetEnvironmentVariable("ConsumerKey");

        public string ConsumerSecret => Environment.GetEnvironmentVariable("ConsumerSecret");

        public string AccessToken => Environment.GetEnvironmentVariable("AccessToken");

        public string TokenSecret => Environment.GetEnvironmentVariable("TokenSecret");
    }
}
