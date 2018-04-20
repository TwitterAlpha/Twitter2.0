using BackUpSystem.DTO;
using BackUpSystem.Utilities.Contracts;
using BackUpSystem.Services.Auth.Contracts;
using BackUpSytem.Services.Data.Contracts;
using Bytes2you.Validation;
using System;
using System.Collections.Generic;

namespace BackUpSytem.Services.Data
{
    public class TwitterService : ITwitterService
    {
        private readonly IOAuthCreationService apiService;
        private readonly IJsonObjectDeserializer jsonDeserializerWrapper;

        public TwitterService(
            IOAuthCreationService apiService, 
            IJsonObjectDeserializer jsonDesirealizerWrapper)
        {
            Guard.WhenArgument(apiService, "OAuthCreationService").IsNull().Throw();
            Guard.WhenArgument(jsonDesirealizerWrapper, "JsonUserDeserializer").IsNull().Throw();

            this.apiService = apiService;
            this.jsonDeserializerWrapper = jsonDesirealizerWrapper;
        }

        public TwitterAccountDto GetUserByScreenName(string screenName)
        {
            var resourceUrl = "https://api.twitter.com/1.1/users/show.json?screen_name=";
            var user = apiService.GetTwitterApiCallData(resourceUrl + screenName);
            var deserializedUser = jsonDeserializerWrapper.Deserialize<TwitterAccountDto>(user);

            return deserializedUser;
        }

        public ICollection<TweetDto> GetUsersTimeline(string screenName)
        {
            var resourceUrl = "https://api.twitter.com/1.1/statuses/user_timeline.json?screen_name=";
            var userTimeline = apiService.GetTwitterApiCallData(resourceUrl + screenName);
            var deserializedUserTimeline = jsonDeserializerWrapper.Deserialize<ICollection<TweetDto>>(userTimeline);

            return deserializedUserTimeline;
        }
    }
}
