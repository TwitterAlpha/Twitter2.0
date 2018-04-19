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
        /// Stream reader object handle.
        /// </summary>
        private IStreamReader streamReaderWrapper;

        /// <summary>
        /// JSON User deserializer object handle.
        /// </summary>
        private IJsonUserDeserializer jsonDeserializerWrapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonUserReader"/> class.
        /// </summary>
        /// <param name="streamReaderWrapper">Stream reader wrapper to be used for reading text data.</param>
        /// <param name="jsonDeserializerWrapper">JSON deserializer wrapper to be used for converting JSON text.</param>
        public JsonUserReader(IStreamReader streamReaderWrapper, IJsonUserDeserializer jsonDeserializerWrapper)
        {
            Guard.WhenArgument(streamReaderWrapper, "JsonReader").IsNull().Throw();
            Guard.WhenArgument(jsonDeserializerWrapper, "JsonReader").IsNull().Throw();

            this.streamReaderWrapper = streamReaderWrapper;
            this.jsonDeserializerWrapper = jsonDeserializerWrapper;
        }

        /// <summary>
        /// Gets a UserDto object after an API call.
        /// </summary>
        /// <returns>Collection of Journal DTOs.</returns>
        public UserDto GetUser(Stream streamData)
        {
            using (this.streamReaderWrapper.GetStreamReader(streamData))
            {
                return this.jsonDeserializerWrapper.Deserialize(this.streamReaderWrapper.GetStreamReader(streamData).ReadToEnd());
            }
        }
    }
}
