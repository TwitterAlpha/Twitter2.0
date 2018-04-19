using BackUpSystem.DTO;
using BackUpSystem.NewtonsoftWrapper.Contracts;
using BackUpSystem.NewtonsoftWrapper.Utils.Contracts;
using Bytes2you.Validation;
using System.IO;

namespace BackUpSystem.NewtonsoftWrapper
{
    /// <summary>
    /// Represent a <see cref="JsonUserReader"/> class.
    /// </summary>
    public class JsonUserReader : IJsonUserReader
    {
        /// <summary>
        /// JSON User deserializer object handle.
        /// </summary>
        private IJsonUserDeserializer jsonDeserializerWrapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonUserReader"/> class.
        /// </summary>
        /// <param name="streamReaderWrapper">Stream reader wrapper to be used for reading text data.</param>
        /// <param name="jsonDeserializerWrapper">JSON deserializer wrapper to be used for converting JSON text.</param>
        public JsonUserReader(IJsonUserDeserializer jsonDeserializerWrapper)
        {
            Guard.WhenArgument(jsonDeserializerWrapper, "JsonReader").IsNull().Throw();

            this.jsonDeserializerWrapper = jsonDeserializerWrapper;
        }

        /// <summary>
        /// Gets a UserDto object after an API call.
        /// </summary>
        /// <returns>Collection of Journal DTOs.</returns>
        public TwitterAccountDto DeserializeUser(string jsonResponseData)
        {
            return this.jsonDeserializerWrapper.Deserialize(jsonResponseData);
        }
    }
}
