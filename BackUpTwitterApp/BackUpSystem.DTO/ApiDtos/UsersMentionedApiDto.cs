using Newtonsoft.Json;

namespace BackUpSystem.DTO.ApiDtos
{
    public class UsersMentionedApiDto
    {
        [JsonProperty("screen_name")]
        public string UserName { get; set; }
    }
}