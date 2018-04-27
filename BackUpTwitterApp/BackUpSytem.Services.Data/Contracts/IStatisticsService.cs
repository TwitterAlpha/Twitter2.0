using BackUpSystem.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackUpSytem.Services.Data.Contracts
{
    public interface IStatisticsService
    {
        Task<int> GetTotalDownloadedTweets();

        Task<int> GetTotalRetweets();

        Task<IEnumerable<User>> GetAllUsersStats();
    }
}
