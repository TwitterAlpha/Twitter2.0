using BackUpSystem.DTO;

namespace BackUpSystem.NewtonsoftWrapper.Contracts
{
    public interface IJsonUserReader
    {
        UserDto GetUser(string jsonResponseData);
    }
}
