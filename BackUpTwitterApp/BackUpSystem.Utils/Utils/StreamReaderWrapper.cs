using BackUpSystem.NewtonsoftWrapper.Utils.Contracts;
using Bytes2you.Validation;
using System.IO;
using System.Net;

namespace BackUpSystem.NewtonsoftWrapper.Utils
{
    /// <summary>
    /// Abstracts StreamReader in order to be testable
    /// </summary>
    public class StreamReaderWrapper : IStreamReader
    {
        public string GetStreamReader(WebResponse stream)
        {
            Guard.WhenArgument(stream, "StreamReaderWrapper").IsNull().Throw();

            return new StreamReader(stream.GetResponseStream()).ReadToEnd();
        }
    }
}
