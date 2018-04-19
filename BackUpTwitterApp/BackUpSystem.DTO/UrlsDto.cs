using Newtonsoft.Json;

namespace BackUpSystem.DTO
{
    public class UrlsDto
    {
        [JsonProperty("expanded_url")]
        public string WebsiteUrl { get; set; }
    }
}