using BackUpSystem.Services.Data.Contracts;
using BackUpSystem.Web.Areas.Admin.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace BackUpSystem.Web.Controllers.UnitTests.UserManagementControllerTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void CreateInstance_WhenInvokedWithValidParameters()
        {
            //Arrange
            var userServiceMock = new Mock<IUserService>();
            var twitterAccountServiceMock = new Mock<ITwitterAccountService>();
            var tweetServiceMock = new Mock<ITweetService>();

            //Act
            var userManagementController = new UserManagementController
                 (
             userServiceMock.Object,
             twitterAccountServiceMock.Object,
             tweetServiceMock.Object
                );

            //Assert
            Assert.IsNotNull(userManagementController);
            Assert.IsInstanceOfType(userManagementController, typeof(UserManagementController));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithNullUserServiceArgument()
        {
            //Arrange
            //var userServiceMock = new Mock<IUserService>();
            var twitterAccountServiceMock = new Mock<ITwitterAccountService>();
            var tweetServiceMock = new Mock<ITweetService>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new UserManagementController
                 (
             null,
             twitterAccountServiceMock.Object,
             tweetServiceMock.Object
                ));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithNullTwitterAccountServiceArgument()
        {
            //Arrange
            var userServiceMock = new Mock<IUserService>();
            //var twitterAccountServiceMock = new Mock<ITwitterAccountService>();
            var tweetServiceMock = new Mock<ITweetService>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new UserManagementController
                 (
             userServiceMock.Object,
             null,
             tweetServiceMock.Object
                ));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithNullTweetServiceArgument()
        {
            //Arrange
            var userServiceMock = new Mock<IUserService>();
            var twitterAccountServiceMock = new Mock<ITwitterAccountService>();
            //var tweetServiceMock = new Mock<ITweetService>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new UserManagementController
                 (
              userServiceMock.Object,
             twitterAccountServiceMock.Object,
             null
                ));
        }
    }
}
