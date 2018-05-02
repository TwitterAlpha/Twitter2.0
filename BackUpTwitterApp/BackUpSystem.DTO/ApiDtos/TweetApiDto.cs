using Newtonsoft.Json;
using System;

namespace BackUpSystem.DTO.ApiDtos
{
    public class TweetApiDto
    {
        [JsonProperty("id_str")]
        public string Id { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        public string TweetAuthor { get; set; }

        [JsonProperty("user")]
        public UserDto User { get; set; }

        public string AuthorImage { get; set; }

        public string TweetUrl { get; set; }

        [JsonProperty("favorite_count")]
        public int LikesCount { get; set; }

        [JsonProperty("retweet_count")]
        public int RetweetCount { get; set; }

        [JsonProperty("entities")]
        public EntitiesApiDto Entities { get; set; }
    }
}
