using BackUpSystem.Data.Models;
using BackUpSystem.Date.Repositories.Contracts;
using System.Threading.Tasks;

namespace BackUpSystem.Data.Repositories.Contracts
{
    public interface ITweetRepository : IRepository<Tweet>
    {
        Task<bool> DownloadTweet(string userId, Tweet tweet);

        Task<bool> UserTweetIsDeleted(string userId, string tweetId);
    }
}
