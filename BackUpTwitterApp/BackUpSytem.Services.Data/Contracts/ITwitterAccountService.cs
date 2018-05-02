using BackUpSystem.DTO;
using System.Threading.Tasks;

namespace BackUpSystem.Services.Data.Contracts
{
    public interface ITwitterAccountService
    {
        Task<TwitterAccountDto> GetTwitterAccountById(string id);

        Task<bool> AddTwitterAccountToUser(TwitterAccountApiDto twitterAccountApiDto, string userId);

        Task<bool> DeleteTwitterAccountFromUser(string userId, string twitterAccountId);
    }
}
