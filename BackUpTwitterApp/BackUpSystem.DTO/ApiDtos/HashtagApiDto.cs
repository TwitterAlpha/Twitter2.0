using Newtonsoft.Json;

namespace BackUpSystem.DTO.ApiDtos
{
    public class HashtagApiDto
    {
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}