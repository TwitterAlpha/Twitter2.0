using BackUpSystem.Services.Data.Contracts;
using BackUpSystem.Web.Areas.Admin.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackUpSystem.Web.Controllers.UnitTests.UserManagementControllerTests
{
    [TestClass]
    class Constructor_Should
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

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new StatisticsController(null));
        }
    }
}
