using BackUpSystem.Data.Models;
using BackUpSystem.Date.Repositories.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackUpSystem.Data.Repositories.Contracts
{
    public interface ITweetRepository : IRepository<Tweet>
    {
        void DownloadTweet(string userId, Tweet tweet);

        void DeleteTweet(string userId, string tweetId);
    }
}
