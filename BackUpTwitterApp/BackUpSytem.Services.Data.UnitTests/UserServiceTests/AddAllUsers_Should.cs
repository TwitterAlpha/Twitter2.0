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
using System.Linq;
using System.Threading.Tasks;

namespace BackUpSytem.Services.Data.UnitTests.UserServiceTests
{
    [TestClass]
    public class AddAllUsers_Should
    {
        [TestMethod]
        public async Task ReturnCollectionOfUserDtoObject_WhenNoExceptionsAreThrown()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterServiceMock = new Mock<ITwitterService>();
            var userManagerMock = MockUserManager<User>();

            var user = new User() { Name = "Marto Stamatov", Id = "30" };
            var users = new List<User>()
            {
                user
            };

            var userDto = new UserDto() { Name = "Marto Stamatov", Id = "30" };
            var usersDto = new List<UserDto>()
            {
               userDto
            };

            var adminRoleId = "1905";
            var roles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>() { RoleId = "1905", UserId = "30" },
                new IdentityUserRole<string>() { RoleId = "333", UserId = "222" }
            };
            var expectedResult = new UserDto() { Name = "Marto Stamatov", Id = "30" };

            userRepositoryMock
                .Setup(x => x.GetAll())
                .ReturnsAsync(users);

            mappingProviderMock
                .Setup(x => x.ProjectTo<User, UserDto>(users))
                .Returns(usersDto);

            userRepositoryMock
                .Setup(x => x.GetAdminRoleId())
                .ReturnsAsync(adminRoleId);

            userRepositoryMock
                .Setup(x => x.GetAllRoles())
                .ReturnsAsync(roles);

