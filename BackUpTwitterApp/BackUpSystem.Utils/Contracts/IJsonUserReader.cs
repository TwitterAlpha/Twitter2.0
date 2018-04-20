using BackUpSystem.DTO;

namespace BackUpSystem.Utilities.Contracts
{
    public interface IJsonUserReader
    {
        object DeserializeUser(string jsonResponseData);
    }
}
