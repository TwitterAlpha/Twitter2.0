using BackUpSystem.Data.Models;
using BackUpSystem.Data.Repositories.Contracts;
using BackUpSystem.DTO;
using BackUpSystem.Utilities.Contracts;
using BackUpSytem.Services.Data.Abstracts;
using BackUpSytem.Services.Data.Contracts;
using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BackUpSytem.Services.Data
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

        public void DownloadTweet(string userId, TweetDto tweet)
        {
            throw new NotImplementedException();
        }

        public void DeleteTweet(string userId, string tweetId)
        {
            throw new NotImplementedException();
        }
    }
}
