using System.IO;
using System.Net;

namespace BackUpSystem.NewtonsoftWrapper.Utils.Contracts
{
    public interface IStreamReader
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="jsonResponseData"></param>
        /// <returns></returns>
        string GetStreamReader(WebResponse stream);
    }
}
