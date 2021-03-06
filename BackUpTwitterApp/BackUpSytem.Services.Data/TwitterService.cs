﻿using BackUpSystem.DTO;
using BackUpSystem.DTO.ApiDtos;
using BackUpSystem.Services.Auth.Contracts;
using BackUpSystem.Utilities.Contracts;
using BackUpSystem.Services.Data.Contracts;
using Bytes2you.Validation;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackUpSystem.Services.Data
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
            Guard.WhenArgument(userJson, "Json Response").IsNullOrEmpty().Throw();

            var deserializedUser = jsonDeserializerWrapper.Deserialize<TwitterAccountApiDto>(userJson);
            Guard.WhenArgument(deserializedUser, "Deserialized User").IsNull().Throw();

            return deserializedUser;
        }

        public async Task<TwitterAccountApiDto> GetUserByScreenName(string screenName)
        {
            Guard.WhenArgument(screenName, "User ScreenName").IsNullOrEmpty().Throw();

            var resourceUrl = "https://api.twitter.com/1.1/users/show.json?screen_name=";
            var userJson = await apiService.GetTwitterApiCallData(resourceUrl + screenName);
            Guard.WhenArgument(userJson, "Json Response").IsNullOrEmpty().Throw();

            var deserializedUser = jsonDeserializerWrapper.Deserialize<TwitterAccountApiDto>(userJson);
            Guard.WhenArgument(deserializedUser, "Deserialized User").IsNull().Throw();

            return deserializedUser;
        }

        public async Task<ICollection<TwitterAccountApiDto>> SearchUsersByScreenName(string screenName)
        {
            Guard.WhenArgument(screenName, "Screen name").IsNullOrEmpty().Throw();

            var resourceUrl = "https://api.twitter.com/1.1/users/search.json?q=";
            var userJson = await apiService.GetTwitterApiCallData($"{resourceUrl}{screenName}&count=20");
            Guard.WhenArgument(userJson, "Json Response").IsNullOrEmpty().Throw();

            var deserializedUsers = jsonDeserializerWrapper.Deserialize<ICollection<TwitterAccountApiDto>>(userJson);
            Guard.WhenArgument(deserializedUsers, "Deserialized Users").IsNull().Throw();
                    
            return deserializedUsers;
        }

        public async Task<ICollection<TweetApiDto>> GetTimeline(string favUsersIds)
        {
            Guard.WhenArgument(favUsersIds, "Favorite users Ids").IsNullOrEmpty().Throw();

            var resourceUrl = "https://api.twitter.com/1.1/users/lookup.json?user_id=";
            var userJson = await apiService.GetTwitterApiCallData(resourceUrl + favUsersIds);
            Guard.WhenArgument(userJson, "Json Response").IsNullOrEmpty().Throw();

            var deserializedUsers = jsonDeserializerWrapper.Deserialize<ICollection<TwitterAccountApiDto>>(userJson)
                .Where(s => s.CurrentStatus != null);
            Guard.WhenArgument(deserializedUsers, "Deserialized Tweets").IsNull().Throw();

            foreach (var twitterAccount in deserializedUsers)
            {
                twitterAccount.CurrentStatus.TweetAuthor = twitterAccount.Name;
                twitterAccount.CurrentStatus.TweetUrl = $"https://twitter.com/{twitterAccount.UserName}/status/{twitterAccount.CurrentStatus.Id}?ref_src=twsrc%5Etfw";
                //twitterAccount.CurrentStatus.AuthorImage = twitterAccount.ImageUrl;
            }

            var timeline = deserializedUsers
                .Select(u => u.CurrentStatus)
                .OrderByDescending(t => t.CreatedAt)
                .ToList();

            return timeline;
        }

        public async Task<ICollection<TweetApiDto>> GetUsersTimeline(string userId)
        {
            Guard.WhenArgument(userId, "User Id").IsNullOrEmpty().Throw();

            var resourceUrl = "https://api.twitter.com/1.1/statuses/user_timeline.json?user_id=";
            var userTimelineJson = await apiService.GetTwitterApiCallData($"{resourceUrl}{userId}&count=20");
            Guard.WhenArgument(userTimelineJson, "Json Response").IsNullOrEmpty().Throw();

            var deserializedUserTimeline = jsonDeserializerWrapper.Deserialize<ICollection<TweetApiDto>>(userTimelineJson);
            Guard.WhenArgument(deserializedUserTimeline, "Deserialized Tweets").IsNull().Throw();

            foreach (var tweet in deserializedUserTimeline)
            {
                tweet.TweetUrl = $"https://twitter.com/screenName/status/{tweet.Id}?ref_src=twsrc%5Etfw";
            }

            return deserializedUserTimeline;
        }
    }
}
