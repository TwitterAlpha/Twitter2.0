using BackUpSystem.Data.Models;
using BackUpSystem.Data.Repositories.Contracts;
using BackUpSystem.DTO;
using BackUpSystem.DTO.ApiDtos;
using BackUpSystem.Utilities.Contracts;
using BackUpSystem.Services.Data.Abstracts;
using BackUpSystem.Services.Data.Contracts;
using Bytes2you.Validation;
using System.Threading.Tasks;

namespace BackUpSystem.Services.Data
{
    public class TweetService : BaseService, ITweetService
    {
        private readonly ITweetRepository tweetRepository;

        public TweetService(
            IUnitOfWork unitOfWork, 
            IMappingProvider mappingProvider, 
            IUserRepository userRepository,
            ITweetRepository tweetRepository) 
            : base(unitOfWork, mappingProvider, userRepository)
        {
            Guard.WhenArgument(tweetRepository, "Tweet Repository").IsNull().Throw();
            this.tweetRepository = tweetRepository;
        }

        public async Task<TweetDto> GetTweetById(string id)
        {
            Guard.WhenArgument(id, "Tweet Id").IsNullOrEmpty().Throw();

            var tweet = await this.tweetRepository.Get(id);
            Guard.WhenArgument(tweet, "Tweet").IsNull().Throw();

            var tweetDto = this.MappingProvider.MapTo<TweetDto>(tweet);
            Guard.WhenArgument(tweetDto, "Tweet Dto").IsNull().Throw();

            return tweetDto;
        }

        public async Task<bool> DownloadTweet(string userId, TweetApiDto tweetDto)
        {
            Guard.WhenArgument(userId, "User Id").IsNullOrEmpty().Throw();
            Guard.WhenArgument(tweetDto, "Tweet Dto").IsNull().Throw();

            var tweet = this.MappingProvider.MapTo<Tweet>(tweetDto);
            Guard.WhenArgument(tweet, "Tweet").IsNull().Throw();

            var checkIfTweetExists = await this.tweetRepository.Get(tweet.Id);

            if (checkIfTweetExists == null)
            {
                this.tweetRepository.Add(tweet);
                await this.UnitOfWork.SaveChangesAsync();
            }

            var user = await this.UserRepository.Get(userId);
            Guard.WhenArgument(user, "User").IsNull().Throw();

            //this.tweetRepository.DownloadTweet(userId, tweet);

            if (await this.UserRepository.TweetDownloaded(user, tweet))
            {
                await this.UnitOfWork.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteTweet(string userId, string tweetId)
        {
            Guard.WhenArgument(userId, "User Id").IsNullOrEmpty().Throw();
            Guard.WhenArgument(tweetId, "Tweet Id").IsNull().Throw();

            if (await this.tweetRepository.UserTweetIsDeleted(userId, tweetId))
            {
                await this.UnitOfWork.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public string RetweetATweet(string userId, string tweetId)
        {
            Guard.WhenArgument(userId, "User Id").IsNullOrEmpty().Throw();
            Guard.WhenArgument(tweetId, "Tweet Id").IsNull().Throw();

            var resourceUrl = "https://twitter.com/intent/retweet?tweet_id=" + tweetId;
            this.tweetRepository.RetweetATweet(userId);

            this.UnitOfWork.SaveChanges();

            return resourceUrl;
        }
    }
}
