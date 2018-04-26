using BackUpSystem.DTO;
using BackUpSystem.DTO.ApiDtos;
using BackUpSystem.Services.Auth.Contracts;
using BackUpSystem.Utilities.Contracts;
using BackUpSytem.Services.Data.Contracts;
using Bytes2you.Validation;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackUpSytem.Services.Data
{
    public class TwitterService : ITwitterService
    {
        private readonly IOAuthCreationService apiService;
        private readonly IJsonObjectDeserializer jsonDeserializerWrapper;

        public TwitterService(
            IOAuthCreationService apiService, 
            IJsonObjectDeserializer jsonDeserealizerWrapper)
        {
            Guard.WhenArgument(apiService, "OAuthCreationService").IsNull().Throw();
            Guard.WhenArgument(jsonDeserealizerWrapper, "JsonUserDeserializer").IsNull().Throw();

            this.apiService = apiService;
            this.jsonDeserializerWrapper = jsonDeserealizerWrapper;
        }

        public async Task<TwitterAccountApiDto> GetUserById(string id)
        {
            Guard.WhenArgument(id, "User Id").IsNullOrEmpty().Throw();

            var resourceUrl = "https://api.twitter.com/1.1/users/show.json?user_id=";
            var userJson = await apiService.GetTwitterApiCallData(resourceUrl + id);
            Guard.WhenArgument(userJson, "Screen name").IsNullOrEmpty().Throw();

            var deserializedUser = jsonDeserializerWrapper.Deserialize<TwitterAccountApiDto>(userJson);
            Guard.WhenArgument(deserializedUser, "Deserialized User").IsNull().Throw();

            return deserializedUser;
        }
       
        public async Task<ICollection<TwitterAccountApiDto>> SearchUsersByScreenName(string screenName)
        {
            Guard.WhenArgument(screenName, "Screen name").IsNullOrEmpty().Throw();

            var resourceUrl = "https://api.twitter.com/1.1/users/search.json?q=";
            var userJson = await apiService.GetTwitterApiCallData($"{resourceUrl}{screenName}&count=5");
            Guard.WhenArgument(userJson, "Screen name").IsNullOrEmpty().Throw();

            var deserializedUser = jsonDeserializerWrapper.Deserialize<ICollection<TwitterAccountApiDto>>(userJson);
            Guard.WhenArgument(deserializedUser, "Deserialized User").IsNull().Throw();

            return deserializedUser;
        }

        public async Task<ICollection<TweetApiDto>> GetTimeline(string favUsersIds)
        {
            Guard.WhenArgument(favUsersIds, "Favorite users Ids").IsNullOrEmpty().Throw();

            var resourceUrl = "https://api.twitter.com/1.1/users/lookup.json?user_id=";
            var userJson = await apiService.GetTwitterApiCallData(resourceUrl + favUsersIds);
            Guard.WhenArgument(userJson, "User Json").IsNullOrEmpty().Throw();

            var deserializedUsers = jsonDeserializerWrapper.Deserialize<ICollection<TwitterAccountApiDto>>(userJson);
            Guard.WhenArgument(deserializedUsers, "Deserialized User").IsNull().Throw();

            foreach (var twitterAccount in deserializedUsers)
            {
                twitterAccount.CurrentStatus.TweetAuthor = twitterAccount.Name;
                //twitterAccount.CurrentStatus.AuthorImage = twitterAccount.ImageUrl;
            }

            var timeline = deserializedUsers
                .Select(u => u.CurrentStatus)
                .OrderByDescending(t => t.CreatedAt)
                .ToList();

            return timeline;
        }

        public async Task<ICollection<TweetApiDto>> GetUsersTimeline(string screenName)
        {
            Guard.WhenArgument(screenName, "Screen name").IsNullOrEmpty().Throw();

            var resourceUrl = "https://api.twitter.com/1.1/statuses/user_timeline.json?screen_name=";
            var userTimelineJson = await apiService.GetTwitterApiCallData(resourceUrl + screenName);
            Guard.WhenArgument(userTimelineJson, "UserTimeline Json").IsNullOrEmpty().Throw();

            var deserializedUserTimeline = jsonDeserializerWrapper.Deserialize<ICollection<TweetApiDto>>(userTimelineJson);
            Guard.WhenArgument(deserializedUserTimeline, "Deserialized UserTimeline").IsNull().Throw();

            return deserializedUserTimeline;
        }
    }
}
