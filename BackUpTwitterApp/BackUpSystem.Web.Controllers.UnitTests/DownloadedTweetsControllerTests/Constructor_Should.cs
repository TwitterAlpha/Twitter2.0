using BackUpSystem.Data.Models;
using BackUpSystem.Services.Data.Contracts;
using BackUpSystem.Utilities.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackUpSystem.Web.Controllers.UnitTests.DownloadedTweetsControllerTests
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
            var userServiceMock = new Mock<IUserService>();
            var userManagerMock = MockUserManager<User>();
            var mappingProviderMock = new Mock<IMappingProvider>();

            //Act
            var controller = new DownloadedTweetsController
                (userServiceMock.Object,
                userManagerMock.Object,
                mappingProviderMock.Object);

            //Assert
            Assert.IsNotNull(controller);
            Assert.IsInstanceOfType(controller, typeof(DownloadedTweetsController));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithNullUserServiceArgument()
        {
            //Arrange
            var userServiceMock = new Mock<IUserService>();
            var userManagerMock = MockUserManager<User>();
            var mappingProviderMock = new Mock<IMappingProvider>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() =>
            new DownloadedTweetsController
                (
                //userServiceMock.Object,
                null,
                userManagerMock.Object,
                mappingProviderMock.Object
                ));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithNullUserManagerArgument()
        {
            //Arrange
            var userServiceMock = new Mock<IUserService>();
            //var userManagerMock = MockUserManager<User>();
            var mappingProviderMock = new Mock<IMappingProvider>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() =>
            new DownloadedTweetsController
                (
                userServiceMock.Object,
                //userManagerMock.Object,
                null,
                mappingProviderMock.Object
                ));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithNullMappingProviderArgument()
        {
            //Arrange
            var userServiceMock = new Mock<IUserService>();
            var userManagerMock = MockUserManager<User>();
            //var mappingProviderMock = new Mock<IMappingProvider>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() =>
            new DownloadedTweetsController
                (
                userServiceMock.Object,
                userManagerMock.Object,
                 //mappingProviderMock.Object
                 null
                ));
        }
    }
}
