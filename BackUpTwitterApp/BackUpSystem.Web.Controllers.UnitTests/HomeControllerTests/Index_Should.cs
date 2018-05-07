using BackUpSystem.Data.Models;
using BackUpSystem.Services.Data.Contracts;
using BackUpSystem.Utilities.Contracts;
using BackUpSystem.Web.Areas.Admin.Controllers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;

namespace BackUpSystem.Web.Controllers.UnitTests.HomeControllerTests
{
    [TestClass]
    public class Index_Should
    {
        /*
        public static Mock<UserManager<TUser>> MockUserManager<TUser>() where TUser : class
        {
            var store = new Mock<IUserStore<TUser>>();
            var mgr = new Mock<UserManager<TUser>>(store.Object, null, null, null, null, null, null, null, null);
            mgr.Object.UserValidators.Add(new UserValidator<TUser>());
            mgr.Object.PasswordValidators.Add(new PasswordValidator<TUser>());
            return mgr;
        }

        [TestMethod]
        public async Task ReturnIndexViewWhenInvoked()
        {
            //Arrange
            var userServiceMock = new Mock<IUserService>();
            var userManagerMock = MockUserManager<User>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var twitterService = new Mock<ITwitterService>();

            var controller = new HomeController
                (userServiceMock.Object,
                userManagerMock.Object,
                mappingProviderMock.Object,
                twitterService.Object
                );

            //Act & Assert
            var result = await controller.Index() as RedirectToActionResult;
            Assert.AreEqual("About", result.ActionName);
        }
        */
    }
}
