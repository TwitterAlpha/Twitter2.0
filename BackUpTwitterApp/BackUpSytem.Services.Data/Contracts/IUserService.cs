using BackUpSystem.DTO;
using System;
using System.Collections.Generic;

namespace BackUpSytem.Services.Data.Contracts
{
    public interface IUserService
    {
        UserDto GetUserById(string id);

        IEnumerable<TwitterAccountDto> GetAllFavoriteUsers(string id);

        IEnumerable<TweetDto> GetAllDownloadTweetsByUser(string id);

        void UpdateName(string id, string name);

        void UpdateBirthDate(string id, DateTime? birthDate);

        void UpdateProfileImage(string id, string imageUrl);

        void DeleteUser(string id);
    }
}