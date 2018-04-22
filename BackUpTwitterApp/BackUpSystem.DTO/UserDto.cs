using Newtonsoft.Json;

namespace BackUpSystem.DTO
{
    public class UserDto
    {
        [JsonProperty("id_str")]
        public string AuthorId { get; set; }
    }
}
