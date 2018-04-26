using System.Threading.Tasks;

namespace BackUpSytem.Services.Data.Contracts
{
    public interface IStatisticsService
    {
        Task<int> GetTotalDownloadedTweets();

        Task<int> GetTotalRetweets();
    }
}
