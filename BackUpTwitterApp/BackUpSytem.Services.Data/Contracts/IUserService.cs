using BackUpSystem.Data.Models;
using System.Collections.Generic;

namespace BackUpSytem.Services.Data.Contracts
{
    public interface IUserService
    {
        void AddUser(User user);

        IEnumerable<TwitterAccount> GetAllFavoriteUsers(string id);

        IEnumerable<Tweet> GetAllDownloadTweetsByUser(string id);
    }
}
