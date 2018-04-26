using BackUpSystem.DTO;
using System.Threading.Tasks;

namespace BackUpSytem.Services.Data.Contracts
{
    public interface ITwitterAccountService
    {
        Task<TwitterAccountDto> GetTwitterAccountById(string id);

        void AddTwitterAccountToUser(TwitterAccountApiDto twitterAccountApiDto, string userId);

        void DeleteTwitterAccountFromUser(string id, string userId);
    }
}
