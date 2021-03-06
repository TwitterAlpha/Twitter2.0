﻿using BackUpSystem.DTO.ApiDtos;
using Newtonsoft.Json;
using System;

namespace BackUpSystem.DTO
{
    public class TwitterAccountApiDto
    {
        [JsonProperty("id_str")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("screen_name")]
        public string UserName { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("entities")]
        public EntitiesApiDto Entities { get; set; }

        [JsonProperty("followers_count")]
        public int FollowersCount { get; set; }

        [JsonProperty("friends_count")]
        public int FollowingCount { get; set; }

        [JsonProperty("favourites_count")]
        public int LikesCount { get; set; }

        [JsonProperty("profile_banner_url")]
        public string BackgroundImage { get; set; } 

        [JsonProperty("status")]
        public TweetApiDto CurrentStatus { get; set; }

        [JsonProperty("statuses_count")]
        public int TweetsCount { get; set; }

        [JsonProperty("created_at")]
        public DateTime? JoinedDate { get; set; }

        [JsonProperty("profile_image_url_https")]
        public string ImageUrl { get; set; }
    }
}
