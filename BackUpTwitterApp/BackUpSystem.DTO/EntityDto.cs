using Newtonsoft.Json;
using System.Collections.Generic;

namespace BackUpSystem.DTO
{
    public class EntityDto
    {
        [JsonProperty("url")]
        public UrlDto Url { get; set; }

        [JsonProperty("media")]
        public ICollection<MediaDto> Media { get; set; }

        [JsonProperty("hashtags")]
        public ICollection<HashtagDto> Hashtag { get; set; }

        [JsonProperty("user_mentions")]
        public ICollection<UsersMentionedDto> UsersMentioned { get; set; }
    }
}