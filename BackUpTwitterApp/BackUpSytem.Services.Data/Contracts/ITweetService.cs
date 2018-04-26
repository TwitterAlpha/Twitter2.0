using BackUpSystem.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackUpSytem.Services.Data.Contracts
{
    public interface ITweetService
    {
        Task<TweetDto> GetTweetById(string id);

        void DownloadTweet(string userId, TweetDto tweet);

        void DeleteTweet(string userId, string tweetId);
    }
}
