using BackUpSystem.DTO;
using BackUpSystem.DTO.ApiDtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackUpSystem.Services.Data.Contracts
{
    public interface IUserService
    {
        Task UpdateIsAdmin(string id, bool isAdmin);

        Task<IEnumerable<UserDto>> GetAllUsers();

        Task<UserDto> GetUserById(string id);

        Task<UserDto> GetUserByUsername(string userName);

        Task<IEnumerable<TwitterAccountDto>> GetAllFavoriteTwitterAccounts(string id);

        Task<ICollection<TweetApiDto>> GetAllDownloadTweetsByUser(string id);

        Task<IEnumerable<TweetApiDto>> GetTimeline(string id);

        Task UpdateName(string id, string name);

        Task UpdateBirthDate(string id, DateTime? birthDate);

        Task UpdateProfileImage(string id, string imageUrl);

        Task DeleteUser(string id);

        Task<int> GetUserRetweets(string userId);
    }
}