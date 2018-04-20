using BackUpSystem.DTO;

namespace BackUpSystem.NewtonsoftWrapper.Utils.Contracts
{
    public interface IJsonObjectDeserializer
    {
        Т Deserialize<Т>(string jsonUserText);
    }
}
