using BackUpSystem.Data.Repositories.Contracts;
using BackUpSystem.Services.Data;
using BackUpSystem.Utilities.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;

namespace BackUpSytem.Services.Data.UnitTests.TwitterAccountServiceTests
{
    [TestClass]
    public class DeleteTwitterAccountFromUser_Should
    {
        [TestMethod]
        public async Task ReturnTrue_WhenInvokedWithValidParameters()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterAccountRepositoryMock = new Mock<ITwitterAccountRepository>();

            var userId = "30";
            var twitterAccountId = "1905";

            twitterAccountRepositoryMock
                .Setup(x => x.UserTwitterAccountIsDeleted(userId, twitterAccountId))
                .ReturnsAsync(true);

            var twitterAccountService = new TwitterAccountService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                twitterAccountRepositoryMock.Object);

            //Act
            var userIsDeleted = await twitterAccountService.DeleteTwitterAccountFromUser(userId, twitterAccountId);

            //Assert
            Assert.IsTrue(userIsDeleted);
        }

        [TestMethod]
        public async Task ReturnFalse_WhenTwitterAccountRepositoryDeleteMetodReturnsFalse()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterAccountRepositoryMock = new Mock<ITwitterAccountRepository>();

            var userId = "30";
            var twitterAccountId = "1905";

            twitterAccountRepositoryMock
                .Setup(x => x.UserTwitterAccountIsDeleted(userId, twitterAccountId))
                .ReturnsAsync(false);

            var twitterAccountService = new TwitterAccountService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                twitterAccountRepositoryMock.Object);

            //Act
            var userIsDeleted = await twitterAccountService.DeleteTwitterAccountFromUser(userId, twitterAccountId);

            //Assert
            Assert.IsFalse(userIsDeleted);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullUserIdParameter()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterAccountRepositoryMock = new Mock<ITwitterAccountRepository>();

            var userId = "30";
            var twitterAccountId = "1905";

            twitterAccountRepositoryMock
                .Setup(x => x.UserTwitterAccountIsDeleted(userId, twitterAccountId))
                .ReturnsAsync(true);

            var twitterAccountService = new TwitterAccountService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                twitterAccountRepositoryMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => twitterAccountService.DeleteTwitterAccountFromUser(null, twitterAccountId));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithInvalidEmptyUserIdParameter()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterAccountRepositoryMock = new Mock<ITwitterAccountRepository>();

            var userId = "30";
            var twitterAccountId = "1905";

            twitterAccountRepositoryMock
                .Setup(x => x.UserTwitterAccountIsDeleted(userId, twitterAccountId))
                .ReturnsAsync(true);

            var twitterAccountService = new TwitterAccountService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                twitterAccountRepositoryMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentException>(() => twitterAccountService.DeleteTwitterAccountFromUser(string.Empty, twitterAccountId));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullTwitterAccountIdParameter()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterAccountRepositoryMock = new Mock<ITwitterAccountRepository>();

            var userId = "30";
            var twitterAccountId = "1905";

            twitterAccountRepositoryMock
                .Setup(x => x.UserTwitterAccountIsDeleted(userId, twitterAccountId))
                .ReturnsAsync(true);

            var twitterAccountService = new TwitterAccountService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                twitterAccountRepositoryMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => twitterAccountService.DeleteTwitterAccountFromUser(userId, null));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithInvalidEmptyTwitterAccountIdParameter()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterAccountRepositoryMock = new Mock<ITwitterAccountRepository>();

            var userId = "30";
            var twitterAccountId = "1905";

            twitterAccountRepositoryMock
                .Setup(x => x.UserTwitterAccountIsDeleted(userId, twitterAccountId))
                .ReturnsAsync(true);

            var twitterAccountService = new TwitterAccountService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                twitterAccountRepositoryMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentException>(() => twitterAccountService.DeleteTwitterAccountFromUser(userId, string.Empty));
        }
    }
}
