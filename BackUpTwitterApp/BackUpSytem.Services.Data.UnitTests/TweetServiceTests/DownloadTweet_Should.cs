using BackUpSystem.Data.Models;
using BackUpSystem.Data.Repositories.Contracts;
using BackUpSystem.DTO.ApiDtos;
using BackUpSystem.Services.Data;
using BackUpSystem.Utilities.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;

namespace BackUpSytem.Services.Data.UnitTests.TweetServiceTests
{
    [TestClass]
    public class DownloadTweet_Should
    {
        [TestMethod]
        public async Task ReturnTrue_WhenTweetSuccessfullyDownloaded()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var tweetRepositoryMock = new Mock<ITweetRepository>();

            var tweetApiDto = new TweetApiDto();
            var tweet = new Tweet() { Id = "30" };
            var user = new User() { Name = "Marto Stamatov" };

            mappingProviderMock
                .Setup(x => x.MapTo<Tweet>(tweetApiDto))
                .Returns(tweet);

            tweetRepositoryMock
                .Setup(x => x.Get(tweet.Id))
                .ReturnsAsync(tweet);

            userRepositoryMock
                .Setup(x => x.Get(user.Id))
                .ReturnsAsync(user);

            userRepositoryMock
                .Setup(x => x.TweetDownloaded(user, tweet))
                .ReturnsAsync(true);

            var tweetService = new TweetService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                tweetRepositoryMock.Object);

            //Act
            var tweetIsDownloaded = await tweetService.DownloadTweet(user.Id, tweetApiDto);

