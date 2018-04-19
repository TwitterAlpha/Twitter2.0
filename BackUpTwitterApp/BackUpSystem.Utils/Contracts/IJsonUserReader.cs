using BackUpSystem.DTO;

namespace BackUpSystem.NewtonsoftWrapper.Contracts
{
    public interface IJsonUserReader
    {
        TwitterAccountDto DeserializeUser(string jsonResponseData);
    }
}
