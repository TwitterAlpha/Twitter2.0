using BackUpSystem.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackUpSystem.NewtonsoftWrapper.Utils.Contracts
{
    public interface IJsonUserTimelineDeserializer
    {
        ICollection<TweetDto> Deserialize(string jsonUserText);
    }
}
