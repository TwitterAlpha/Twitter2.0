using BackUpSystem.Services.Auth.Contracts;
using System;

namespace BackUpSystem.Services.Auth
{
    public class FacebookCredentials : IFacebookCredentials
    {
        public string AppId => Environment.GetEnvironmentVariable("FacebookAppId");

        public string AppSecret => Environment.GetEnvironmentVariable("FacebookAppSecret");
    }
}
