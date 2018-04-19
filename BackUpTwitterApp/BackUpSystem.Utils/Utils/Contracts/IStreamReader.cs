using System.IO;

namespace BackUpSystem.NewtonsoftWrapper.Utils.Contracts
{
    public interface IStreamReader
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="jsonResponseData"></param>
        /// <returns></returns>
        StreamReader GetStreamReader(Stream stream);
    }
}
