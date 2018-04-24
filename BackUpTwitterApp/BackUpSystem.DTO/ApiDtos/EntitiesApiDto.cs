using Newtonsoft.Json;
using System.Collections.Generic;

namespace BackUpSystem.DTO.ApiDtos
{
    public class EntitiesApiDto
    {
        [JsonProperty("url")]
        public UrlApiDto Url { get; set; }

        [JsonProperty("media")]
        public ICollection<MediaApiDto> Media { get; set; }

        [JsonProperty("hashtags")]
        public ICollection<HashtagApiDto> Hashtags { get; set; }

        //[JsonProperty("user_mentions")]
        //public ICollection<UsersMentionedDto> UsersMentioned { get; set; }
    }
}