using BackUpSystem.DTO;
using BackUpSystem.DTO.ApiDtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackUpSytem.Services.Data.Contracts
{
    public interface ITwitterService
    {
        Task<TwitterAccountApiDto> GetUserById(string id);

        Task<ICollection<TwitterAccountApiDto>> SearchUsersByScreenName(string screenName);

        Task<ICollection<TweetApiDto>> GetTimeline(string favUsersIds);

        Task<ICollection<TweetApiDto>> GetUsersTimeline(string screenName);

    }
}
