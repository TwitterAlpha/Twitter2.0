using Newtonsoft.Json;
using System.Collections.Generic;

namespace BackUpSystem.DTO.ApiDtos
{
    public class UrlApiDto
    {
        [JsonProperty("urls")]
        public ICollection<UrlsApiDto> Urls { get; set; }
    }
}
