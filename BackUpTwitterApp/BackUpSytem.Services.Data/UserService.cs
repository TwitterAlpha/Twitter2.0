using BackUpSystem.Data.Models;
using BackUpSystem.Data.Repositories.Contracts;
using BackUpSystem.DTO;
using BackUpSystem.DTO.ApiDtos;
using BackUpSystem.Utilities.Contracts;
using BackUpSystem.Services.Data.Abstracts;
using BackUpSystem.Services.Data.Contracts;
using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BackUpSystem.Services.Data
{
    public class UserService : BaseService, IUserService
    {
        private readonly ITwitterService twitterService;
        private readonly UserManager<User> userManager;

        public UserService(
            IUnitOfWork unitOfWork,
            IMappingProvider mappingProvider,
            IUserRepository userRepository,
            ITwitterService twitterService,
             UserManager<User> userManager)
            : base(unitOfWork, mappingProvider, userRepository)
        {
            Guard.WhenArgument(twitterService, "Twitter Service").IsNull().Throw();
            Guard.WhenArgument(userManager, "User Manager").IsNull().Throw();

            this.twitterService = twitterService;
            this.userManager = userManager;
        }

        public async Task<UserDto> GetUserById(string id)
        {
            Guard.WhenArgument(id, "User Id").IsNullOrEmpty().Throw();

            var user = await this.UserRepository.Get(id);
            Guard.WhenArgument(user, "User").IsNull().Throw();

            var userDto = MappingProvider.MapTo<UserDto>(user);
            Guard.WhenArgument(userDto, "UserDto").IsNull().Throw();

            var adminRoleId = await this.UserRepository.GetAdminRoleId();
            Guard.WhenArgument(adminRoleId, "AdminRole Id").IsNullOrEmpty().Throw();

            //var roles = (await this.UserRepository.GetAllRoles()).Where(r => r.RoleId == adminRoleId);
            //var admins = usersDto.Join(roles, u => u.Id, r => r.UserId, (u, r) => u);
            var isAdmin = (await this.UserRepository.GetAllRoles())?.Any(r => r.RoleId == adminRoleId && r.UserId == id);

            if (isAdmin == true)
            {
                userDto.IsAdmin = true;
            }

            return userDto;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsers()
        {
            var users = (await this.UserRepository.GetAll()).Where(u => !u.IsDeleted);
            Guard.WhenArgument(users, "Users").IsNull().Throw();

            var usersDto = MappingProvider.ProjectTo<User, UserDto>(users);
            Guard.WhenArgument(usersDto, "UsersDto").IsNull().Throw();

            var adminRoleId = await this.UserRepository.GetAdminRoleId();
            Guard.WhenArgument(adminRoleId, "AdminRole Id").IsNullOrEmpty().Throw();

            var roles = (await this.UserRepository.GetAllRoles())?.Where(r => r.RoleId == adminRoleId);
            var admins = usersDto.Join(roles, u => u.Id, r => r.UserId, (u, r) => u);
            Guard.WhenArgument(admins, "Admins").IsNull().Throw();

            foreach (var admin in admins)
            {
                admin.IsAdmin = true;
            }

            return usersDto;
        }

        public async Task<UserDto> GetUserByUsername(string userName)
        {
            Guard.WhenArgument(userName, "Username").IsNullOrEmpty().Throw();

            var user = await this.UserRepository.GetUserByUsername(userName);
            Guard.WhenArgument(user, "User").IsNull().Throw();

            var userDto = MappingProvider.MapTo<UserDto>(user);
            Guard.WhenArgument(userDto, "UserDto").IsNull().Throw();

            return userDto;
        }

        public async Task<IEnumerable<TwitterAccountDto>> GetAllFavoriteTwitterAccounts(string id)
        {
            Guard.WhenArgument(id, "User Id").IsNullOrEmpty().Throw();

            var twitterAccounts = await this.UserRepository.GetAllFavoriteTwitterAccounts(id);
            Guard.WhenArgument(twitterAccounts, "Twitter Accounts").IsNull().Throw();

            var twitterAccountsDto = this.MappingProvider.ProjectTo<TwitterAccount, TwitterAccountDto>(twitterAccounts);
            Guard.WhenArgument(twitterAccountsDto, "Twitter AccountsDto").IsNull().Throw();

            return twitterAccountsDto.OrderBy(t => t.Name);
        }

        public async Task<IEnumerable<TweetApiDto>> GetTimeline(string id)
        {
            Guard.WhenArgument(id, "User Id").IsNullOrEmpty().Throw();

            var twitterAccounts = await this.UserRepository.GetAllFavoriteTwitterAccounts(id);
            Guard.WhenArgument(twitterAccounts, "Twitter Accounts").IsNull().Throw();

            var twitterAccountsDto = this.MappingProvider.ProjectTo<TwitterAccount, TwitterAccountDto>(twitterAccounts);
            Guard.WhenArgument(twitterAccountsDto, "Twitter AccountsDto").IsNull().Throw();

            var sb = new StringBuilder();

            foreach (var twitterAccount in twitterAccountsDto)
            {
                sb.Append($"{twitterAccount.Id},");
            }

            if (sb.Length == 0)
            {
                return new List<TweetApiDto>();
            }

            sb.Length--;

            var timeline = await twitterService.GetTimeline(sb.ToString());
            Guard.WhenArgument(timeline, "Timeline").IsNull().Throw();

            return timeline;
        }

        public async Task<ICollection<TweetApiDto>> GetAllDownloadTweetsByUser(string id)
        {
            Guard.WhenArgument(id, "User Id").IsNullOrEmpty().Throw();

            var downloadedTweets = await this.UserRepository.GetAllDownloadedTweets(id);
            Guard.WhenArgument(downloadedTweets, "Downloaded Tweets").IsNull().Throw();

            var downloadedTweetsDto = this.MappingProvider.ProjectTo<Tweet, TweetApiDto>(downloadedTweets);
            Guard.WhenArgument(downloadedTweetsDto, "Downloaded TweetsDto").IsNull().Throw();

            return downloadedTweetsDto.OrderByDescending(t => t.CreatedAt).ToList();
        }

        public async Task<bool> UpdateName(string id, string name)
        {
            Guard.WhenArgument(id, "User Id").IsNullOrEmpty().Throw();
            Guard.WhenArgument(name, "User Name").IsNullOrEmpty().Throw();

            if (await this.UserRepository.UpdateName(id, name))
            {
                this.UnitOfWork.SaveChanges();
                return true;
            }

            return false;
        }

        public async Task<bool> UpdateBirthDate(string id, DateTime? birthDate)
        {
            Guard.WhenArgument(id, "User Id").IsNullOrEmpty().Throw();
            Guard.WhenArgument(birthDate, "Birth Date").IsNull().Throw();

            if (await this.UserRepository.UpdateBirthDate(id, birthDate))
            {
                this.UnitOfWork.SaveChanges();
                return true;
            }

            return false;
        }

        public async Task UpdateIsAdmin(string id, bool isAdmin)
        {
            var user = await this.userManager.FindByIdAsync(id);

            if (isAdmin)
            {
                await this.userManager.AddToRoleAsync(user, "Admin");
            }
            else
            {
                await this.userManager.RemoveFromRoleAsync(user, "Admin");
            }
        }

        public async Task<bool> UpdateProfileImage(string id, string imageUrl)
        {
            Guard.WhenArgument(id, "User Id").IsNullOrEmpty().Throw();
            Guard.WhenArgument(imageUrl, "Image Url").IsNullOrEmpty().Throw();

            if (await this.UserRepository.UpdateImageUrl(id, imageUrl))
            {
                this.UnitOfWork.SaveChanges();
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteUser(string id)
        {
            Guard.WhenArgument(id, "User Id").IsNullOrEmpty().Throw();

            var user = await this.UserRepository.Get(id);
            Guard.WhenArgument(user, "User").IsNull().Throw();

            if (!user.IsDeleted)
            {
                this.UserRepository.Delete(user);
                this.UserRepository.DeleteUserFromOtherTables(id);
                this.UnitOfWork.SaveChanges();

                return true;
            }

            return false;
        }

        public async Task<int> GetUserRetweets(string userId)
        {
            Guard.WhenArgument(userId, "User Id").IsNullOrEmpty().Throw();

            var user = await this.UserRepository.Get(userId);
            Guard.WhenArgument(user, "User").IsNull().Throw();

            return user.RetweetsCount;
        }

        public async Task DeleteTwitterAccount()
        {

        }
    }
}
