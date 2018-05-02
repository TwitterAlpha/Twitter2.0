using BackUpSystem.Data.Repositories.Contracts;
using BackUpSystem.Services.Data;
using BackUpSystem.Services.Data.Contracts;
using BackUpSystem.Utilities.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace BackUpSytem.Services.Data.UnitTests.TwitterAccountServiceTests
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
            var twitterAccountRepositoryMock = new Mock<ITwitterAccountRepository>();

            //Act
            var twitterAccountService = new TwitterAccountService(
                unitOfWorkMock.Object, 
                mappingProviderMock.Object, 
                userRepositoryMock.Object,
                twitterAccountRepositoryMock.Object);

            //Assert
            Assert.IsNotNull(twitterAccountService);
            Assert.IsInstanceOfType(twitterAccountService, typeof(ITwitterAccountService));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithNullUnitOfWorkParameter()
        {
            //Arrange
            //var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterAccountRepositoryMock = new Mock<ITwitterAccountRepository>();

            //Act & Assert
             Assert.ThrowsException<ArgumentNullException>(() => new TwitterAccountService(
                null,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                twitterAccountRepositoryMock.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithNullMappingProviderParameter()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            //var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterAccountRepositoryMock = new Mock<ITwitterAccountRepository>();

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new TwitterAccountService(
               unitOfWorkMock.Object,
               null,
               userRepositoryMock.Object,
               twitterAccountRepositoryMock.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithNullUserRepositoryParameter()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            //var userRepositoryMock = new Mock<IUserRepository>();
            var twitterAccountRepositoryMock = new Mock<ITwitterAccountRepository>();

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new TwitterAccountService(
               unitOfWorkMock.Object,
               mappingProviderMock.Object,
               null,
               twitterAccountRepositoryMock.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithNullTwitterAccountRepositoryParameter()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterAccountRepositoryMock = new Mock<ITwitterAccountRepository>();

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new TwitterAccountService(
               unitOfWorkMock.Object,
               mappingProviderMock.Object,
               userRepositoryMock.Object,
               null));
        }
    }
}
