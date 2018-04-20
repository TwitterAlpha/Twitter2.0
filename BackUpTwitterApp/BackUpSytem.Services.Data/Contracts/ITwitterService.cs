using BackUpSystem.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackUpSytem.Services.Data.Contracts
{
    public interface ITwitterService
    {
        TwitterAccountDto GetUserByScreenName(string screenName);

        ICollection<TweetDto> GetUsersTimeline(string screenName);
    }
}
