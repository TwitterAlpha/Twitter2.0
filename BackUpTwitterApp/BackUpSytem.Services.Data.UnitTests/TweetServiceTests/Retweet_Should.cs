using BackUpSystem.Data.Repositories.Contracts;
using BackUpSystem.Services.Data;
using BackUpSystem.Utilities.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace BackUpSytem.Services.Data.UnitTests.TweetServiceTests
{
    [TestClass]
    public class Retweet_Should
    {
        [TestMethod]
        public void ReturnAString_WhenInvokedWithValidParameters()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var tweetRepositoryMock = new Mock<ITweetRepository>();

            var userId = "30";
            var tweetId = "1905";
            var expectedResult = "https://twitter.com/intent/retweet?tweet_id=" + tweetId;

            var tweetService = new TweetService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                tweetRepositoryMock.Object);

            //Act
            var actualResult = tweetService.RetweetATweet(userId, tweetId);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void CallSaveChangesMethodOnce_WhenInvokedWithValidParameters()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var tweetRepositoryMock = new Mock<ITweetRepository>();

            var userId = "30";
            var tweetId = "1905";
            var expectedResult = "https://twitter.com/intent/retweet?tweet_id=" + tweetId;

            var tweetService = new TweetService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                tweetRepositoryMock.Object);

            //Act
            var actualResult = tweetService.RetweetATweet(userId, tweetId);

            //Assert
            unitOfWorkMock.Verify(x => x.SaveChangesAsync(), Times.Once);
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
            var expectedResult = "https://twitter.com/intent/retweet?tweet_id=" + tweetId;

            var tweetService = new TweetService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                tweetRepositoryMock.Object);

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => tweetService.RetweetATweet(null, tweetId));
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
            var expectedResult = "https://twitter.com/intent/retweet?tweet_id=" + tweetId;

            var tweetService = new TweetService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                tweetRepositoryMock.Object);

            //Act && Assert
            Assert.ThrowsException<ArgumentException>(() => tweetService.RetweetATweet(string.Empty, tweetId));
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
            var expectedResult = "https://twitter.com/intent/retweet?tweet_id=" + tweetId;

            var tweetService = new TweetService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                tweetRepositoryMock.Object);

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => tweetService.RetweetATweet(userId, null));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithInvalidEmptyTweetIdParameter()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var tweetRepositoryMock = new Mock<ITweetRepository>();

            var userId = "30";
            var tweetId = "1905";
            var expectedResult = "https://twitter.com/intent/retweet?tweet_id=" + tweetId;

            var tweetService = new TweetService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                tweetRepositoryMock.Object);

            //Act && Assert
            Assert.ThrowsException<ArgumentException>(() => tweetService.RetweetATweet(userId, string.Empty));
        }
    }
}
