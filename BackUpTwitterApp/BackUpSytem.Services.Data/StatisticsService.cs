using BackUpSystem.Data.Models;
using BackUpSystem.Data.Repositories.Contracts;
using BackUpSystem.Services.Data.Contracts;
using Bytes2you.Validation;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackUpSystem.Services.Data
{
    public class StatisticsService : IStatisticsService
    {
        private readonly ITweetRepository tweetRepository;
        private readonly IUserRepository userRepository;

        public StatisticsService(ITweetRepository tweetRepository, IUserRepository userRepository)
        {
            Guard.WhenArgument(tweetRepository, "Tweet Repository").IsNull().Throw();
            Guard.WhenArgument(userRepository, "User Repository").IsNull().Throw();

            this.tweetRepository = tweetRepository;
            this.userRepository = userRepository;
        }

        public async Task<int> GetTotalDownloadedTweets()
        {
            var totalDownloadedTweets = await tweetRepository.GetAll();
            Guard.WhenArgument(totalDownloadedTweets, "Total Downloaded Tweets").IsNull().Throw();

            return totalDownloadedTweets.Count();
        }

        public async Task<int> GetTotalRetweets()
        {
            var totalUsers = await userRepository.GetAll();
            Guard.WhenArgument(totalUsers, "Total Users").IsNull().Throw();

            return totalUsers.Sum(x => x.RetweetsCount);
        }

        public async Task<IEnumerable<User>> GetAllUsersStats()
        {
            var totalUsers = await userRepository.GetAll();
            Guard.WhenArgument(totalUsers, "Total Users").IsNull().Throw();

            return totalUsers.OrderBy(u => u.Name);
        }
    }
}
