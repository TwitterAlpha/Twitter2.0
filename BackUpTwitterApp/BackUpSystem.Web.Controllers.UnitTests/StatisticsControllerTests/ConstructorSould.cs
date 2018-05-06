using BackUpSystem.Services.Data.Contracts;
using BackUpSystem.Web.Areas.Admin.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace BackUpSystem.Web.Controllers.UnitTests.StatisticsControllerTests
{
    [TestClass]
    public class ConstructorSould
    {
        [TestMethod]
        public void CreateInstance_WhenInvokedWithValidParameters()
        {
            //Arrange
            var userServiceMock = new Mock<IUserService>();

            //Act
            var statisticsController = new StatisticsController(
                userServiceMock.Object
                );

            //Assert
            Assert.IsNotNull(statisticsController);
            Assert.IsInstanceOfType(statisticsController, typeof(StatisticsController));
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
