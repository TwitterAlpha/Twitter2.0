using System.Net;

namespace BackUpSystem.Utilities.Contracts
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
