using Newtonsoft.Json;

namespace BackUpSystem.DTO
{
    public class HashtagDto
    {
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}