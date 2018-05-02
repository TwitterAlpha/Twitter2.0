using BackUpSystem.Data.Models;
using BackUpSystem.Data.Repositories.Contracts;
using BackUpSystem.DTO;
using BackUpSystem.Services.Data;
using BackUpSystem.Utilities.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BackUpSytem.Services.Data.UnitTests.TwitterAccountServiceTests
{
    [TestClass]
    public class GetTwitterAccountById_Should
    {
        [TestMethod]
        public async Task ReturnTwitterAccount_WhenInvokedWithValidIdParameter()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterAccountRepositoryMock = new Mock<ITwitterAccountRepository>();

            var userId = "30";
            var twitterAccount = new TwitterAccount() { Name = "Marto Stamatov" };
            var expectedResult = new TwitterAccountDto() { Name = "Marto Stamatov" };

            twitterAccountRepositoryMock
                .Setup(x => x.Get(userId))
                .ReturnsAsync(twitterAccount);

            mappingProviderMock
                .Setup(x => x.MapTo<TwitterAccountDto>(twitterAccount))
                .Returns(expectedResult);

            var twitterAccountService = new TwitterAccountService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                twitterAccountRepositoryMock.Object);

            //Act
            var actualResult = await twitterAccountService.GetTwitterAccountById(userId);

            //Assert
            Assert.IsNotNull(actualResult);
            Assert.AreEqual(actualResult.Name, expectedResult.Name);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullUserIdParameter()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterAccountRepositoryMock = new Mock<ITwitterAccountRepository>();

            string userId = null;
            var twitterAccount = new TwitterAccount() { Name = "Marto Stamatov" };
            var expectedResult = new TwitterAccountDto() { Name = "Marto Stamatov" };

            twitterAccountRepositoryMock
                .Setup(x => x.Get(userId))
                .ReturnsAsync(twitterAccount);

            mappingProviderMock
                .Setup(x => x.MapTo<TwitterAccountDto>(twitterAccount))
                .Returns(expectedResult);

            var twitterAccountService = new TwitterAccountService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                twitterAccountRepositoryMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await twitterAccountService.GetTwitterAccountById(userId));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithInvalidEmptyUserIdParameter()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterAccountRepositoryMock = new Mock<ITwitterAccountRepository>();

            string userId = string.Empty;
            var twitterAccount = new TwitterAccount() { Name = "Marto Stamatov" };
            var expectedResult = new TwitterAccountDto() { Name = "Marto Stamatov" };

            twitterAccountRepositoryMock
                .Setup(x => x.Get(userId))
                .ReturnsAsync(twitterAccount);

            mappingProviderMock
                .Setup(x => x.MapTo<TwitterAccountDto>(twitterAccount))
                .Returns(expectedResult);

            var twitterAccountService = new TwitterAccountService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                twitterAccountRepositoryMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentException>(async () => await twitterAccountService.GetTwitterAccountById(userId));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenTwitterAccountRepositoryMethodReturnsNull()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterAccountRepositoryMock = new Mock<ITwitterAccountRepository>();

            string userId = null;
            TwitterAccount twitterAccount = null;
            var expectedResult = new TwitterAccountDto() { Name = "Marto Stamatov" };

            twitterAccountRepositoryMock
                .Setup(x => x.Get(userId))
                .ReturnsAsync(twitterAccount);

            mappingProviderMock
                .Setup(x => x.MapTo<TwitterAccountDto>(twitterAccount))
                .Returns(expectedResult);

            var twitterAccountService = new TwitterAccountService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                twitterAccountRepositoryMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await twitterAccountService.GetTwitterAccountById(userId));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenMappingProviderReturnsNull()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterAccountRepositoryMock = new Mock<ITwitterAccountRepository>();

            string userId = null;
            var twitterAccount = new TwitterAccount() { Name = "Marto Stamatov" };
            TwitterAccountDto expectedResult = null;

            twitterAccountRepositoryMock
                .Setup(x => x.Get(userId))
                .ReturnsAsync(twitterAccount);

            mappingProviderMock
                .Setup(x => x.MapTo<TwitterAccountDto>(twitterAccount))
                .Returns(expectedResult);

            var twitterAccountService = new TwitterAccountService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                twitterAccountRepositoryMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await twitterAccountService.GetTwitterAccountById(userId));
        }
    }
}
