using BackUpSystem.DTO;
using BackUpSystem.NewtonsoftWrapper.Utils.Contracts;
using Bytes2you.Validation;
using Newtonsoft.Json;

namespace BackUpSystem.NewtonsoftWrapper.Utils
{
    /// <summary>
    /// Abstracts Newtonsoft Json Deserializer in order to be testable
    /// </summary>
    public class JsonUserDeserializer : IJsonUserDeserializer
    {
        /// Deserializes the JSON to the User DTO type - wrapper instance method.
        /// </summary>
        /// <param name="jsonText">The JSON to be deserialized.</param>
        /// <returns>User Dto</returns>
        public UserDto Deserialize(string jsonUserText)
        {
            Guard.WhenArgument(jsonUserText, "Deserialize").IsNullOrEmpty().Throw();

            return JsonConvert.DeserializeObject<UserDto>(jsonUserText);
        }
    }
}