            //Assert
            Assert.IsTrue(tweetIsDownloaded);
        }

        [TestMethod]
        public async Task CallSaveChangesMethodOnce_WhenTweetAlreadyExists()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var tweetRepositoryMock = new Mock<ITweetRepository>();

            var tweetApiDto = new TweetApiDto();
            var tweet = new Tweet() { Id = "30" };
            var user = new User() { Name = "Marto Stamatov" };

            mappingProviderMock
                .Setup(x => x.MapTo<Tweet>(tweetApiDto))
                .Returns(tweet);

            tweetRepositoryMock
                .Setup(x => x.Get(tweet.Id))
                .ReturnsAsync(tweet);

            userRepositoryMock
                .Setup(x => x.Get(user.Id))
                .ReturnsAsync(user);

            userRepositoryMock
                .Setup(x => x.TweetDownloaded(user, tweet))
                .ReturnsAsync(true);

            var tweetService = new TweetService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                tweetRepositoryMock.Object);

            //Act
            var tweetIsDownloaded = await tweetService.DownloadTweet(user.Id, tweetApiDto);

            //Assert
            unitOfWorkMock.Verify(x => x.SaveChangesAsync(), Times.Once);
        }

        [TestMethod]
        public async Task CallSaveChangesMethodTwice_WhenTweetDoesNotExistInTheDatabase()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var tweetRepositoryMock = new Mock<ITweetRepository>();

            var tweetApiDto = new TweetApiDto();
            var tweet = new Tweet() { Id = "30" };
            var user = new User() { Name = "Marto Stamatov" };

            mappingProviderMock
                .Setup(x => x.MapTo<Tweet>(tweetApiDto))
                .Returns(tweet);

            tweetRepositoryMock
                .Setup(x => x.Get(tweet.Id))
                .ReturnsAsync((Tweet)null);

            tweetRepositoryMock.Setup(x => x.Add(tweet)).Verifiable();

            userRepositoryMock
                .Setup(x => x.Get(user.Id))
                .ReturnsAsync(user);

            userRepositoryMock
                .Setup(x => x.TweetDownloaded(user, tweet))
                .ReturnsAsync(true);

            var tweetService = new TweetService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                tweetRepositoryMock.Object);

            //Act
            var tweetIsDownloaded = await tweetService.DownloadTweet(user.Id, tweetApiDto);

            //Assert
            unitOfWorkMock.Verify(x => x.SaveChangesAsync(), Times.Exactly(2));
        }

        [TestMethod]
        public async Task ReturnFalse_WhenUserRepositoryTweedDownloadedMethodReturnsFalse()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var tweetRepositoryMock = new Mock<ITweetRepository>();

            var tweetApiDto = new TweetApiDto();
            var tweet = new Tweet() { Id = "30" };
            var user = new User() { Name = "Marto Stamatov" };

            mappingProviderMock
                .Setup(x => x.MapTo<Tweet>(tweetApiDto))
                .Returns(tweet);

            tweetRepositoryMock
                .Setup(x => x.Get(tweet.Id))
                .ReturnsAsync(tweet);

            userRepositoryMock
                .Setup(x => x.Get(user.Id))
                .ReturnsAsync(user);

            userRepositoryMock
                .Setup(x => x.TweetDownloaded(user, tweet))
                .ReturnsAsync(false);

            var tweetService = new TweetService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                tweetRepositoryMock.Object);

            //Act
            var tweetIsDownloaded = await tweetService.DownloadTweet(user.Id, tweetApiDto);

            //Assert
            Assert.IsFalse(tweetIsDownloaded);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithNullUserIdParameter()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var tweetRepositoryMock = new Mock<ITweetRepository>();

            var tweetApiDto = new TweetApiDto();
            var tweet = new Tweet() { Id = "30" };
            var user = new User() { Name = "Marto Stamatov" };

            mappingProviderMock
                .Setup(x => x.MapTo<Tweet>(tweetApiDto))
                .Returns(tweet);

            tweetRepositoryMock
                .Setup(x => x.Get(tweet.Id))
                .ReturnsAsync(tweet);

            userRepositoryMock
                .Setup(x => x.Get(user.Id))
                .ReturnsAsync(user);

            userRepositoryMock
                .Setup(x => x.TweetDownloaded(user, tweet))
                .ReturnsAsync(true);

            var tweetService = new TweetService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                tweetRepositoryMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => tweetService.DownloadTweet(null, tweetApiDto));
        }


        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithEmptyUserIdParameter()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var tweetRepositoryMock = new Mock<ITweetRepository>();

            var tweetApiDto = new TweetApiDto();
            var tweet = new Tweet() { Id = "30" };
            var user = new User() { Name = "Marto Stamatov" };

            mappingProviderMock
                .Setup(x => x.MapTo<Tweet>(tweetApiDto))
                .Returns(tweet);

            tweetRepositoryMock
                .Setup(x => x.Get(tweet.Id))
                .ReturnsAsync(tweet);

            userRepositoryMock
                .Setup(x => x.Get(user.Id))
                .ReturnsAsync(user);

            userRepositoryMock
                .Setup(x => x.TweetDownloaded(user, tweet))
                .ReturnsAsync(true);

            var tweetService = new TweetService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                tweetRepositoryMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentException>(() => tweetService.DownloadTweet(string.Empty, tweetApiDto));
        }


        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithNullTweetApiDtoParameter()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var tweetRepositoryMock = new Mock<ITweetRepository>();

            var tweetApiDto = new TweetApiDto();
            var tweet = new Tweet() { Id = "30" };
            var user = new User() { Name = "Marto Stamatov" };

            mappingProviderMock
                .Setup(x => x.MapTo<Tweet>(tweetApiDto))
                .Returns(tweet);

            tweetRepositoryMock
                .Setup(x => x.Get(tweet.Id))
                .ReturnsAsync(tweet);

            userRepositoryMock
                .Setup(x => x.Get(user.Id))
                .ReturnsAsync(user);

            userRepositoryMock
                .Setup(x => x.TweetDownloaded(user, tweet))
                .ReturnsAsync(true);

            var tweetService = new TweetService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                tweetRepositoryMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => tweetService.DownloadTweet(user.Id, null));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenMappingProviderMapMethodReturnsNull()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var tweetRepositoryMock = new Mock<ITweetRepository>();

            var tweetApiDto = new TweetApiDto();
            var tweet = new Tweet() { Id = "30" };
            var user = new User() { Name = "Marto Stamatov" };

            mappingProviderMock
                .Setup(x => x.MapTo<Tweet>(tweetApiDto))
                .Returns((Tweet)null);

            tweetRepositoryMock
                .Setup(x => x.Get(tweet.Id))
                .ReturnsAsync(tweet);

            userRepositoryMock
                .Setup(x => x.Get(user.Id))
                .ReturnsAsync(user);

            userRepositoryMock
                .Setup(x => x.TweetDownloaded(user, tweet))
                .ReturnsAsync(true);

            var tweetService = new TweetService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                tweetRepositoryMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => tweetService.DownloadTweet(user.Id, tweetApiDto));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenUserRepositoryGetMethodReturnsNull()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var tweetRepositoryMock = new Mock<ITweetRepository>();

            var tweetApiDto = new TweetApiDto();
            var tweet = new Tweet() { Id = "30" };
            var user = new User() { Name = "Marto Stamatov" };

            mappingProviderMock
                .Setup(x => x.MapTo<Tweet>(tweetApiDto))
                .Returns((Tweet)null);

            tweetRepositoryMock
                .Setup(x => x.Get(tweet.Id))
                .ReturnsAsync(tweet);

            userRepositoryMock
                .Setup(x => x.Get(user.Id))
                .ReturnsAsync((User)null);

            userRepositoryMock
                .Setup(x => x.TweetDownloaded(user, tweet))
                .ReturnsAsync(true);

            var tweetService = new TweetService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                tweetRepositoryMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => tweetService.DownloadTweet(user.Id, tweetApiDto));
        }
    }
}