            var userService = new UserService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                twitterServiceMock.Object,
                userManagerMock.Object);

            //Act
            var actualResult = await userService.GetAllUsers();

            //Assert
            Assert.IsNotNull(actualResult);
            Assert.IsInstanceOfType(actualResult, typeof(IEnumerable<UserDto>));
        }

        [TestMethod]
        public async Task ReturnCollectionOfUserDtoObjectWithAdminUser_WhenAdminUserExists()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterServiceMock = new Mock<ITwitterService>();
            var userManagerMock = MockUserManager<User>();

            var user = new User() { Name = "Marto Stamatov", Id = "30" };
            var users = new List<User>()
            {
                user
            };

            var userDto = new UserDto() { Name = "Marto Stamatov", Id = "30" };
            var usersDto = new List<UserDto>()
            {
               userDto
            };

            var adminRoleId = "1905";
            var roles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>() { RoleId = "1905", UserId = "30" },
                new IdentityUserRole<string>() { RoleId = "333", UserId = "222" }
            };
            var expectedResult = new UserDto() { Name = "Marto Stamatov", Id = "30" };

            userRepositoryMock
                .Setup(x => x.GetAll())
                .ReturnsAsync(users);

            mappingProviderMock
                .Setup(x => x.ProjectTo<User, UserDto>(users))
                .Returns(usersDto);

            userRepositoryMock
                .Setup(x => x.GetAdminRoleId())
                .ReturnsAsync(adminRoleId);

            userRepositoryMock
                .Setup(x => x.GetAllRoles())
                .ReturnsAsync(roles);

            var userService = new UserService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                twitterServiceMock.Object,
                userManagerMock.Object);

            //Act
            var actualResult = await userService.GetAllUsers();

            //Assert
            Assert.IsTrue(actualResult.FirstOrDefault().IsAdmin);
        }

        [TestMethod]
        public async Task ReturnCollectionOfUserDtoObjectWithNoAdminUser_WhenThereIsNoAdmin()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterServiceMock = new Mock<ITwitterService>();
            var userManagerMock = MockUserManager<User>();

            var user = new User() { Name = "Marto Stamatov", Id = "30" };
            var users = new List<User>()
            {
                user
            };

            var userDto = new UserDto() { Name = "Marto Stamatov", Id = "30" };
            var usersDto = new List<UserDto>()
            {
               userDto
            };

            var adminRoleId = "1905";
            var roles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>() { RoleId = "no admin", UserId = "no admin"},
                new IdentityUserRole<string>() { RoleId = "333", UserId = "222" }
            };
            var expectedResult = new UserDto() { Name = "Marto Stamatov", Id = "30" };

            userRepositoryMock
                .Setup(x => x.GetAll())
                .ReturnsAsync(users);

            mappingProviderMock
                .Setup(x => x.ProjectTo<User, UserDto>(users))
                .Returns(usersDto);

            userRepositoryMock
                .Setup(x => x.GetAdminRoleId())
                .ReturnsAsync(adminRoleId);

            userRepositoryMock
                .Setup(x => x.GetAllRoles())
                .ReturnsAsync(roles);

            var userService = new UserService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                twitterServiceMock.Object,
                userManagerMock.Object);

            //Act
            var actualResult = await userService.GetAllUsers();

            //Assert
            Assert.IsFalse(actualResult.FirstOrDefault().IsAdmin);
        }

        [TestMethod]
        public void ThrowAgumentNullException_WhenUserRepositoryGetAllMethodReturnsNull()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterServiceMock = new Mock<ITwitterService>();
            var userManagerMock = MockUserManager<User>();

            var user = new User() { Name = "Marto Stamatov", Id = "30" };
            var users = new List<User>()
            {
                user
            };

            var userDto = new UserDto() { Name = "Marto Stamatov", Id = "30" };
            var usersDto = new List<UserDto>()
            {
               userDto
            };

            var adminRoleId = "1905";
            var roles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>() { RoleId = "no admin", UserId = "no admin"},
                new IdentityUserRole<string>() { RoleId = "333", UserId = "222" }
            };
            var expectedResult = new UserDto() { Name = "Marto Stamatov", Id = "30" };

            userRepositoryMock
                .Setup(x => x.GetAll())
                .ReturnsAsync((IEnumerable<User>)null);

            mappingProviderMock
                .Setup(x => x.ProjectTo<User, UserDto>(users))
                .Returns(usersDto);

            userRepositoryMock
                .Setup(x => x.GetAdminRoleId())
                .ReturnsAsync(adminRoleId);

            userRepositoryMock
                .Setup(x => x.GetAllRoles())
                .ReturnsAsync(roles);

            var userService = new UserService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                twitterServiceMock.Object,
                userManagerMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await userService.GetAllUsers());
        }

        [TestMethod]
        public void ThrowAgumentNullException_WhenMappingProviderProjectToMethodReturnsNull()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterServiceMock = new Mock<ITwitterService>();
            var userManagerMock = MockUserManager<User>();

            var user = new User() { Name = "Marto Stamatov", Id = "30" };
            var users = new List<User>()
            {
                user
            };

            var userDto = new UserDto() { Name = "Marto Stamatov", Id = "30" };
            var usersDto = new List<UserDto>()
            {
               userDto
            };

            var adminRoleId = "1905";
            var roles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>() { RoleId = "no admin", UserId = "no admin"},
                new IdentityUserRole<string>() { RoleId = "333", UserId = "222" }
            };
            var expectedResult = new UserDto() { Name = "Marto Stamatov", Id = "30" };

            userRepositoryMock
                .Setup(x => x.GetAll())
                .ReturnsAsync((IEnumerable<User>)null);

            mappingProviderMock
                .Setup(x => x.ProjectTo<User, UserDto>(users))
                .Returns((IEnumerable<UserDto>)null);

            userRepositoryMock
                .Setup(x => x.GetAdminRoleId())
                .ReturnsAsync(adminRoleId);

            userRepositoryMock
                .Setup(x => x.GetAllRoles())
                .ReturnsAsync(roles);

            var userService = new UserService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                twitterServiceMock.Object,
                userManagerMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await userService.GetAllUsers());
        }

        [TestMethod]
        public void ThrowAgumentNullException_WhenUserRepositoryGetAdminRoleIdMethodReturnsNull()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterServiceMock = new Mock<ITwitterService>();
            var userManagerMock = MockUserManager<User>();

            var user = new User() { Name = "Marto Stamatov", Id = "30" };
            var users = new List<User>()
            {
                user
            };

            var userDto = new UserDto() { Name = "Marto Stamatov", Id = "30" };
            var usersDto = new List<UserDto>()
            {
               userDto
            };

            var adminRoleId = "1905";
            var roles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>() { RoleId = "no admin", UserId = "no admin"},
                new IdentityUserRole<string>() { RoleId = "333", UserId = "222" }
            };
            var expectedResult = new UserDto() { Name = "Marto Stamatov", Id = "30" };

            userRepositoryMock
                .Setup(x => x.GetAll())
                .ReturnsAsync((IEnumerable<User>)null);

            mappingProviderMock
                .Setup(x => x.ProjectTo<User, UserDto>(users))
                .Returns((IEnumerable<UserDto>)null);

            userRepositoryMock
                .Setup(x => x.GetAdminRoleId())
                .ReturnsAsync((string)null);

            userRepositoryMock
                .Setup(x => x.GetAllRoles())
                .ReturnsAsync(roles);

            var userService = new UserService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                twitterServiceMock.Object,
                userManagerMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await userService.GetAllUsers());
        }

        [TestMethod]
        public void ThrowAgumentException_WhenUserRepositoryGetAdminRoleIdMethodReturnsEmptyString()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterServiceMock = new Mock<ITwitterService>();
            var userManagerMock = MockUserManager<User>();

            var user = new User() { Name = "Marto Stamatov", Id = "30" };
            var users = new List<User>()
            {
                user
            };

            var userDto = new UserDto() { Name = "Marto Stamatov", Id = "30" };
            var usersDto = new List<UserDto>()
            {
               userDto
            };

            var adminRoleId = "1905";
            var roles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>() { RoleId = "no admin", UserId = "no admin"},
                new IdentityUserRole<string>() { RoleId = "333", UserId = "222" }
            };
            var expectedResult = new UserDto() { Name = "Marto Stamatov", Id = "30" };

            userRepositoryMock
                .Setup(x => x.GetAll())
                .ReturnsAsync((IEnumerable<User>)null);

            mappingProviderMock
                .Setup(x => x.ProjectTo<User, UserDto>(users))
                .Returns((IEnumerable<UserDto>)null);

            userRepositoryMock
                .Setup(x => x.GetAdminRoleId())
                .ReturnsAsync(string.Empty);

            userRepositoryMock
                .Setup(x => x.GetAllRoles())
                .ReturnsAsync(roles);

            var userService = new UserService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                twitterServiceMock.Object,
                userManagerMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentException>(async () => await userService.GetAllUsers());
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
