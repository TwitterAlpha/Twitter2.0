namespace BackUpSystem.Utilities.Contracts
{
    public interface IJsonObjectDeserializer
    {
        Т Deserialize<Т>(string jsonUserText);
    }
}
