using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackUpSystem.DTO
{
    public class UrlDto
    {
        [JsonProperty("urls")]
        public ICollection<UrlsDto> Urls { get; set; }
    }
}
