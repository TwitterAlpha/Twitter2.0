using BackUpSystem.Data.Models;
using BackUpSystem.Data.Repositories.Contracts;
using BackUpSytem.Services.Data.Contracts;
using Bytes2you.Validation;
using System.Collections.Generic;
using System.Linq;

namespace BackUpSytem.Services.Data
{
    public class UserService : IUserService
    {
        private readonly IUserRepository repository;

        public UserService(IUserRepository repository)
        {
            Guard.WhenArgument(repository, "User Repository").IsNull().Throw();
            this.repository = repository;
        }

        public IEnumerable<UserTwitterAccount> GetAllFavoriteUsers(string id)
        {
            var twitterAccounts = this.repository.GetAllFavoriteTwitterAccounts(id);

            return twitterAccounts.OrderBy(t => t.TwitterAccount.Name);
        }

        public IEnumerable<UserTweet> GetAllDownloadTweetsByUser(string id)
        {
            var downloadedTweets = this.repository.GetAllDownloadedTweets(id);

            return downloadedTweets.OrderByDescending(t => t.Tweet.CreatedAt);
        }
    }
}
