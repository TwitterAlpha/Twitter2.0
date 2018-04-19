using Newtonsoft.Json;
using System;

namespace BackUpSystem.DTO
{
    public class TwitterAccountDto
    {
        [JsonProperty("screen_name")]
        public string UserName { get; set; }
    }
}
