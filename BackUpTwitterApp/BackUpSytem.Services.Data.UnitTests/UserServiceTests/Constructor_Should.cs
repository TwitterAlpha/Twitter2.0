using BackUpSystem.Data.Models;
using BackUpSystem.Data.Repositories.Contracts;
using BackUpSystem.Services.Data;
using BackUpSystem.Services.Data.Contracts;
using BackUpSystem.Utilities.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace BackUpSytem.Services.Data.UnitTests.UserServiceTests
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
            var twitterServiceMock = new Mock<ITwitterService>();
            var userManagerMock = MockUserManager<User>();

            //Act
            var userService = new UserService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                twitterServiceMock.Object,
                userManagerMock.Object);

            //Assert
            Assert.IsNotNull(userService);
            Assert.IsInstanceOfType(userService, typeof(IUserService));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullUnitOfWorkParameter()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterServiceMock = new Mock<ITwitterService>();
            var userManagerMock = MockUserManager<User>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new UserService(
              null,
              mappingProviderMock.Object,
              userRepositoryMock.Object,
              twitterServiceMock.Object,
              userManagerMock.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullMappingProviderParameter()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterServiceMock = new Mock<ITwitterService>();
            var userManagerMock = MockUserManager<User>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new UserService(
              unitOfWorkMock.Object,
              null,
              userRepositoryMock.Object,
              twitterServiceMock.Object,
              userManagerMock.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullUserRepositoryParameter()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterServiceMock = new Mock<ITwitterService>();
            var userManagerMock = MockUserManager<User>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new UserService(
              unitOfWorkMock.Object,
              mappingProviderMock.Object,
              null,
              twitterServiceMock.Object,
              userManagerMock.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullTwitterServiceParameter()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterServiceMock = new Mock<ITwitterService>();
            var userManagerMock = MockUserManager<User>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new UserService(
              unitOfWorkMock.Object,
              mappingProviderMock.Object,
              userRepositoryMock.Object,
              null,
              userManagerMock.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullUserManagerParameter()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterServiceMock = new Mock<ITwitterService>();
            var userManagerMock = MockUserManager<User>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new UserService(
              unitOfWorkMock.Object,
              mappingProviderMock.Object,
              userRepositoryMock.Object,
              twitterServiceMock.Object,
              null));
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
