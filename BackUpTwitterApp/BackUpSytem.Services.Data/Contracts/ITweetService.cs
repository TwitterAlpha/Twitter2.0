using BackUpSystem.DTO;
using BackUpSystem.DTO.ApiDtos;
using System.Threading.Tasks;

namespace BackUpSytem.Services.Data.Contracts
{
    public interface ITweetService
    {
        Task<TweetDto> GetTweetById(string id);

        Task<bool> DownloadTweet(string userId, TweetApiDto tweet);

        void DeleteTweet(string userId, string tweetId);

        string RetweetATweet(string userId, string tweetId);
    }
}
