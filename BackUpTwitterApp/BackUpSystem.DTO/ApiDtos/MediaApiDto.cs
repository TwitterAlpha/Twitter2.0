using Newtonsoft.Json;

namespace BackUpSystem.DTO.ApiDtos
{
    public class MediaApiDto
    {
        [JsonProperty("media_url")]
        public string MediaUrl { get; set; }
    }
}