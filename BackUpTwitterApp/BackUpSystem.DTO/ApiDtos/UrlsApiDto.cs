using Newtonsoft.Json;

namespace BackUpSystem.DTO.ApiDtos
{
    public class UrlsApiDto
    {
        [JsonProperty("expanded_url")]
        public string WebsiteUrl { get; set; }
    }
}