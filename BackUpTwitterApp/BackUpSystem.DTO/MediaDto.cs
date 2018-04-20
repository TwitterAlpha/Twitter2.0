using Newtonsoft.Json;

namespace BackUpSystem.DTO
{
    public class MediaDto
    {
        [JsonProperty("media_url")]
        public string MediaUrl { get; set; }
    }
}