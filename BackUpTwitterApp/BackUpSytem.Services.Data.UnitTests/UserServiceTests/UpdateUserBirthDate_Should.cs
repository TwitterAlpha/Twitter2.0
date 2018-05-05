using BackUpSystem.Data.Models;
using BackUpSystem.Data.Repositories.Contracts;
using BackUpSystem.Services.Data;
using BackUpSystem.Services.Data.Contracts;
using BackUpSystem.Utilities.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;

namespace BackUpSytem.Services.Data.UnitTests.UserServiceTests
{
    [TestClass]
    public class UpdateUserBirthDate_Should
    {
        [TestMethod]
        public async Task ReturnTrue_WhenNameSuccessfullyUpdated()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterServiceMock = new Mock<ITwitterService>();
            var userManagerMock = MockUserManager<User>();

            var userId = "30";
            var birthDate = DateTime.Parse("1878-03-01");

            userRepositoryMock
                .Setup(x => x.UpdateBirthDate(userId, birthDate))
                .ReturnsAsync(true);

            var userService = new UserService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                twitterServiceMock.Object,
                userManagerMock.Object);

            //Act   
            var result = await userService.UpdateBirthDate(userId, birthDate);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task ReturnFalse_WhenUserRepositoryUpdateUserNameMethodReturnsFalse()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterServiceMock = new Mock<ITwitterService>();
            var userManagerMock = MockUserManager<User>();

            var userId = "30";
            var birthDate = DateTime.Parse("1878-03-01");

            userRepositoryMock
                .Setup(x => x.UpdateBirthDate(userId, birthDate))
                .ReturnsAsync(false);

            var userService = new UserService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                twitterServiceMock.Object,
                userManagerMock.Object);

            //Act   
            var result = await userService.UpdateBirthDate(userId, birthDate);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public async Task CallSaveChangesOnce_WhenInvokedWithValidParameters()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterServiceMock = new Mock<ITwitterService>();
            var userManagerMock = MockUserManager<User>();

            var userId = "30";
            var birthDate = DateTime.Parse("1878-03-01");

            userRepositoryMock
                .Setup(x => x.UpdateBirthDate(userId, birthDate))
                .ReturnsAsync(true);

            var userService = new UserService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                twitterServiceMock.Object,
                userManagerMock.Object);

            //Act   
            var result = await userService.UpdateBirthDate(userId, birthDate);

            //Assert
            unitOfWorkMock.Verify(x => x.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public async Task NotCallSaveChanges_WhenInvokedWithValidParameters()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterServiceMock = new Mock<ITwitterService>();
            var userManagerMock = MockUserManager<User>();

            var userId = "30";
            var birthDate = DateTime.Parse("1878-03-01");

            userRepositoryMock
                .Setup(x => x.UpdateBirthDate(userId, birthDate))
                .ReturnsAsync(false);

            var userService = new UserService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                twitterServiceMock.Object,
                userManagerMock.Object);

            //Act   
            var result = await userService.UpdateBirthDate(userId, birthDate);

            //Assert
            unitOfWorkMock.Verify(x => x.SaveChanges(), Times.Exactly(0));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullUserIdParameter()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterServiceMock = new Mock<ITwitterService>();
            var userManagerMock = MockUserManager<User>();

            var userId = "30";
            var birthDate = DateTime.Parse("1878-03-01");

            userRepositoryMock
                .Setup(x => x.UpdateBirthDate(userId, birthDate))
                .ReturnsAsync(true);

            var userService = new UserService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                twitterServiceMock.Object,
                userManagerMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await userService.UpdateBirthDate(null, birthDate));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithInvalidEmptyUserIdParameter()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterServiceMock = new Mock<ITwitterService>();
            var userManagerMock = MockUserManager<User>();

            var userId = "30";
            var birthDate = DateTime.Parse("1878-03-01");

            userRepositoryMock
                .Setup(x => x.UpdateBirthDate(userId, birthDate))
                .ReturnsAsync(true);

            var userService = new UserService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                twitterServiceMock.Object,
                userManagerMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentException>(async () => await userService.UpdateBirthDate(string.Empty, birthDate));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullUserBirthDateParameter()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterServiceMock = new Mock<ITwitterService>();
            var userManagerMock = MockUserManager<User>();

            var userId = "30";
            var birthDate = DateTime.Parse("1878-03-01");

            userRepositoryMock
                .Setup(x => x.UpdateBirthDate(userId, birthDate))
                .ReturnsAsync(true);

            var userService = new UserService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                twitterServiceMock.Object,
                userManagerMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await userService.UpdateBirthDate(userId, null));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithInvalidEmptyBirthDateParameter()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterServiceMock = new Mock<ITwitterService>();
            var userManagerMock = MockUserManager<User>();

            var userId = "30";
            var userName = "Marto Stamatov";

            userRepositoryMock
                .Setup(x => x.UpdateName(userId, userName))
                .ReturnsAsync(true);

            var userService = new UserService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                twitterServiceMock.Object,
                userManagerMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentException>(async () => await userService.UpdateName(userId, string.Empty));
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
