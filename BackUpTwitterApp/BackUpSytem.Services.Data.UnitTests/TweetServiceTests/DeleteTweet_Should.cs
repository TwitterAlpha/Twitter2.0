using BackUpSystem.Data.Repositories.Contracts;
using BackUpSystem.Services.Data;
using BackUpSystem.Utilities.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;

namespace BackUpSytem.Services.Data.UnitTests.TweetServiceTests
{
    [TestClass]
    public class DeleteTweet_Should
    {
        [TestMethod]
        public async Task ReturnTrue_WhenTweetSuccessfullyDeleted()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var tweetRepositoryMock = new Mock<ITweetRepository>();

            var userId = "30";
            var tweetId = "1905";

            tweetRepositoryMock
                .Setup(x => x.UserTweetIsDeleted(userId, tweetId))
                .ReturnsAsync(true);

            var tweetService = new TweetService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                tweetRepositoryMock.Object);

            //Act
            var tweetIsDeleted = await tweetService.DeleteTweet(userId, tweetId);

            //Assert
            Assert.IsTrue(tweetIsDeleted);
        }

        [TestMethod]
        public async Task CallSaveChangesOnce_WhenTweetSuccessfullyDeleted()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var tweetRepositoryMock = new Mock<ITweetRepository>();

            var userId = "30";
            var tweetId = "1905";

            tweetRepositoryMock
                .Setup(x => x.UserTweetIsDeleted(userId, tweetId))
                .ReturnsAsync(true);

            var tweetService = new TweetService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                tweetRepositoryMock.Object);

            //Act
            var tweetIsDeleted = await tweetService.DeleteTweet(userId, tweetId);

            //Assert
            unitOfWorkMock.Verify(x => x.SaveChangesAsync(), Times.Once);
        }

        [TestMethod]
        public async Task ReturnFalse_WhenTweetRepositoryTweetIsDeletedMethodReturnsFalse()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var tweetRepositoryMock = new Mock<ITweetRepository>();

            var userId = "30";
            var tweetId = "1905";

            tweetRepositoryMock
                .Setup(x => x.UserTweetIsDeleted(userId, tweetId))
                .ReturnsAsync(false);

            var tweetService = new TweetService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                tweetRepositoryMock.Object);

            //Act
            var tweetIsDeleted = await tweetService.DeleteTweet(userId, tweetId);

            //Assert
            Assert.IsFalse(tweetIsDeleted);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullUserIdParameter()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var tweetRepositoryMock = new Mock<ITweetRepository>();

            var userId = "30";
            var tweetId = "1905";

            tweetRepositoryMock
                .Setup(x => x.UserTweetIsDeleted(userId, tweetId))
                .ReturnsAsync(false);

            var tweetService = new TweetService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                tweetRepositoryMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => tweetService.DeleteTweet(null, tweetId));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithInvalidEmptyUserIdParameter()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var tweetRepositoryMock = new Mock<ITweetRepository>();

            var userId = "30";
            var tweetId = "1905";

            tweetRepositoryMock
                .Setup(x => x.UserTweetIsDeleted(userId, tweetId))
                .ReturnsAsync(false);

            var tweetService = new TweetService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                tweetRepositoryMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentException>(() => tweetService.DeleteTweet(string.Empty, tweetId));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullTweetIdIdParameter()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var tweetRepositoryMock = new Mock<ITweetRepository>();

            var userId = "30";
            var tweetId = "1905";

            tweetRepositoryMock
                .Setup(x => x.UserTweetIsDeleted(userId, tweetId))
                .ReturnsAsync(false);

            var tweetService = new TweetService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                tweetRepositoryMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => tweetService.DeleteTweet(userId, null));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidEmptyTweetIdIdParameter()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var tweetRepositoryMock = new Mock<ITweetRepository>();

            var userId = "30";
            var tweetId = "1905";

            tweetRepositoryMock
                .Setup(x => x.UserTweetIsDeleted(userId, tweetId))
                .ReturnsAsync(false);

            var tweetService = new TweetService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                tweetRepositoryMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentException>(() => tweetService.DeleteTweet(userId, string.Empty));
        }
    }
}
