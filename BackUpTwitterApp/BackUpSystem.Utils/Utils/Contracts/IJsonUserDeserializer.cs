using BackUpSystem.DTO;

namespace BackUpSystem.NewtonsoftWrapper.Utils.Contracts
{
    public interface IJsonUserDeserializer
    {
        UserDto Deserialize(string jsonUserText);
    }
}
