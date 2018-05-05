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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackUpSytem.Services.Data.UnitTests.UserServiceTests
{
    [TestClass]
    public class GetAllDownloadTweetsByUser_Should
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
            var tweet = new Tweet() { Id = "1905" };
            var tweets = new List<Tweet>()
            {
                tweet
            };

            var tweetDto = new TweetApiDto() { Id = "1905" };
            var expectedResult = new List<TweetApiDto>()
            {
                tweetDto
            };

            userRepositoryMock
                .Setup(x => x.GetAllDownloadedTweets(userId))
                .ReturnsAsync(tweets);

            mappingProviderMock
                .Setup(x => x.ProjectTo<Tweet, TweetApiDto>(tweets))
                .Returns(expectedResult);

            var userService = new UserService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                twitterServiceMock.Object,
                userManagerMock.Object);

            //Act
            var actualResult = await userService.GetAllDownloadTweetsByUser(userId);

            //Assert
            Assert.IsNotNull(actualResult);
            Assert.AreEqual(actualResult.FirstOrDefault().Id, expectedResult.FirstOrDefault().Id);
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
            var tweet = new Tweet() { Id = "1905" };
            var tweets = new List<Tweet>()
            {
                tweet
            };

            var tweetDto = new TweetApiDto() { Id = "1905" };
            var expectedResult = new List<TweetApiDto>()
            {
                tweetDto
            };

            userRepositoryMock
                .Setup(x => x.GetAllDownloadedTweets(userId))
                .ReturnsAsync(tweets);

            mappingProviderMock
                .Setup(x => x.ProjectTo<Tweet, TweetApiDto>(tweets))
                .Returns(expectedResult);

            var userService = new UserService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                twitterServiceMock.Object,
                userManagerMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await userService.GetAllDownloadTweetsByUser(null));
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
            var tweet = new Tweet() { Id = "1905" };
            var tweets = new List<Tweet>()
            {
                tweet
            };

            var tweetDto = new TweetApiDto() { Id = "1905" };
            var expectedResult = new List<TweetApiDto>()
            {
                tweetDto
            };

            userRepositoryMock
                .Setup(x => x.GetAllDownloadedTweets(userId))
                .ReturnsAsync(tweets);

            mappingProviderMock
                .Setup(x => x.ProjectTo<Tweet, TweetApiDto>(tweets))
                .Returns(expectedResult);

            var userService = new UserService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                twitterServiceMock.Object,
                userManagerMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentException>(async () => await userService.GetAllDownloadTweetsByUser(string.Empty));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenUserRepositoryGetAllDownloadedTweetsMethodReturnsNull()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterServiceMock = new Mock<ITwitterService>();
            var userManagerMock = MockUserManager<User>();

            var userId = "30";
            var tweet = new Tweet() { Id = "1905" };
            var tweets = new List<Tweet>()
            {
                tweet
            };

            var tweetDto = new TweetApiDto() { Id = "1905" };
            var expectedResult = new List<TweetApiDto>()
            {
                tweetDto
            };

            userRepositoryMock
                .Setup(x => x.GetAllDownloadedTweets(userId))
                .ReturnsAsync((ICollection<Tweet>)null);

            mappingProviderMock
                .Setup(x => x.ProjectTo<Tweet, TweetApiDto>(tweets))
                .Returns(expectedResult);

            var userService = new UserService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                twitterServiceMock.Object,
                userManagerMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await userService.GetAllDownloadTweetsByUser(userId));
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
            var tweet = new Tweet() { Id = "1905" };
            var tweets = new List<Tweet>()
            {
                tweet
            };

            var tweetDto = new TweetApiDto() { Id = "1905" };
            var expectedResult = new List<TweetApiDto>()
            {
                tweetDto
            };

            userRepositoryMock
                .Setup(x => x.GetAllDownloadedTweets(userId))
                .ReturnsAsync(tweets);

            mappingProviderMock
                .Setup(x => x.ProjectTo<Tweet, TweetApiDto>(tweets))
                .Returns((ICollection<TweetApiDto>)null);

            var userService = new UserService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                twitterServiceMock.Object,
                userManagerMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await userService.GetAllDownloadTweetsByUser(userId));
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
