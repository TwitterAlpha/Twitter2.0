using BackUpSystem.Data.Models;
using System.Collections.Generic;

namespace BackUpSytem.Services.Data.Contracts
{
    public interface IUserService
    {
        IEnumerable<UserTwitterAccount> GetAllFavoriteUsers(string id);

        IEnumerable<UserTweet> GetAllDownloadTweetsByUser(string id);
    }
}
