using Newtonsoft.Json;
using System;

namespace BackUpSystem.DTO
{
    public class TwitterAccountDto
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
        public EntityDto Entities { get; set; }

        [JsonProperty("followers_count")]
        public int FollowersCount { get; set; }

        [JsonProperty("friends_count")]
        public int FollowingCount { get; set; }

        [JsonProperty("favourites_count")]
        public int LikesCount { get; set; }

        [JsonProperty("statuses_count")]
        public int TweetsCount { get; set; }

        [JsonProperty("created_at")]
        public DateTime? JoinedDate { get; set; }

        [JsonProperty("profile_image_url_https")]
        public string ImageUrl { get; set; }
    }
}
