using BackUpSystem.Data.Models;
using BackUpSystem.Data.Repositories.Contracts;
using BackUpSystem.DTO;
using BackUpSystem.Utilities.Contracts;
using BackUpSytem.Services.Data.Contracts;
using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackUpSytem.Services.Data
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMappingProvider mapper;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IMappingProvider mapper)
        {
            Guard.WhenArgument(userRepository, "User Repository").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "Unit of Work").IsNull().Throw();
            Guard.WhenArgument(mapper, "AutoMapper").IsNull().Throw();

            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<UserDto> GetUserById(string id)
        {
            Guard.WhenArgument(id, "User Id").IsNullOrEmpty().Throw();

            var user = await this.userRepository.Get(id);
            Guard.WhenArgument(user, "User").IsNull().Throw();

            var userDto = mapper.MapTo<UserDto>(user);
            Guard.WhenArgument(userDto, "UserDto").IsNull().Throw();

            return userDto;
        }

        public async Task<IEnumerable<TwitterAccountDto>> GetAllFavoriteUsers(string id)
        {
            Guard.WhenArgument(id, "User Id").IsNullOrEmpty().Throw();

            var twitterAccounts = await this.userRepository.GetAllFavoriteTwitterAccounts(id);
            Guard.WhenArgument(twitterAccounts, "Twitter Accounts").IsNull().Throw();

            var twitterAccountsDto = this.mapper.ProjectTo<TwitterAccount, TwitterAccountDto>(twitterAccounts);
            Guard.WhenArgument(twitterAccountsDto, "Twitter AccountsDto").IsNull().Throw();

            return twitterAccountsDto.OrderBy(t => t.Name);
        }

        public async Task<IEnumerable<TweetDto>> GetAllDownloadTweetsByUser(string id)
        {
            Guard.WhenArgument(id, "User Id").IsNullOrEmpty().Throw();

            var downloadedTweets = await this.userRepository.GetAllDownloadedTweets(id);
            Guard.WhenArgument(downloadedTweets, "Downloaded Tweets").IsNull().Throw();

            var downloadedTweetsDto = this.mapper.ProjectTo<Tweet, TweetDto>(downloadedTweets);
            Guard.WhenArgument(downloadedTweetsDto, "Downloaded TweetsDto").IsNull().Throw();

            return downloadedTweetsDto.OrderByDescending(t => t.CreatedAt);
        }

        public void UpdateName(string id, string name)
        {
            Guard.WhenArgument(id, "User Id").IsNullOrEmpty().Throw();
            Guard.WhenArgument(name, "User Name").IsNullOrEmpty().Throw();

            this.userRepository.UpdateName(id, name);
            this.unitOfWork.SaveChanges();
        }

        public void UpdateBirthDate(string id, DateTime? birthDate)
        {
            Guard.WhenArgument(id, "User Id").IsNullOrEmpty().Throw();
            Guard.WhenArgument(birthDate, "Birth Date").IsNull().Throw();

            this.userRepository.UpdateBirthDate(id, birthDate);
            this.unitOfWork.SaveChanges();
        }

        public void UpdateProfileImage(string id, string imageUrl)
        {
            Guard.WhenArgument(id, "User Id").IsNullOrEmpty().Throw();
            Guard.WhenArgument(imageUrl, "Image Url").IsNullOrEmpty().Throw();

            this.userRepository.UpdateImageUrl(id, imageUrl);
            this.unitOfWork.SaveChanges();
        }

        public async void DeleteUser(string id)
        {
            Guard.WhenArgument(id, "User Id").IsNullOrEmpty().Throw();

            var user = await this.userRepository.Get(id);
            Guard.WhenArgument(user, "User").IsNull().Throw();

            if (!user.IsDeleted)
            {
                this.userRepository.Delete(user);
                this.unitOfWork.SaveChanges();
            }
        }
    }
}
