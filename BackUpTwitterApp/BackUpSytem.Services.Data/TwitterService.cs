using BackUpSystem.DTO;
using BackUpSystem.NewtonsoftWrapper.Contracts;
using BackUpSystem.Services.Auth.Contracts;
using BackUpSytem.Services.Data.Contracts;
using System;

namespace BackUpSytem.Services.Data
{
    public class TwitterService : ITwitterService
    {
        private readonly IOAuthCreationService apiService;
        private readonly IJsonUserReader jsonUserDeserializer;

        public TwitterService(IOAuthCreationService apiService, IJsonUserReader jsonUserDeserializer)
        {
            this.apiService = apiService;
            this.jsonUserDeserializer = jsonUserDeserializer;
        }

        public TwitterAccountDto GetUserByScreenName(string screenName)
        {
            var resourceUrl = "https://api.twitter.com/1.1/users/show.json?screen_name=";
            var user = apiService.GetTwitterApiCallData(resourceUrl + screenName);
            var deserializedUser = jsonUserDeserializer.DeserializeUser(user);

            return deserializedUser;
        }
    }
}
