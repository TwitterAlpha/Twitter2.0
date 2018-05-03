using BackUpSystem.Data.Models;
using BackUpSystem.Data.Repositories.Contracts;
using BackUpSystem.DTO;
using BackUpSystem.Services.Data;
using BackUpSystem.Utilities.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;

namespace BackUpSytem.Services.Data.UnitTests.TwitterAccountServiceTests
{
    [TestClass]
    public class AddTwitterAccountToUser_Should
    {
        [TestMethod]
        public async Task ReturnTrue_WhenInvokedWithValidParameters()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterAccountRepositoryMock = new Mock<ITwitterAccountRepository>();

            string userId = "1905";
            var twitterAccountToAdd = new TwitterAccountApiDto() { Name = "Marto Stamatov", Id = "30", ImageUrl = "SomeUrl" };
            var twitterAccount = new TwitterAccount() { Name = "Marto Stamatov", Id = "30", ImageUrl = "SomeUrl" };
            var user = new User();

            twitterAccountRepositoryMock
             .Setup(x => x.Get(twitterAccountToAdd.Id))
             .ReturnsAsync(twitterAccount);

            mappingProviderMock
                .Setup(x => x.MapTo<TwitterAccount>(twitterAccountToAdd))
                .Returns(twitterAccount);

            userRepositoryMock
                .Setup(x => x.Get(userId))
                .ReturnsAsync(user);

            userRepositoryMock
                .Setup(x => x.TwitterAccountAddedToUser(user, twitterAccount))
                .ReturnsAsync(true);

            var twitterAccountService = new TwitterAccountService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                twitterAccountRepositoryMock.Object);

            //Act
            var actualResult = await twitterAccountService.AddTwitterAccountToUser(twitterAccountToAdd, userId);

