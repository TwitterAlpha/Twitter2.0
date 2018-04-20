using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackUpSystem.DTO
{
    public class UserDto
    {
        [JsonProperty("id_str")]
        public string AuthorId { get; set; }
    }
}
