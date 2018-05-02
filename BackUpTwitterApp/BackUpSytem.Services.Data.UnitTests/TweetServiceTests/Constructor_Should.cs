using BackUpSystem.Data.Repositories.Contracts;
using BackUpSystem.Services.Data;
using BackUpSystem.Services.Data.Contracts;
using BackUpSystem.Utilities.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace BackUpSytem.Services.Data.UnitTests.TweetServiceTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void CreateInstance_WhenInvokedWithValidParameters()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var tweetRepositoryMock = new Mock<ITweetRepository>();

            //Act
            var tweetService = new TweetService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                tweetRepositoryMock.Object);

            //Assert
            Assert.IsNotNull(tweetService);
            Assert.IsInstanceOfType(tweetService, typeof(ITweetService));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithNullUnitOfWorkParameter()
        {
            //Arrange
            //var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var tweetRepositoryMock = new Mock<ITweetRepository>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new TweetService(
                null,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                tweetRepositoryMock.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithNullMappingProviderParameter()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            //var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var tweetRepositoryMock = new Mock<ITweetRepository>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new TweetService(
                unitOfWorkMock.Object,
                null,
                userRepositoryMock.Object,
                tweetRepositoryMock.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithNullUserRepositoryParameter()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            //var userRepositoryMock = new Mock<IUserRepository>();
            var tweetRepositoryMock = new Mock<ITweetRepository>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new TweetService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                null,
                tweetRepositoryMock.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithNullTweetRepositoryParameter()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            //var tweetRepositoryMock = new Mock<ITweetRepository>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new TweetService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                null));
        }
    }
}
