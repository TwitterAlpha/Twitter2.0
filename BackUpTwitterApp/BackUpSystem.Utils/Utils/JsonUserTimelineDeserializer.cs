using BackUpSystem.DTO;
using BackUpSystem.NewtonsoftWrapper.Utils.Contracts;
using Bytes2you.Validation;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace BackUpSystem.NewtonsoftWrapper.Utils
{
    public class JsonUserTimelineDeserializer : IJsonUserTimelineDeserializer
    {
        /// Deserializes the JSON to the User DTO type - wrapper instance method.
        /// </summary>
        /// <param name="jsonText">The JSON to be deserialized.</param>
        /// <returns>User Dto</returns>
        public ICollection<TweetDto> Deserialize(string jsonUserText)
        {
            Guard.WhenArgument(jsonUserText, "Deserialize").IsNullOrEmpty().Throw();

            return JsonConvert.DeserializeObject<ICollection<TweetDto>>(jsonUserText,
                new IsoDateTimeConverter { DateTimeFormat = "ddd MMM dd HH:mm:ss zzz yyyy" });
        }
    }
}
