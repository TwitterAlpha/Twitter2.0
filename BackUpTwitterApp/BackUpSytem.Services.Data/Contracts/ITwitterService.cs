using BackUpSystem.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BackUpSytem.Services.Data.Contracts
{
    public interface ITwitterService
    {
        Task<TwitterAccountApiDto> GetUserById(string id);

        Task<TwitterAccountApiDto> GetUserByScreenName(string screenName);

        Task<ICollection<TweetDto>> GetUsersTimeline(string screenName);

        Task<ICollection<TwitterAccountApiDto>> SearchUsersByScreenName(string screenName);
    }
}
