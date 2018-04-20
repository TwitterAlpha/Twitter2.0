using BackUpSystem.DTO;
using BackUpSystem.NewtonsoftWrapper.Contracts;
using BackUpSystem.NewtonsoftWrapper.Utils.Contracts;
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
        private readonly IJsonUserDeserializer jsonUserDeserializer;
        private readonly IJsonUserTimelineDeserializer jsonUserTimelineDeserializer;

        public TwitterService(
            IOAuthCreationService apiService, 
            IJsonUserDeserializer jsonUserDeserializer, 
            IJsonUserTimelineDeserializer jsonUserTimelineDeserializer)
        {
            Guard.WhenArgument(apiService, "OAuthCreationService").IsNull().Throw();
            Guard.WhenArgument(jsonUserDeserializer, "JsonUserDeserializer").IsNull().Throw();
            Guard.WhenArgument(jsonUserTimelineDeserializer, "JsonUserTimelineDeserializer").IsNull().Throw();

            this.apiService = apiService;
            this.jsonUserDeserializer = jsonUserDeserializer;
            this.jsonUserTimelineDeserializer = jsonUserTimelineDeserializer;
        }

        public TwitterAccountDto GetUserByScreenName(string screenName)
        {
            var resourceUrl = "https://api.twitter.com/1.1/users/show.json?screen_name=";
            var user = apiService.GetTwitterApiCallData(resourceUrl + screenName);
            var deserializedUser = jsonUserDeserializer.Deserialize(user);

            return deserializedUser;
        }

        public ICollection<TweetDto> GetUsersTimeline(string screenName)
        {
            var resourceUrl = "https://api.twitter.com/1.1/statuses/user_timeline.json?screen_name=";
            var user = apiService.GetTwitterApiCallData(resourceUrl + screenName);
            var deserializedUser = jsonUserTimelineDeserializer.Deserialize(user);

            return deserializedUser;
        }
    }
}
