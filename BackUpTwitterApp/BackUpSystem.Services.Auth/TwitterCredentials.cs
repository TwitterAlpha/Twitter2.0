using BackUpSystem.Services.Auth.Contracts;
using System;

namespace BackUpSystem.Services.Auth
{
    public class TwitterCredentials : ITwitterCredentials
    {
        public string ConsumerKey => Environment.GetEnvironmentVariable("ConsumerKey", EnvironmentVariableTarget.User);

        public string ConsumerSecret => Environment.GetEnvironmentVariable("ConsumerSecret", EnvironmentVariableTarget.User);

        public string AccessToken => Environment.GetEnvironmentVariable("AccessToken", EnvironmentVariableTarget.User);

        public string TokenSecret => Environment.GetEnvironmentVariable("TokenSecret", EnvironmentVariableTarget.User);
    }
}