            //Assert
            Assert.IsTrue(actualResult);
        }

        [TestMethod]
        public async Task ReturnFalse_TwitterAccountAddMethodReturnsFalse()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterAccountRepositoryMock = new Mock<ITwitterAccountRepository>();

            string userId = "1905";
            var twitterAccountToAdd = new TwitterAccountApiDto() { Name = "Marto Stamatov", Id = "30", ImageUrl = "SomeUrl" };
            var twitterAccount = new TwitterAccount() { Name = "Marto Stamatov", Id = "30", ImageUrl = "SomeUrl" };
            var user = new User();

            twitterAccountRepositoryMock
             .Setup(x => x.Get(twitterAccountToAdd.Id))
             .ReturnsAsync(twitterAccount);

            mappingProviderMock
                .Setup(x => x.MapTo<TwitterAccount>(twitterAccountToAdd))
                .Returns(twitterAccount);

            userRepositoryMock
                .Setup(x => x.Get(userId))
                .ReturnsAsync(user);

            userRepositoryMock
                .Setup(x => x.TwitterAccountAddedToUser(user, twitterAccount))
                .ReturnsAsync(false);

            var twitterAccountService = new TwitterAccountService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                twitterAccountRepositoryMock.Object);

            //Act
            var actualResult = await twitterAccountService.AddTwitterAccountToUser(twitterAccountToAdd, userId);

            //Assert
            Assert.IsFalse(actualResult);
        }

        [TestMethod]
        public async Task CallSaveChangesTwice_WhenTwitterAccountDoesNotAlreadyExistInDatabase()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterAccountRepositoryMock = new Mock<ITwitterAccountRepository>();

            string userId = "1905";
            var twitterAccountToAdd = new TwitterAccountApiDto() { Name = "Marto Stamatov", Id = "30", ImageUrl = "SomeUrl" };
            var twitterAccount = new TwitterAccount() { Name = "Marto Stamatov", Id = "30", ImageUrl = "SomeUrl" };
            var user = new User() { Name = "Stamat" };

            twitterAccountRepositoryMock
                .Setup(x => x.Get(twitterAccountToAdd.Id))
                .ReturnsAsync((TwitterAccount)null);

            mappingProviderMock
                .Setup(x => x.MapTo<TwitterAccount>(twitterAccountToAdd))
                .Returns(twitterAccount);

            userRepositoryMock
                .Setup(x => x.Get(userId))
                .ReturnsAsync(user);

            userRepositoryMock
                .Setup(x => x.TwitterAccountAddedToUser(user, twitterAccount))
                .ReturnsAsync(true);

            var twitterAccountService = new TwitterAccountService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                twitterAccountRepositoryMock.Object);

            //Act
            var actualResult = await twitterAccountService.AddTwitterAccountToUser(twitterAccountToAdd, userId);

            //Assert
            unitOfWorkMock.Verify(x => x.SaveChangesAsync(), Times.Exactly(2));
        }

        [TestMethod]
        public async Task CallSaveChangesOnce_WhenTwitterAccountAlreadyExistsInDatabase()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterAccountRepositoryMock = new Mock<ITwitterAccountRepository>();

            string userId = "1905";
            var twitterAccountToAdd = new TwitterAccountApiDto() { Name = "Marto Stamatov", Id = "30", ImageUrl = "SomeUrl" };
            var twitterAccount = new TwitterAccount() { Name = "Marto Stamatov", Id = "30", ImageUrl = "SomeUrl" };
            var user = new User() { Name = "Stamat" };

            twitterAccountRepositoryMock
                .Setup(x => x.Get(twitterAccountToAdd.Id))
                .ReturnsAsync(twitterAccount);

            mappingProviderMock
                .Setup(x => x.MapTo<TwitterAccount>(twitterAccountToAdd))
                .Returns(twitterAccount);

            userRepositoryMock
                .Setup(x => x.Get(userId))
                .ReturnsAsync(user);

            userRepositoryMock
                .Setup(x => x.TwitterAccountAddedToUser(user, twitterAccount))
                .ReturnsAsync(true);

            var twitterAccountService = new TwitterAccountService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                twitterAccountRepositoryMock.Object);

            //Act
            var actualResult = await twitterAccountService.AddTwitterAccountToUser(twitterAccountToAdd, userId);

            //Assert
            unitOfWorkMock.Verify(x => x.SaveChangesAsync(), Times.Once);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInokedWithInvalidNullTwitterAccountParameter()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterAccountRepositoryMock = new Mock<ITwitterAccountRepository>();

            string userId = "1905";
            var twitterAccountToAdd = new TwitterAccountApiDto() { Name = "Marto Stamatov", Id = "30", ImageUrl = "SomeUrl" };
            var twitterAccount = new TwitterAccount() { Name = "Marto Stamatov", Id = "30", ImageUrl = "SomeUrl" };
            var user = new User();

            twitterAccountRepositoryMock
             .Setup(x => x.Get(twitterAccountToAdd.Id))
             .ReturnsAsync(twitterAccount);

            mappingProviderMock
                .Setup(x => x.MapTo<TwitterAccount>(twitterAccountToAdd))
                .Returns(twitterAccount);

            userRepositoryMock
                .Setup(x => x.Get(userId))
                .ReturnsAsync(user);

            userRepositoryMock
                .Setup(x => x.TwitterAccountAddedToUser(user, twitterAccount))
                .ReturnsAsync(true);

            var twitterAccountService = new TwitterAccountService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                twitterAccountRepositoryMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(async () =>
            await twitterAccountService.AddTwitterAccountToUser(null, userId));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInokedWithInvalidNullUserIdParameter()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterAccountRepositoryMock = new Mock<ITwitterAccountRepository>();

            string userId = "1905";
            var twitterAccountToAdd = new TwitterAccountApiDto() { Name = "Marto Stamatov", Id = "30", ImageUrl = "SomeUrl" };
            var twitterAccount = new TwitterAccount() { Name = "Marto Stamatov", Id = "30", ImageUrl = "SomeUrl" };
            var user = new User();

            twitterAccountRepositoryMock
             .Setup(x => x.Get(twitterAccountToAdd.Id))
             .ReturnsAsync(twitterAccount);

            mappingProviderMock
                .Setup(x => x.MapTo<TwitterAccount>(twitterAccountToAdd))
                .Returns(twitterAccount);

            userRepositoryMock
                .Setup(x => x.Get(userId))
                .ReturnsAsync(user);

            userRepositoryMock
                .Setup(x => x.TwitterAccountAddedToUser(user, twitterAccount))
                .ReturnsAsync(true);

            var twitterAccountService = new TwitterAccountService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                twitterAccountRepositoryMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(async () =>
            await twitterAccountService.AddTwitterAccountToUser(twitterAccountToAdd, null));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInokedWithInvalidEmptyUserIdParameter()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterAccountRepositoryMock = new Mock<ITwitterAccountRepository>();

            string userId = "1905";
            var twitterAccountToAdd = new TwitterAccountApiDto() { Name = "Marto Stamatov", Id = "30", ImageUrl = "SomeUrl" };
            var twitterAccount = new TwitterAccount() { Name = "Marto Stamatov", Id = "30", ImageUrl = "SomeUrl" };
            var user = new User();

            twitterAccountRepositoryMock
             .Setup(x => x.Get(twitterAccountToAdd.Id))
             .ReturnsAsync(twitterAccount);

            mappingProviderMock
                .Setup(x => x.MapTo<TwitterAccount>(twitterAccountToAdd))
                .Returns(twitterAccount);

            userRepositoryMock
                .Setup(x => x.Get(userId))
                .ReturnsAsync(user);

            userRepositoryMock
                .Setup(x => x.TwitterAccountAddedToUser(user, twitterAccount))
                .ReturnsAsync(true);

            var twitterAccountService = new TwitterAccountService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                twitterAccountRepositoryMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentException>(async () =>
            await twitterAccountService.AddTwitterAccountToUser(twitterAccountToAdd, string.Empty));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenMappingProviderMapMethodReturnsNull()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterAccountRepositoryMock = new Mock<ITwitterAccountRepository>();

            string userId = "1905";
            var twitterAccountToAdd = new TwitterAccountApiDto() { Name = "Marto Stamatov", Id = "30", ImageUrl = "SomeUrl" };
            var twitterAccount = new TwitterAccount() { Name = "Marto Stamatov", Id = "30", ImageUrl = "SomeUrl" };
            var user = new User();

            twitterAccountRepositoryMock
             .Setup(x => x.Get(twitterAccountToAdd.Id))
             .ReturnsAsync(twitterAccount);

            mappingProviderMock
                .Setup(x => x.MapTo<TwitterAccount>(twitterAccountToAdd))
                .Returns((TwitterAccount)null);

            userRepositoryMock
                .Setup(x => x.Get(userId))
                .ReturnsAsync(user);

            userRepositoryMock
                .Setup(x => x.TwitterAccountAddedToUser(user, twitterAccount))
                .ReturnsAsync(true);

            var twitterAccountService = new TwitterAccountService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                twitterAccountRepositoryMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(async () =>
            await twitterAccountService.AddTwitterAccountToUser(twitterAccountToAdd, userId));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenUserRepositoryGetMethodReturnsNull()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterAccountRepositoryMock = new Mock<ITwitterAccountRepository>();

            string userId = "1905";
            var twitterAccountToAdd = new TwitterAccountApiDto() { Name = "Marto Stamatov", Id = "30", ImageUrl = "SomeUrl" };
            var twitterAccount = new TwitterAccount() { Name = "Marto Stamatov", Id = "30", ImageUrl = "SomeUrl" };
            var user = new User();

            twitterAccountRepositoryMock
             .Setup(x => x.Get(twitterAccountToAdd.Id))
             .ReturnsAsync(twitterAccount);

            mappingProviderMock
                .Setup(x => x.MapTo<TwitterAccount>(twitterAccountToAdd))
                .Returns(twitterAccount);

            userRepositoryMock
                .Setup(x => x.Get(userId))
                .ReturnsAsync((User)null);

            userRepositoryMock
                .Setup(x => x.TwitterAccountAddedToUser(user, twitterAccount))
                .ReturnsAsync(true);

            var twitterAccountService = new TwitterAccountService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                twitterAccountRepositoryMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(async () =>
            await twitterAccountService.AddTwitterAccountToUser(twitterAccountToAdd, userId));
        }
    }
}
