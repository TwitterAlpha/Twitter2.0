using BackUpSystem.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BackUpSytem.Services.Data.Contracts
{
    public interface ITwitterService
    {
        Task<TwitterAccountDto> GetUserById(string id);

        Task<TwitterAccountDto> GetUserByScreenName(string screenName);

        Task<ICollection<TweetDto>> GetUsersTimeline(string screenName);

        Task<ICollection<TwitterAccountDto>> SearchUsersByScreenName(string screenName);
    }
}
