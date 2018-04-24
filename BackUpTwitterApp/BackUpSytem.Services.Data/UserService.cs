using BackUpSystem.Data.Models;
using BackUpSystem.Data.Repositories.Contracts;
using BackUpSystem.DTO;
using BackUpSystem.Utilities.Contracts;
using BackUpSytem.Services.Data.Contracts;
using Bytes2you.Validation;
using System.Collections.Generic;
using System.Linq;

namespace BackUpSytem.Services.Data
{
    public class UserService : IUserService
    {
        private readonly IUserRepository repository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMappingProvider mapper;

        public UserService(IUserRepository repository, IUnitOfWork unitOfWork, IMappingProvider mapper)
        {
            Guard.WhenArgument(repository, "User Repository").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "Unit of Work").IsNull().Throw();
            Guard.WhenArgument(mapper, "AutoMapper").IsNull().Throw();

            this.repository = repository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public UserDto GetUserById(string id)
        {
            var user = this.repository.Get(id);

            var userDto = mapper.MapTo<UserDto>(user);

            return userDto;
        }

        public void AddUser(UserDto userDto)
        {
            var user = this.mapper.MapTo<User>(userDto);

            var tw1 = new Tweet() { Id = "9999", Text ="aTEst", AuthorId = "444" };
            var tw2 = new Tweet() { Id = "8888", Text ="TaEstss", AuthorId = "444" };
            var one = new TwitterAccount() { Id = "777", Name = "Pes", UserName = "pes", WebsiteUrl = "website" };
            var two = new TwitterAccount() { Id = "66", Name = "Sas", UserName = "sas", WebsiteUrl = "site" };

            var test = new User();
            test.Id = "444";
            test.TwitterAccounts = new List<UserTwitterAccount>() { new UserTwitterAccount { TwitterAccount = one }, new UserTwitterAccount { TwitterAccount = two } };
            test.FavoriteTweets = new List<UserTweet>() { new UserTweet { Tweet = tw1 }, new UserTweet { Tweet = tw2 } };

            repository.Add(test);
            unitOfWork.SaveChanges();

        }

        public IEnumerable<TwitterAccountDto> GetAllFavoriteUsers(string id)
        {
            var twitterAccounts = this.repository.GetAllFavoriteTwitterAccounts(id);
            var twitterAccountsDto = this.mapper.ProjectTo<TwitterAccountDto>(twitterAccounts);

            return twitterAccountsDto.OrderBy(t => t.Name);
        }

        public IEnumerable<TweetDto> GetAllDownloadTweetsByUser(string id)
        {
            var downloadedTweets = this.repository.GetAllDownloadedTweets(id);
            var downloadedTweetsDto = this.mapper.ProjectTo<TweetDto>(downloadedTweets);

            return downloadedTweetsDto.OrderByDescending(t => t.CreatedAt);
        }
    }
}
