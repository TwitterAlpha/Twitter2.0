using BackUpSystem.Data.Repositories.Contracts;
using BackUpSytem.Services.Data.Contracts;
using Bytes2you.Validation;
using System.Linq;
using System.Threading.Tasks;

namespace BackUpSytem.Services.Data
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
    }
}
