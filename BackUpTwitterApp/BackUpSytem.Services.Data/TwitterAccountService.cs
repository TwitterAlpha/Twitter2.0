using BackUpSystem.Data.Models;
using BackUpSystem.Data.Repositories.Contracts;
using BackUpSystem.DTO;
using BackUpSystem.Utilities.Contracts;
using BackUpSystem.Services.Data.Abstracts;
using BackUpSystem.Services.Data.Contracts;
using Bytes2you.Validation;
using System.Threading.Tasks;

namespace BackUpSystem.Services.Data
{
    public class TwitterAccountService : BaseService, ITwitterAccountService
    {
        private readonly ITwitterAccountRepository twitterAccountRepository;

        public TwitterAccountService(
            IUnitOfWork unitOfWork,
            IMappingProvider mappingProvider,
            IUserRepository UserRepository,
            ITwitterAccountRepository twitterAccountRepository)
            : base(unitOfWork, mappingProvider, UserRepository)
        {
            Guard.WhenArgument(twitterAccountRepository, "TwitterAccount Repository").IsNull().Throw();
            this.twitterAccountRepository = twitterAccountRepository;
        }

        public async Task<TwitterAccountDto> GetTwitterAccountById(string id)
        {
            Guard.WhenArgument(id, "TwitterAccount Id").IsNullOrEmpty().Throw();

            var twitterAccount = await this.twitterAccountRepository.Get(id);
            Guard.WhenArgument(twitterAccount, "TwitterAccount").IsNull().Throw();

            var twitterAccountDto = this.MappingProvider.MapTo<TwitterAccountDto>(twitterAccount);
            Guard.WhenArgument(twitterAccountDto, "TwitterAccount Dto").IsNull().Throw();

            return twitterAccountDto;
        }

        public async Task<bool> AddTwitterAccountToUser(TwitterAccountApiDto twitterAccountApiDto, string userId)
        {
            Guard.WhenArgument(twitterAccountApiDto, "Twitter AccountApiDto").IsNull().Throw();
            Guard.WhenArgument(userId, "User Id").IsNullOrEmpty().Throw();

            var twitterAccountToBeAdded = this.MappingProvider.MapTo<TwitterAccount>(twitterAccountApiDto);
            Guard.WhenArgument(twitterAccountToBeAdded, "Twitter Account to be Added").IsNull().Throw();
            twitterAccountToBeAdded.ImageUrl = twitterAccountToBeAdded.ImageUrl?.Replace("_normal", string.Empty);

            //this.UserRepository.IncludeFavoriteTwitterAccounts();
            var checkIfTwitterAccountExists = await this.twitterAccountRepository.Get(twitterAccountToBeAdded.Id);

            if (checkIfTwitterAccountExists == null)
            {
                this.twitterAccountRepository.Add(twitterAccountToBeAdded);
                await this.UnitOfWork.SaveChangesAsync();
            }

            var user = await this.UserRepository.Get(userId);
            Guard.WhenArgument(user, "User").IsNull().Throw();

            //this.twitterAccountRepository.AddUserTwitterAccount(userId, twitterAccountToBeAdded);

            if (await this.UserRepository.TwitterAccountAddedToUser(user, twitterAccountToBeAdded))
            {
                await this.UnitOfWork.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteTwitterAccountFromUser(string userId, string twitterAccountId)
        {
            Guard.WhenArgument(twitterAccountId, "TwitterAccount Id").IsNull().Throw();
            Guard.WhenArgument(userId, "User Id").IsNullOrEmpty().Throw();

            if (await this.twitterAccountRepository.UserTwitterAccountIsDeleted(userId, twitterAccountId))
            {
                await this.UnitOfWork.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
