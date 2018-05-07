using BackUpSystem.Data.Models;
using BackUpSystem.Services.Data.Contracts;
using BackUpSystem.Utilities.Contracts;
using BackUpSystem.Web.Areas.Admin.Controllers;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace BackUpSystem.Web.Controllers.UnitTests.TwitterAccountControllerTests
{
    [TestClass]
    public class Constructor_Should
    {
        public static Mock<UserManager<TUser>> MockUserManager<TUser>() where TUser : class
        {
            var store = new Mock<IUserStore<TUser>>();
            var mgr = new Mock<UserManager<TUser>>(store.Object, null, null, null, null, null, null, null, null);
            mgr.Object.UserValidators.Add(new UserValidator<TUser>());
            mgr.Object.PasswordValidators.Add(new PasswordValidator<TUser>());
            return mgr;
        }

        [TestMethod]
        public void CreateInstance_WhenInvokedWithValidParameters()
        {
            //Arrange
            var twitterServiceMock = new Mock<ITwitterService>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var twitterAccountServiceMock = new Mock<ITwitterAccountService>();
            var userServiceMock = new Mock<IUserService>();
            var userManagerMock = MockUserManager<User>();


            //Act
            var controller =
                new TwitterAccountController(
                  twitterServiceMock.Object,
                  twitterAccountServiceMock.Object,
                  userServiceMock.Object,
                  mappingProviderMock.Object,
                  userManagerMock.Object
                    );

            //Assert
            Assert.IsNotNull(controller);
            Assert.IsInstanceOfType(controller, typeof(TwitterAccountController));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithNullTwetterServiceArgument()
        {
            //Arrange
            //Arrange
            var twitterServiceMock = new Mock<ITwitterService>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var twitterAccountServiceMock = new Mock<ITwitterAccountService>();
            var userServiceMock = new Mock<IUserService>();
            var userManagerMock = MockUserManager<User>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() =>
            new TwitterAccountController(
                  null,
                  twitterAccountServiceMock.Object,
                  userServiceMock.Object,
                  mappingProviderMock.Object,
                  userManagerMock.Object
                    )
            );
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithNullMappingProviderArgument()
        {
            //Arrange
            //Arrange
            var twitterServiceMock = new Mock<ITwitterService>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var twitterAccountServiceMock = new Mock<ITwitterAccountService>();
            var userServiceMock = new Mock<IUserService>();
            var userManagerMock = MockUserManager<User>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() =>
            new TwitterAccountController(
                  twitterServiceMock.Object,
                  twitterAccountServiceMock.Object,
                  userServiceMock.Object,
                  null,
                  userManagerMock.Object
                    )
            );
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithNullTwetterAccountServiceArgument()
        {
            //Arrange
            //Arrange
            var twitterServiceMock = new Mock<ITwitterService>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var twitterAccountServiceMock = new Mock<ITwitterAccountService>();
            var userServiceMock = new Mock<IUserService>();
            var userManagerMock = MockUserManager<User>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() =>
            new TwitterAccountController(
                  twitterServiceMock.Object,
                  null,
                  userServiceMock.Object,
                  mappingProviderMock.Object,
                  userManagerMock.Object
                    )
            );
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithNullUserServiceArgument()
        {
            //Arrange
            //Arrange
            var twitterServiceMock = new Mock<ITwitterService>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var twitterAccountServiceMock = new Mock<ITwitterAccountService>();
            var userServiceMock = new Mock<IUserService>();
            var userManagerMock = MockUserManager<User>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() =>
            new TwitterAccountController(
                  twitterServiceMock.Object,
                  twitterAccountServiceMock.Object,
                  null,
                  mappingProviderMock.Object,
                  userManagerMock.Object
                    )
            );
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithNullUserManagerArgument()
        {
            //Arrange
            //Arrange
            var twitterServiceMock = new Mock<ITwitterService>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var twitterAccountServiceMock = new Mock<ITwitterAccountService>();
            var userServiceMock = new Mock<IUserService>();
            var userManagerMock = MockUserManager<User>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() =>
            new TwitterAccountController(
                  twitterServiceMock.Object,
                  twitterAccountServiceMock.Object,
                  userServiceMock.Object,
                  mappingProviderMock.Object,
                  null
                    )
            );
        }
    }
}
