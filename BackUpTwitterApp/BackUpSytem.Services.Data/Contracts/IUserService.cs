using BackUpSystem.DTO;
using BackUpSystem.DTO.ApiDtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackUpSytem.Services.Data.Contracts
{
    public interface IUserService
    {
        Task<UserDto> GetUserById(string id);

        Task<UserDto> GetUserByUsername(string userName);

        Task<IEnumerable<TwitterAccountDto>> GetAllFavoriteUsers(string id);

        Task<IEnumerable<TweetApiDto>> GetAllDownloadTweetsByUser(string id);

        Task<IEnumerable<TweetApiDto>> GetTimeline(string id);

        void UpdateName(string id, string name);

        void UpdateBirthDate(string id, DateTime? birthDate);

        void UpdateProfileImage(string id, string imageUrl);

        void DeleteUser(string id);

        Task<int> GetUserRetweets(string userId);
    }
}