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
        private readonly IUnitOfWork unitOfWork;

        public UserService(IUserRepository repository, IUnitOfWork unitOfWork)
        {
            Guard.WhenArgument(repository, "User Repository").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "Unit of Work").IsNull().Throw();

            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public void AddUser(User user)
        {
            var one = new TwitterAccount() { Id = "11", Name = "Pesho", UserName = "peshooo" };
            var two = new TwitterAccount() { Id = "22", Name = "Sasho", UserName = "sashooo" };

            var test = new User()
            { TwitterAccounts = new List<UserTwitterAccount>() { new UserTwitterAccount { TwitterAccount = one }, new UserTwitterAccount { TwitterAccount = two } } };
            test.Id = "5555";
            repository.Add(test);
            unitOfWork.SaveChanges();

        }

        public IEnumerable<TwitterAccount> GetAllFavoriteUsers(string id)
        {
            var twitterAccounts = this.repository.GetAllFavoriteTwitterAccounts(id);

            return twitterAccounts.OrderBy(t => t.Name);
        }

        public IEnumerable<Tweet> GetAllDownloadTweetsByUser(string id)
        {
            var downloadedTweets = this.repository.GetAllDownloadedTweets(id);

            return downloadedTweets.OrderByDescending(t => t.CreatedAt);
        }
    }
}
