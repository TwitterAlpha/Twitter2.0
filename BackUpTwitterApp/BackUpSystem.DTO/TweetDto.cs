using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackUpSystem.DTO
{
    public class TweetDto
    {
        [JsonProperty("id_str")]
        public string Id { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("user")]
        public UserDto TweetAuthor { get; set; }

        [JsonProperty("favorite_count")]
        public int LikesCount { get; set; }

        [JsonProperty("retweet_count")]
        public int RetweetCount { get; set; }

        

        public string UserMentioned { get; set; }

        [JsonProperty("entities")]
        public EntitiesDto Entities { get; set; }
    }
}
