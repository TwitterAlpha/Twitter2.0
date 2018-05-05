using BackUpSystem.Data.Models;
using BackUpSystem.Data.Repositories.Contracts;
using BackUpSystem.DTO;
using BackUpSystem.Services.Data;
using BackUpSystem.Services.Data.Contracts;
using BackUpSystem.Utilities.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BackUpSytem.Services.Data.UnitTests.UserServiceTests
{
    [TestClass]
    public class GetUserByScreenName_Should
    {
        [TestMethod]
        public async Task ReturnUserDtoObject_WhenInvokedWithValidParameter()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterServiceMock = new Mock<ITwitterService>();
            var userManagerMock = MockUserManager<User>();

            var username = "strongman";
            var user = new User() { Name = "Marto Stamatov", Id = "30", UserName = username };
            var expectedResult = new UserDto() { Name = "Marto Stamatov", Id = "30", UserName = username };

            userRepositoryMock
                .Setup(x => x.GetUserByUsername(username))
                .ReturnsAsync(user);

            mappingProviderMock
                .Setup(x => x.MapTo<UserDto>(user))
                .Returns(expectedResult);

            var userService = new UserService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                twitterServiceMock.Object,
                userManagerMock.Object);

            //Act
            var actualResult = await userService.GetUserByUsername(username);

            //Assert
            Assert.IsNotNull(actualResult);
            Assert.AreSame(actualResult, expectedResult);
        }

        [TestMethod]
        public void ThrowsArgumentNullException_WhenInvokedWithInvalidNullUsernameParameter()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterServiceMock = new Mock<ITwitterService>();
            var userManagerMock = MockUserManager<User>();

            var username = "strongman";
            var user = new User() { Name = "Marto Stamatov", Id = "30", UserName = username };
            var expectedResult = new UserDto() { Name = "Marto Stamatov", Id = "30", UserName = username };

            userRepositoryMock
                .Setup(x => x.GetUserByUsername(username))
                .ReturnsAsync(user);

            mappingProviderMock
                .Setup(x => x.MapTo<UserDto>(user))
                .Returns(expectedResult);

            var userService = new UserService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                twitterServiceMock.Object,
                userManagerMock.Object);

            //Act
            Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await userService.GetUserByUsername(null));
        }


        [TestMethod]
        public void ThrowsArgumentException_WhenInvokedWithInvalidEmptyUsernameParameter()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterServiceMock = new Mock<ITwitterService>();
            var userManagerMock = MockUserManager<User>();

            var username = "strongman";
            var user = new User() { Name = "Marto Stamatov", Id = "30", UserName = username };
            var expectedResult = new UserDto() { Name = "Marto Stamatov", Id = "30", UserName = username };

            userRepositoryMock
                .Setup(x => x.GetUserByUsername(username))
                .ReturnsAsync(user);

            mappingProviderMock
                .Setup(x => x.MapTo<UserDto>(user))
                .Returns(expectedResult);

            var userService = new UserService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                twitterServiceMock.Object,
                userManagerMock.Object);

            //Act
            Assert.ThrowsExceptionAsync<ArgumentException>(async () => await userService.GetUserByUsername(string.Empty));
        }

        [TestMethod]
        public void ThrowsArgumentNullException_WhenUserRepositoryGetUserByUsernameMethodReturnsNull()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterServiceMock = new Mock<ITwitterService>();
            var userManagerMock = MockUserManager<User>();

            var username = "strongman";
            var user = new User() { Name = "Marto Stamatov", Id = "30", UserName = username };
            var expectedResult = new UserDto() { Name = "Marto Stamatov", Id = "30", UserName = username };

            userRepositoryMock
                .Setup(x => x.GetUserByUsername(username))
                .ReturnsAsync((User)null);

            mappingProviderMock
                .Setup(x => x.MapTo<UserDto>(user))
                .Returns(expectedResult);

            var userService = new UserService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                twitterServiceMock.Object,
                userManagerMock.Object);

            //Act
            Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await userService.GetUserByUsername(username));
        }

        [TestMethod]
        public void ThrowsArgumentNullException_WhenMappingProviderMapToMethodReturnsNull()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterServiceMock = new Mock<ITwitterService>();
            var userManagerMock = MockUserManager<User>();

            var username = "strongman";
            var user = new User() { Name = "Marto Stamatov", Id = "30", UserName = username };
            var expectedResult = new UserDto() { Name = "Marto Stamatov", Id = "30", UserName = username };

            userRepositoryMock
                .Setup(x => x.GetUserByUsername(username))
                .ReturnsAsync(user);

            mappingProviderMock
                .Setup(x => x.MapTo<UserDto>(user))
                .Returns((UserDto)null);

            var userService = new UserService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                twitterServiceMock.Object,
                userManagerMock.Object);

            //Act
            Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await userService.GetUserByUsername(username));
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
