using BackUpSystem.DTO;

namespace BackUpSystem.NewtonsoftWrapper.Utils.Contracts
{
    public interface IJsonUserDeserializer
    {
        TwitterAccountDto Deserialize(string jsonUserText);
    }
}
