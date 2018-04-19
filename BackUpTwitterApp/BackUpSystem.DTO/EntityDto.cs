using Newtonsoft.Json;
using System.Collections.Generic;

namespace BackUpSystem.DTO
{
    public class EntityDto
    {
        [JsonProperty("url")]
        public UrlDto Url { get; set; }
    }
}