using BackUpSystem.Data.Models;
using BackUpSystem.DTO;
using System.Collections.Generic;

namespace BackUpSytem.Services.Data.Contracts
{
    public interface IUserService
    {
        UserDto GetUserById(string id);

        void AddUser(UserDto user);

        IEnumerable<TwitterAccountDto> GetAllFavoriteUsers(string id);

        IEnumerable<TweetDto> GetAllDownloadTweetsByUser(string id);
    }
}
