using BackUpSystem.DTO;
using BackUpSystem.DTO.ApiDtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackUpSystem.Services.Data.Contracts
{
    public interface ITwitterService
    {
        Task<TwitterAccountApiDto> GetUserById(string id);

        Task<TwitterAccountApiDto> GetUserByScreenName(string screenName);

        Task<ICollection<TwitterAccountApiDto>> SearchUsersByScreenName(string screenName);

        Task<ICollection<TweetApiDto>> GetTimeline(string favUsersIds);

        Task<ICollection<TweetApiDto>> GetUsersTimeline(string userId);
    }
}
