using BackUpSystem.DTO;

namespace BackUpSystem.NewtonsoftWrapper.Contracts
{
    public interface IJsonUserReader
    {
        object DeserializeUser(string jsonResponseData);
    }
}
