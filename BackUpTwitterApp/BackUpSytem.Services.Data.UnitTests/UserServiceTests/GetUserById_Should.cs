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
    public class GetUserById_Should
    {
        [TestMethod]
        public async Task ReturnUserDtoObject_WhenInvokedWithValidParameters()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterServiceMock = new Mock<ITwitterService>();
            var userManagerMock = MockUserManager<User>();

            var user = new User() { Name = "Marto Stamatov", Id = "30" };
            var adminRoleId = "1905";
            var roles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>() { RoleId = "1905", UserId = "30" },
                new IdentityUserRole<string>() { RoleId = "333", UserId = "222" }
            };
            var expectedResult = new UserDto() { Name = "Marto Stamatov", Id = "30" };

            userRepositoryMock
                .Setup(x => x.Get(user.Id))
                .ReturnsAsync(user);

            mappingProviderMock
                .Setup(x => x.MapTo<UserDto>(user))
                .Returns(expectedResult);

            userRepositoryMock
                .Setup(x => x.GetAdminRoleId())
                .ReturnsAsync(adminRoleId);

            userRepositoryMock
                .Setup(x => x.GetAllRoles())
                .ReturnsAsync(roles);

            expectedResult.IsAdmin = true;

            var userService = new UserService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                twitterServiceMock.Object,
                userManagerMock.Object);

            //Act
            var actualResult = await userService.GetUserById(user.Id);

            //Assert
            Assert.AreEqual(actualResult.Name, expectedResult.Name);
        }

        [TestMethod]
        public async Task ReturnAdminUser_WhenUserHasAdminRole()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterServiceMock = new Mock<ITwitterService>();
            var userManagerMock = MockUserManager<User>();

            var user = new User() { Name = "Marto Stamatov", Id = "30" };
            var adminRoleId = "1905";
            var roles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>() { RoleId = "1905", UserId = "30" },
                new IdentityUserRole<string>() { RoleId = "333", UserId = "222" }
            };
            var expectedResult = new UserDto() { Name = "Marto Stamatov", Id = "30" };

            userRepositoryMock
                .Setup(x => x.Get(user.Id))
                .ReturnsAsync(user);

            mappingProviderMock
                .Setup(x => x.MapTo<UserDto>(user))
                .Returns(expectedResult);

            userRepositoryMock
                .Setup(x => x.GetAdminRoleId())
                .ReturnsAsync(adminRoleId);

            userRepositoryMock
                .Setup(x => x.GetAllRoles())
                .ReturnsAsync(roles);

            expectedResult.IsAdmin = true;

            var userService = new UserService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                twitterServiceMock.Object,
                userManagerMock.Object);

            //Act
            var actualResult = await userService.GetUserById(user.Id);

            //Assert
            Assert.IsTrue(actualResult.IsAdmin);
        }

        [TestMethod]
        public async Task ReturnNotAdminUser_WhenUserIsNotAdmin()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterServiceMock = new Mock<ITwitterService>();
            var userManagerMock = MockUserManager<User>();

            var user = new User() { Name = "Marto Stamatov", Id = "30" };
            var adminRoleId = "1905";
            var roles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>() { RoleId = "195", UserId = "3" },
                new IdentityUserRole<string>() { RoleId = "333", UserId = "222" }
            };
            var expectedResult = new UserDto() { Name = "Marto Stamatov", Id = "30" };

            userRepositoryMock
                .Setup(x => x.Get(user.Id))
                .ReturnsAsync(user);

            mappingProviderMock
                .Setup(x => x.MapTo<UserDto>(user))
                .Returns(expectedResult);

            userRepositoryMock
                .Setup(x => x.GetAdminRoleId())
                .ReturnsAsync(adminRoleId);

            userRepositoryMock
                .Setup(x => x.GetAllRoles())
                .ReturnsAsync(roles);

            expectedResult.IsAdmin = false;

            var userService = new UserService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                twitterServiceMock.Object,
                userManagerMock.Object);

            //Act
            var actualResult = await userService.GetUserById(user.Id);

            //Assert
            Assert.IsFalse(actualResult.IsAdmin);
        }

        [TestMethod]
        public void ThrowArgumentNullException_InvokedWithNullIdParameter()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterServiceMock = new Mock<ITwitterService>();
            var userManagerMock = MockUserManager<User>();

            string userId = null;
            var user = new User() { Name = "Marto Stamatov", Id = userId };
            var adminRoleId = "1905";
            var roles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>() { RoleId = "195", UserId = "3" },
                new IdentityUserRole<string>() { RoleId = "333", UserId = "222" }
            };
            var expectedResult = new UserDto() { Name = "Marto Stamatov", Id = userId };

            userRepositoryMock
                .Setup(x => x.Get(userId))
                .ReturnsAsync(user);

            mappingProviderMock
                .Setup(x => x.MapTo<UserDto>(user))
                .Returns(expectedResult);

            userRepositoryMock
                .Setup(x => x.GetAdminRoleId())
                .ReturnsAsync(adminRoleId);

            userRepositoryMock
                .Setup(x => x.GetAllRoles())
                .ReturnsAsync(roles);

            expectedResult.IsAdmin = false;

            var userService = new UserService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                twitterServiceMock.Object,
                userManagerMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await userService.GetUserById(userId));
        }

        [TestMethod]
        public void ThrowArgumentNullException_InvokedWithEmptyIdParameter()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterServiceMock = new Mock<ITwitterService>();
            var userManagerMock = MockUserManager<User>();

            string userId = string.Empty;
            var user = new User() { Name = "Marto Stamatov", Id = userId };
            var adminRoleId = "1905";
            var roles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>() { RoleId = "195", UserId = "3" },
                new IdentityUserRole<string>() { RoleId = "333", UserId = "222" }
            };
            var expectedResult = new UserDto() { Name = "Marto Stamatov", Id = userId };

            userRepositoryMock
                .Setup(x => x.Get(userId))
                .ReturnsAsync(user);

            mappingProviderMock
                .Setup(x => x.MapTo<UserDto>(user))
                .Returns(expectedResult);

            userRepositoryMock
                .Setup(x => x.GetAdminRoleId())
                .ReturnsAsync(adminRoleId);

            userRepositoryMock
                .Setup(x => x.GetAllRoles())
                .ReturnsAsync(roles);

            expectedResult.IsAdmin = false;

            var userService = new UserService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                twitterServiceMock.Object,
                userManagerMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentException>(async () => await userService.GetUserById(userId));
        }

        [TestMethod]
        public void ThrowArgumentNullException_UserRepositoryGetUserByIdMethodReturnsNull()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterServiceMock = new Mock<ITwitterService>();
            var userManagerMock = MockUserManager<User>();

            string userId = "30";
            var user = new User() { Name = "Marto Stamatov", Id = userId };
            var adminRoleId = "1905";
            var roles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>() { RoleId = "195", UserId = "3" },
                new IdentityUserRole<string>() { RoleId = "333", UserId = "222" }
            };
            var expectedResult = new UserDto() { Name = "Marto Stamatov", Id = userId };

            userRepositoryMock
                .Setup(x => x.Get(userId))
                .ReturnsAsync((User)null);

            mappingProviderMock
                .Setup(x => x.MapTo<UserDto>(user))
                .Returns(expectedResult);

            userRepositoryMock
                .Setup(x => x.GetAdminRoleId())
                .ReturnsAsync(adminRoleId);

            userRepositoryMock
                .Setup(x => x.GetAllRoles())
                .ReturnsAsync(roles);

            expectedResult.IsAdmin = false;

            var userService = new UserService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                twitterServiceMock.Object,
                userManagerMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await userService.GetUserById(userId));
        }

        [TestMethod]
        public void ThrowArgumentNullException_MappingProviderMapToMethodReturnsNull()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterServiceMock = new Mock<ITwitterService>();
            var userManagerMock = MockUserManager<User>();

            string userId = "30";
            var user = new User() { Name = "Marto Stamatov", Id = userId };
            var adminRoleId = "1905";
            var roles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>() { RoleId = "195", UserId = "3" },
                new IdentityUserRole<string>() { RoleId = "333", UserId = "222" }
            };
            var expectedResult = new UserDto() { Name = "Marto Stamatov", Id = userId };

            userRepositoryMock
                .Setup(x => x.Get(userId))
                .ReturnsAsync(user);

            mappingProviderMock
                .Setup(x => x.MapTo<UserDto>(user))
                .Returns((UserDto)null);

            userRepositoryMock
                .Setup(x => x.GetAdminRoleId())
                .ReturnsAsync(adminRoleId);

            userRepositoryMock
                .Setup(x => x.GetAllRoles())
                .ReturnsAsync(roles);

            expectedResult.IsAdmin = false;

            var userService = new UserService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                twitterServiceMock.Object,
                userManagerMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await userService.GetUserById(userId));
        }

        [TestMethod]
        public void ThrowArgumentNullException_UserRepositoryGetAdminRoleIdMethodReturnsNull()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterServiceMock = new Mock<ITwitterService>();
            var userManagerMock = MockUserManager<User>();

            string userId = "30";
            var user = new User() { Name = "Marto Stamatov", Id = userId };
            var adminRoleId = "1905";
            var roles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>() { RoleId = "195", UserId = "3" },
                new IdentityUserRole<string>() { RoleId = "333", UserId = "222" }
            };
            var expectedResult = new UserDto() { Name = "Marto Stamatov", Id = userId };

            userRepositoryMock
                .Setup(x => x.Get(userId))
                .ReturnsAsync(user);

            mappingProviderMock
                .Setup(x => x.MapTo<UserDto>(user))
                .Returns(expectedResult);

            userRepositoryMock
                .Setup(x => x.GetAdminRoleId())
                .ReturnsAsync((string)null);

            userRepositoryMock
                .Setup(x => x.GetAllRoles())
                .ReturnsAsync(roles);

            expectedResult.IsAdmin = false;

            var userService = new UserService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                twitterServiceMock.Object,
                userManagerMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await userService.GetUserById(userId));
        }

        [TestMethod]
        public void ThrowArgumentException_UserRepositoryGetAdminRoleIdMethodReturnsEmptyString()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterServiceMock = new Mock<ITwitterService>();
            var userManagerMock = MockUserManager<User>();

            string userId = "30";
            var user = new User() { Name = "Marto Stamatov", Id = userId };
            var adminRoleId = "1905";
            var roles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>() { RoleId = "195", UserId = "3" },
                new IdentityUserRole<string>() { RoleId = "333", UserId = "222" }
            };
            var expectedResult = new UserDto() { Name = "Marto Stamatov", Id = userId };

            userRepositoryMock
                .Setup(x => x.Get(userId))
                .ReturnsAsync(user);

            mappingProviderMock
                .Setup(x => x.MapTo<UserDto>(user))
                .Returns(expectedResult);

            userRepositoryMock
                .Setup(x => x.GetAdminRoleId())
                .ReturnsAsync(string.Empty);

            userRepositoryMock
                .Setup(x => x.GetAllRoles())
                .ReturnsAsync(roles);

            expectedResult.IsAdmin = false;

            var userService = new UserService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                twitterServiceMock.Object,
                userManagerMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentException>(async () => await userService.GetUserById(userId));
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
