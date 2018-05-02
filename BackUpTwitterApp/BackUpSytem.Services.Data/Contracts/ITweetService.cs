using BackUpSystem.DTO;
using BackUpSystem.DTO.ApiDtos;
using System.Threading.Tasks;

namespace BackUpSystem.Services.Data.Contracts
{
    public interface ITweetService
    {
        Task<TweetDto> GetTweetById(string id);

        Task<bool> DownloadTweet(string userId, TweetApiDto tweet);

        Task<bool> DeleteTweet(string userId, string tweetId);

        string RetweetATweet(string userId, string tweetId);
    }
}
