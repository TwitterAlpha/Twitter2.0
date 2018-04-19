using BackUpSystem.NewtonsoftWrapper.Utils.Contracts;
using Bytes2you.Validation;
using System.IO;

namespace BackUpSystem.NewtonsoftWrapper.Utils
{
    /// <summary>
    /// Abstracts StreamReader in order to be testable
    /// </summary>
    public class StreamReaderWrapper : IStreamReader
    {
        private readonly StreamReader streamReader;

        public StreamReader GetStreamReader(Stream stream)
        {
            Guard.WhenArgument(stream, "StreamReaderWrapper").IsNull().Throw();

            return new StreamReader(stream);
        }
    }
}
