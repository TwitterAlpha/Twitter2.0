﻿using BackUpSystem.Data.Models;
using BackUpSystem.Data.Repositories.Contracts;
using BackUpSystem.DTO;
using BackUpSystem.Utilities.Contracts;
using BackUpSytem.Services.Data.Abstracts;
using BackUpSytem.Services.Data.Contracts;
using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackUpSytem.Services.Data
{
    public class UserService : BaseService, IUserService
    {
        public UserService(
            IUnitOfWork unitOfWork, 
            IMappingProvider mappingProvider, 
            IUserRepository userRepository) 
            : base(unitOfWork, mappingProvider, userRepository)
        {
        }

        public async Task<UserDto> GetUserById(string id)
        {
            Guard.WhenArgument(id, "User Id").IsNullOrEmpty().Throw();

            var user = await this.UserRepository.Get(id);
            Guard.WhenArgument(user, "User").IsNull().Throw();

            var userDto = MappingProvider.MapTo<UserDto>(user);
            Guard.WhenArgument(userDto, "UserDto").IsNull().Throw();

            return userDto;
        }

        public async Task<IEnumerable<TwitterAccountDto>> GetAllFavoriteUsers(string id)
        {
            Guard.WhenArgument(id, "User Id").IsNullOrEmpty().Throw();

            var twitterAccounts = await this.UserRepository.GetAllFavoriteTwitterAccounts(id);
            Guard.WhenArgument(twitterAccounts, "Twitter Accounts").IsNull().Throw();

            var twitterAccountsDto = this.MappingProvider.ProjectTo<TwitterAccount, TwitterAccountDto>(twitterAccounts);
            Guard.WhenArgument(twitterAccountsDto, "Twitter AccountsDto").IsNull().Throw();

            return twitterAccountsDto.OrderBy(t => t.Name);
        }

        public async Task<IEnumerable<TweetDto>> GetAllDownloadTweetsByUser(string id)
        {
            Guard.WhenArgument(id, "User Id").IsNullOrEmpty().Throw();

            var downloadedTweets = await this.UserRepository.GetAllDownloadedTweets(id);
            Guard.WhenArgument(downloadedTweets, "Downloaded Tweets").IsNull().Throw();

            var downloadedTweetsDto = this.MappingProvider.ProjectTo<Tweet, TweetDto>(downloadedTweets);
            Guard.WhenArgument(downloadedTweetsDto, "Downloaded TweetsDto").IsNull().Throw();

            return downloadedTweetsDto.OrderByDescending(t => t.CreatedAt);
        }

        public void UpdateName(string id, string name)
        {
            Guard.WhenArgument(id, "User Id").IsNullOrEmpty().Throw();
            Guard.WhenArgument(name, "User Name").IsNullOrEmpty().Throw();

            this.UserRepository.UpdateName(id, name);
            this.UnitOfWork.SaveChanges();
        }

        public void UpdateBirthDate(string id, DateTime? birthDate)
        {
            Guard.WhenArgument(id, "User Id").IsNullOrEmpty().Throw();
            Guard.WhenArgument(birthDate, "Birth Date").IsNull().Throw();

            this.UserRepository.UpdateBirthDate(id, birthDate);
            this.UnitOfWork.SaveChanges();
        }

        public void UpdateProfileImage(string id, string imageUrl)
        {
            Guard.WhenArgument(id, "User Id").IsNullOrEmpty().Throw();
            Guard.WhenArgument(imageUrl, "Image Url").IsNullOrEmpty().Throw();

            this.UserRepository.UpdateImageUrl(id, imageUrl);
            this.UnitOfWork.SaveChanges();
        }

        public async void DeleteUser(string id)
        {
            Guard.WhenArgument(id, "User Id").IsNullOrEmpty().Throw();

            var user = await this.UserRepository.Get(id);
            Guard.WhenArgument(user, "User").IsNull().Throw();

            if (!user.IsDeleted)
            {
                this.UserRepository.Delete(user);
                this.UserRepository.DeleteUserFromOtherTables(id);
                this.UnitOfWork.SaveChanges();
            }
        }
    }
}
