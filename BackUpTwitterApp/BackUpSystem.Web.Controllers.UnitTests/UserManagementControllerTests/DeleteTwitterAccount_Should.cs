using BackUpSystem.Services.Data.Contracts;
using BackUpSystem.Web.Areas.Admin.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;

namespace BackUpSystem.Web.Controllers.UnitTests.UserManagementControllerTests
{
    [TestClass]
    public class DeleteTwitterAccount_Should
    {
        [TestMethod]
        public async Task RedirectToActionDetailsWhenInvoked()
        {
            //Arrange
            var userServiceMock = new Mock<IUserService>();
            var twitterAccountServiceMock = new Mock<ITwitterAccountService>();
            var tweetServiceMock = new Mock<ITweetService>();

            var controller = new UserManagementController
                 (
             userServiceMock.Object,
             twitterAccountServiceMock.Object,
             tweetServiceMock.Object
                );

            //Act & Assert
            var result = await controller.DeleteTwitterAccount("2", "5") as RedirectToActionResult;
            Assert.AreEqual("Details", result.ActionName);
        }
    }
}
