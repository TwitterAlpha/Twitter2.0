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
    public class GetAllFavoriteUsers_Should
    {
        [TestMethod]
        public async Task ReturnCollectionOfUserDtoObjects_WhenInvokedWithValidParameter()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterServiceMock = new Mock<ITwitterService>();
            var userManagerMock = MockUserManager<User>();

            var userId = "30";
            var user = new User() { Name = "Marto Stamatov", Id = "30"};
            var users = new List<User>()
            {
                user
            };

            var userDto = new UserDto() { Name = "Marto Stamatov", Id = "30"};
            var usersDto = new List<UserDto>()
            {
                userDto
            };

            userRepositoryMock
                .Setup(x => x.GetAllFavoriteTwitterAccounts(userId))
                .ReturnsAsync(users);

            mappingProviderMock
                .Setup(x => x.MapTo<UserDto>(user))
                .Returns(userDto);

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
            Assert.AreSame(actualResult, userDto);
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
