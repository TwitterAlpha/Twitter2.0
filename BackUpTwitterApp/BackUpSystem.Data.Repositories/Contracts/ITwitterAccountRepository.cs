using BackUpSystem.Data.Models;
using BackUpSystem.Date.Repositories.Contracts;
using System.Threading.Tasks;

namespace BackUpSystem.Data.Repositories.Contracts
{
    public interface ITwitterAccountRepository : IRepository<TwitterAccount>
    {
        Task<bool> UserTwitterAccountIsDeleted(string userId, string twitterAccountId);
    }
}
