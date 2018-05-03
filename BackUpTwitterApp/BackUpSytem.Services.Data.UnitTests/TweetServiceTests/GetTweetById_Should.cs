using BackUpSystem.Data.Models;
using BackUpSystem.Data.Repositories.Contracts;
using BackUpSystem.DTO;
using BackUpSystem.Services.Data;
using BackUpSystem.Utilities.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;

namespace BackUpSytem.Services.Data.UnitTests.TweetServiceTests
{
    [TestClass]
    public class GetTweetById_Should
    {
        [TestMethod]
        public async Task ReturnTweetDtoObject_WhenInvokedWithValidParameters()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var tweetRepositoryMock = new Mock<ITweetRepository>();

            var tweetId = "30";
            var tweet = new Tweet() { Text = "Netflix&Chill" };
            var expectedResult = new TweetDto() { Text = "Netflix&Chill" };

            tweetRepositoryMock
                .Setup(x => x.Get(tweetId))
                .ReturnsAsync(tweet);

            mappingProviderMock
                .Setup(x => x.MapTo<TweetDto>(tweet))
                .Returns(expectedResult);

            var tweetService = new TweetService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                tweetRepositoryMock.Object);

            //Act
            var actualResult = await tweetService.GetTweetById(tweetId);

            //Assert
            Assert.IsNotNull(actualResult);
            Assert.AreEqual(actualResult.Text, expectedResult.Text);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullTweetIdParameter()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var tweetRepositoryMock = new Mock<ITweetRepository>();

            var tweetId = "30";
            var tweet = new Tweet() { Text = "Netflix&Chill" };
            var expectedResult = new TweetDto() { Text = "Netflix&Chill" };

            tweetRepositoryMock
                .Setup(x => x.Get(tweetId))
                .ReturnsAsync(tweet);

            mappingProviderMock
                .Setup(x => x.MapTo<TweetDto>(tweet))
                .Returns(expectedResult);

            var tweetService = new TweetService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                tweetRepositoryMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await tweetService.GetTweetById(null));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithInvalidEmptyTweetIdParameter()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var tweetRepositoryMock = new Mock<ITweetRepository>();

            var tweetId = "30";
            var tweet = new Tweet() { Text = "Netflix&Chill" };
            var expectedResult = new TweetDto() { Text = "Netflix&Chill" };

            tweetRepositoryMock
                .Setup(x => x.Get(tweetId))
                .ReturnsAsync(tweet);

            mappingProviderMock
                .Setup(x => x.MapTo<TweetDto>(tweet))
                .Returns(expectedResult);

            var tweetService = new TweetService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                tweetRepositoryMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentException>(async () => await tweetService.GetTweetById(string.Empty));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenTweetRepositoryGetMethodReturnsNull()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var tweetRepositoryMock = new Mock<ITweetRepository>();

            var tweetId = "30";
            var tweet = new Tweet() { Text = "Netflix&Chill" };
            var expectedResult = new TweetDto() { Text = "Netflix&Chill" };

            tweetRepositoryMock
                .Setup(x => x.Get(tweetId))
                .ReturnsAsync((Tweet)null);

            mappingProviderMock
                .Setup(x => x.MapTo<TweetDto>(tweet))
                .Returns(expectedResult);

            var tweetService = new TweetService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                tweetRepositoryMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentException>(async () => await tweetService.GetTweetById(tweetId));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenMappingProviderMapMethodReturnsNull()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var tweetRepositoryMock = new Mock<ITweetRepository>();

            var tweetId = "30";
            var tweet = new Tweet() { Text = "Netflix&Chill" };
            var expectedResult = new TweetDto() { Text = "Netflix&Chill" };

            tweetRepositoryMock
                .Setup(x => x.Get(tweetId))
                .ReturnsAsync(tweet);

            mappingProviderMock
                .Setup(x => x.MapTo<TweetDto>(tweet))
                .Returns((TweetDto)null);

            var tweetService = new TweetService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                tweetRepositoryMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentException>(async () => await tweetService.GetTweetById(tweetId));
        }
    }
}
    