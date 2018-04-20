using Newtonsoft.Json;

namespace BackUpSystem.DTO
{
    public class UsersMentionedDto
    {
        [JsonProperty("screen_name")]
        public string UserName { get; set; }
    }
}