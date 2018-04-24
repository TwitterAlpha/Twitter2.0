using BackUpSystem.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackUpSytem.Services.Data.Contracts
{
    public interface IUserService
    {
        Task<UserDto> GetUserById(string id);

        Task<IEnumerable<TwitterAccountDto>> GetAllFavoriteUsers(string id);

        Task<IEnumerable<TweetDto>> GetAllDownloadTweetsByUser(string id);

        void UpdateName(string id, string name);

        void UpdateBirthDate(string id, DateTime? birthDate);

        void UpdateProfileImage(string id, string imageUrl);

        void DeleteUser(string id);
    }
}