using BackUpSystem.Data.Models;
using BackUpSystem.Data.Repositories.Contracts;
using BackUpSystem.DTO;
using BackUpSystem.DTO.ApiDtos;
using BackUpSystem.Services.Data;
using BackUpSystem.Services.Data.Contracts;
using BackUpSystem.Utilities.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackUpSytem.Services.Data.UnitTests.UserServiceTests
{
    [TestClass]
    public class GetTimeline_Should
    {
        [TestMethod]
        public async Task ReturnCollectionOfTweetDtoObjects_WhenInvokedWithValidParameters()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterServiceMock = new Mock<ITwitterService>();
            var userManagerMock = MockUserManager<User>();

            var userId = "30";
            var twitterAccount = new TwitterAccount() { Name = "Grigor", Id = "30" };
            var twitterAccountSecond = new TwitterAccount() { Name = "Grigor", Id = "40" };
            var twitterAccounts = new List<TwitterAccount>()
            {
                twitterAccount,
                twitterAccountSecond
            };

            var twitterAccountDto = new TwitterAccountDto() { Name = "Grigor", Id = "30" };
            var twitterAccountDtoSecond = new TwitterAccountDto() { Name = "Grigor", Id = "40" };
            var twitterAccountsDto = new List<TwitterAccountDto>()
            {
                twitterAccountDto,
                twitterAccountDtoSecond
            };

            var tweet = new TweetApiDto() { Id = "1905" };
            var expectedResult = new List<TweetApiDto>()
            {
                tweet
            };

            userRepositoryMock
                .Setup(x => x.GetAllFavoriteTwitterAccounts(userId))
                .ReturnsAsync(twitterAccounts);

            mappingProviderMock
                .Setup(x => x.ProjectTo<TwitterAccount, TwitterAccountDto>(twitterAccounts))
                .Returns(twitterAccountsDto);

            twitterServiceMock
                .Setup(x => x.GetTimeline("30,40"))
                .ReturnsAsync(expectedResult);

            var userService = new UserService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                twitterServiceMock.Object,
                userManagerMock.Object);

            //Act
            var actualResult = await userService.GetTimeline(userId);

            //Assert
            Assert.IsNotNull(actualResult);
            Assert.AreSame(actualResult, expectedResult);
        }

        [TestMethod]
        public async Task ReturnEmptyCollectionOfTweets_WhenThereIsNotTwitterAccounts()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterServiceMock = new Mock<ITwitterService>();
            var userManagerMock = MockUserManager<User>();

            var userId = "30";
            var twitterAccount = new TwitterAccount() { Name = "Grigor", Id = "30" };
            var twitterAccountSecond = new TwitterAccount() { Name = "Grigor", Id = "40" };
            var twitterAccounts = new List<TwitterAccount>()
            {
                twitterAccount,
                twitterAccountSecond
            };

            var twitterAccountDto = new TwitterAccountDto() { Name = "Grigor", Id = "30" };
            var twitterAccountDtoSecond = new TwitterAccountDto() { Name = "Grigor", Id = "40" };
            var twitterAccountsDto = new List<TwitterAccountDto>();

            var tweet = new TweetApiDto() { Id = "1905" };
            var expectedResult = new List<TweetApiDto>();

            userRepositoryMock
                .Setup(x => x.GetAllFavoriteTwitterAccounts(userId))
                .ReturnsAsync(twitterAccounts);

            mappingProviderMock
                .Setup(x => x.ProjectTo<TwitterAccount, TwitterAccountDto>(twitterAccounts))
                .Returns(twitterAccountsDto);

            twitterServiceMock
                .Setup(x => x.GetTimeline("30,40"))
                .ReturnsAsync(expectedResult);

            var userService = new UserService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                twitterServiceMock.Object,
                userManagerMock.Object);

            //Act
            var actualResult = await userService.GetTimeline(userId);

            //Assert
            Assert.IsNotNull(actualResult);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullIdParameter()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterServiceMock = new Mock<ITwitterService>();
            var userManagerMock = MockUserManager<User>();

            var userId = "30";
            var twitterAccount = new TwitterAccount() { Name = "Grigor", Id = "30" };
            var twitterAccountSecond = new TwitterAccount() { Name = "Grigor", Id = "40" };
            var twitterAccounts = new List<TwitterAccount>()
            {
                twitterAccount,
                twitterAccountSecond
            };

            var twitterAccountDto = new TwitterAccountDto() { Name = "Grigor", Id = "30" };
            var twitterAccountDtoSecond = new TwitterAccountDto() { Name = "Grigor", Id = "40" };
            var twitterAccountsDto = new List<TwitterAccountDto>()
            {
                twitterAccountDto,
                twitterAccountDtoSecond
            };

            var tweet = new TweetApiDto() { Id = "1905" };
            var expectedResult = new List<TweetApiDto>()
            {
                tweet
            };

            userRepositoryMock
                .Setup(x => x.GetAllFavoriteTwitterAccounts(userId))
                .ReturnsAsync(twitterAccounts);

            mappingProviderMock
                .Setup(x => x.ProjectTo<TwitterAccount, TwitterAccountDto>(twitterAccounts))
                .Returns(twitterAccountsDto);

            twitterServiceMock
                .Setup(x => x.GetTimeline("30,40"))
                .ReturnsAsync(expectedResult);

            var userService = new UserService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                twitterServiceMock.Object,
                userManagerMock.Object);

            //Act
            Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await userService.GetTimeline(null));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithInvalidEmptyIdParameter()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterServiceMock = new Mock<ITwitterService>();
            var userManagerMock = MockUserManager<User>();

            var userId = "30";
            var twitterAccount = new TwitterAccount() { Name = "Grigor", Id = "30" };
            var twitterAccountSecond = new TwitterAccount() { Name = "Grigor", Id = "40" };
            var twitterAccounts = new List<TwitterAccount>()
            {
                twitterAccount,
                twitterAccountSecond
            };

            var twitterAccountDto = new TwitterAccountDto() { Name = "Grigor", Id = "30" };
            var twitterAccountDtoSecond = new TwitterAccountDto() { Name = "Grigor", Id = "40" };
            var twitterAccountsDto = new List<TwitterAccountDto>()
            {
                twitterAccountDto,
                twitterAccountDtoSecond
            };

            var tweet = new TweetApiDto() { Id = "1905" };
            var expectedResult = new List<TweetApiDto>()
            {
                tweet
            };

            userRepositoryMock
                .Setup(x => x.GetAllFavoriteTwitterAccounts(userId))
                .ReturnsAsync(twitterAccounts);

            mappingProviderMock
                .Setup(x => x.ProjectTo<TwitterAccount, TwitterAccountDto>(twitterAccounts))
                .Returns(twitterAccountsDto);

            twitterServiceMock
                .Setup(x => x.GetTimeline("30,40"))
                .ReturnsAsync(expectedResult);

            var userService = new UserService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                twitterServiceMock.Object,
                userManagerMock.Object);

            //Act
            Assert.ThrowsExceptionAsync<ArgumentException>(async () => await userService.GetTimeline(string.Empty));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenUserRepositoryGetAllFavoritesMethodReturnsNull()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterServiceMock = new Mock<ITwitterService>();
            var userManagerMock = MockUserManager<User>();

            var userId = "30";
            var twitterAccount = new TwitterAccount() { Name = "Grigor", Id = "30" };
            var twitterAccountSecond = new TwitterAccount() { Name = "Grigor", Id = "40" };
            var twitterAccounts = new List<TwitterAccount>()
            {
                twitterAccount,
                twitterAccountSecond
            };

            var twitterAccountDto = new TwitterAccountDto() { Name = "Grigor", Id = "30" };
            var twitterAccountDtoSecond = new TwitterAccountDto() { Name = "Grigor", Id = "40" };
            var twitterAccountsDto = new List<TwitterAccountDto>()
            {
                twitterAccountDto,
                twitterAccountDtoSecond
            };

            var tweet = new TweetApiDto() { Id = "1905" };
            var expectedResult = new List<TweetApiDto>()
            {
                tweet
            };

            userRepositoryMock
                .Setup(x => x.GetAllFavoriteTwitterAccounts(userId))
                .ReturnsAsync((IEnumerable<TwitterAccount>)null);

            mappingProviderMock
                .Setup(x => x.ProjectTo<TwitterAccount, TwitterAccountDto>(twitterAccounts))
                .Returns(twitterAccountsDto);

            twitterServiceMock
                .Setup(x => x.GetTimeline("30,40"))
                .ReturnsAsync(expectedResult);

            var userService = new UserService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                twitterServiceMock.Object,
                userManagerMock.Object);

            //Act
            Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await userService.GetTimeline(userId));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenMappingProviderProjectToMethodReturnsNull()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterServiceMock = new Mock<ITwitterService>();
            var userManagerMock = MockUserManager<User>();

            var userId = "30";
            var twitterAccount = new TwitterAccount() { Name = "Grigor", Id = "30" };
            var twitterAccountSecond = new TwitterAccount() { Name = "Grigor", Id = "40" };
            var twitterAccounts = new List<TwitterAccount>()
            {
                twitterAccount,
                twitterAccountSecond
            };

            var twitterAccountDto = new TwitterAccountDto() { Name = "Grigor", Id = "30" };
            var twitterAccountDtoSecond = new TwitterAccountDto() { Name = "Grigor", Id = "40" };
            var twitterAccountsDto = new List<TwitterAccountDto>()
            {
                twitterAccountDto,
                twitterAccountDtoSecond
            };

            var tweet = new TweetApiDto() { Id = "1905" };
            var expectedResult = new List<TweetApiDto>()
            {
                tweet
            };

            userRepositoryMock
                .Setup(x => x.GetAllFavoriteTwitterAccounts(userId))
                .ReturnsAsync(twitterAccounts);

            mappingProviderMock
                .Setup(x => x.ProjectTo<TwitterAccount, TwitterAccountDto>(twitterAccounts))
                .Returns((IEnumerable<TwitterAccountDto>)null);

            twitterServiceMock
                .Setup(x => x.GetTimeline("30,40"))
                .ReturnsAsync(expectedResult);

            var userService = new UserService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                twitterServiceMock.Object,
                userManagerMock.Object);

            //Act
            Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await userService.GetTimeline(userId));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenTwitterServiceGetTimelineMethodReturnsNull()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterServiceMock = new Mock<ITwitterService>();
            var userManagerMock = MockUserManager<User>();

            var userId = "30";
            var twitterAccount = new TwitterAccount() { Name = "Grigor", Id = "30" };
            var twitterAccountSecond = new TwitterAccount() { Name = "Grigor", Id = "40" };
            var twitterAccounts = new List<TwitterAccount>()
            {
                twitterAccount,
                twitterAccountSecond
            };

            var twitterAccountDto = new TwitterAccountDto() { Name = "Grigor", Id = "30" };
            var twitterAccountDtoSecond = new TwitterAccountDto() { Name = "Grigor", Id = "40" };
            var twitterAccountsDto = new List<TwitterAccountDto>()
            {
                twitterAccountDto,
                twitterAccountDtoSecond
            };

            var tweet = new TweetApiDto() { Id = "1905" };
            var expectedResult = new List<TweetApiDto>()
            {
                tweet
            };

            userRepositoryMock
                .Setup(x => x.GetAllFavoriteTwitterAccounts(userId))
                .ReturnsAsync(twitterAccounts);

            mappingProviderMock
                .Setup(x => x.ProjectTo<TwitterAccount, TwitterAccountDto>(twitterAccounts))
                .Returns(twitterAccountsDto);

            twitterServiceMock
                .Setup(x => x.GetTimeline("30,40"))
                .ReturnsAsync((ICollection<TweetApiDto>)null);

            var userService = new UserService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                twitterServiceMock.Object,
                userManagerMock.Object);

            //Act
            Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await userService.GetTimeline(userId));
        }

        public static Mock<UserManager<TUser>> MockUserManager<TUser>() where TUser : class
        {
            var store = new Mock<IUserStore<TUser>>();
            var mgr = new Mock<UserManager<TUser>>(store.Object, null, null, null, null, null, null, null, null);
            mgr.Object.UserValidators.Add(new UserValidator<TUser>());
            mgr.Object.PasswordValidators.Add(new PasswordValidator<TUser>());
            return mgr;
        }
    }
}
