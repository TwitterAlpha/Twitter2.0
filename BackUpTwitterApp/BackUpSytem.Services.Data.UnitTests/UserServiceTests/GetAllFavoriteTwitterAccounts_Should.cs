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
using System.Threading.Tasks;

namespace BackUpSytem.Services.Data.UnitTests.UserServiceTests
{
    [TestClass]
    public class GetAllFavoriteTwitterAccounts_Should
    {
        [TestMethod]
        public async Task ReturnCollectionOfTwitterAccountDtobjects_WhenInvokedWithValidParameter()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterServiceMock = new Mock<ITwitterService>();
            var userManagerMock = MockUserManager<User>();

            var userId = "30";
            var twitterAccount = new TwitterAccount() { Name = "Grigor", Id = "30" };
            var twitterAccounts = new List<TwitterAccount>()
            {
                twitterAccount
            };

            var twitterAccountDto = new TwitterAccountDto() { Name = "Grigor", Id = "30" };
            var expectedResult = new List<TwitterAccountDto>()
            {
                twitterAccountDto
            };

            userRepositoryMock
                .Setup(x => x.GetAllFavoriteTwitterAccounts(userId))
                .ReturnsAsync(twitterAccounts);

            mappingProviderMock
                .Setup(x => x.ProjectTo<TwitterAccount, TwitterAccountDto>(twitterAccounts))
                .Returns(expectedResult);

            var userService = new UserService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                twitterServiceMock.Object,
                userManagerMock.Object);

            //Act
            var actualResult = await userService.GetAllFavoriteTwitterAccounts(userId);

            //Assert
            Assert.IsNotNull(actualResult);
            Assert.AreSame(actualResult, expectedResult);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullIdParameter()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterServiceMock = new Mock<ITwitterService>();
            var userManagerMock = MockUserManager<User>();

            var userId = "30";
            var twitterAccount = new TwitterAccount() { Name = "Grigor", Id = "30" };
            var twitterAccounts = new List<TwitterAccount>()
            {
                twitterAccount
            };

            var twitterAccountDto = new TwitterAccountDto() { Name = "Grigor", Id = "30" };
            var expectedResult = new List<TwitterAccountDto>()
            {
                twitterAccountDto
            };

            userRepositoryMock
                .Setup(x => x.GetAllFavoriteTwitterAccounts(userId))
                .ReturnsAsync(twitterAccounts);

            mappingProviderMock
                .Setup(x => x.ProjectTo<TwitterAccount, TwitterAccountDto>(twitterAccounts))
                .Returns(expectedResult);

            var userService = new UserService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                twitterServiceMock.Object,
                userManagerMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await userService.GetAllFavoriteTwitterAccounts(null));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithInvalidEmptyIdParameter()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterServiceMock = new Mock<ITwitterService>();
            var userManagerMock = MockUserManager<User>();

            var userId = "30";
            var twitterAccount = new TwitterAccount() { Name = "Grigor", Id = "30" };
            var twitterAccounts = new List<TwitterAccount>()
            {
                twitterAccount
            };

            var twitterAccountDto = new TwitterAccountDto() { Name = "Grigor", Id = "30" };
            var expectedResult = new List<TwitterAccountDto>()
            {
                twitterAccountDto
            };

            userRepositoryMock
                .Setup(x => x.GetAllFavoriteTwitterAccounts(userId))
                .ReturnsAsync(twitterAccounts);

            mappingProviderMock
                .Setup(x => x.ProjectTo<TwitterAccount, TwitterAccountDto>(twitterAccounts))
                .Returns(expectedResult);

            var userService = new UserService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                twitterServiceMock.Object,
                userManagerMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentException>(async () => await userService.GetAllFavoriteTwitterAccounts(string.Empty));
        }


        [TestMethod]
        public void ThrowArgumentNullException_WhenUserRepositoryGetUserByIdMethodReturnsNull()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterServiceMock = new Mock<ITwitterService>();
            var userManagerMock = MockUserManager<User>();

            var userId = "30";
            var twitterAccount = new TwitterAccount() { Name = "Grigor", Id = "30" };
            var twitterAccounts = new List<TwitterAccount>()
            {
                twitterAccount
            };

            var twitterAccountDto = new TwitterAccountDto() { Name = "Grigor", Id = "30" };
            var expectedResult = new List<TwitterAccountDto>()
            {
                twitterAccountDto
            };

            userRepositoryMock
                .Setup(x => x.GetAllFavoriteTwitterAccounts(userId))
                .ReturnsAsync((IEnumerable<TwitterAccount>)null);

            mappingProviderMock
                .Setup(x => x.ProjectTo<TwitterAccount, TwitterAccountDto>(twitterAccounts))
                .Returns(expectedResult);

            var userService = new UserService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                twitterServiceMock.Object,
                userManagerMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await userService.GetAllFavoriteTwitterAccounts(userId));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenMappingProviderProjectToMethodReturnsNull()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var twitterServiceMock = new Mock<ITwitterService>();
            var userManagerMock = MockUserManager<User>();

            var userId = "30";
            var twitterAccount = new TwitterAccount() { Name = "Grigor", Id = "30" };
            var twitterAccounts = new List<TwitterAccount>()
            {
                twitterAccount
            };

            var twitterAccountDto = new TwitterAccountDto() { Name = "Grigor", Id = "30" };
            var expectedResult = new List<TwitterAccountDto>()
            {
                twitterAccountDto
            };

            userRepositoryMock
                .Setup(x => x.GetAllFavoriteTwitterAccounts(userId))
                .ReturnsAsync(twitterAccounts);

            mappingProviderMock
                .Setup(x => x.ProjectTo<TwitterAccount, TwitterAccountDto>(twitterAccounts))
                .Returns((IEnumerable<TwitterAccountDto>)null);

            var userService = new UserService(
                unitOfWorkMock.Object,
                mappingProviderMock.Object,
                userRepositoryMock.Object,
                twitterServiceMock.Object,
                userManagerMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await userService.GetAllFavoriteTwitterAccounts(userId));
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
