using BackUpSystem.Data.Models;
using BackUpSystem.Services.Data.Contracts;
using BackUpSystem.Web.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;

namespace BackUpSystem.Web.Controllers.UnitTests.AccountControllerTests
{
    /*
    public static class MockProvider
    {
        public static SignInManager<User> SignInManager(UserManager<User> userManager)
        {
            var signInManagerMock = new Mock<SignInManager<User>>(
                userManager,
                Mock.Of<IHttpContextAccessor>(),
                Mock.Of<IUserClaimsPrincipalFactory<User>>(),
                Mock.Of<IOptions<IdentityOptions>>(),
                null);

            signInManagerMock
                .Setup(s => s.PasswordSignInAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<bool>(),
                    It.IsAny<bool>()))
                .Returns((string userName, string password, bool isPersistent, bool lockoutOnFailure) =>
                {
                    if (userName == "valid@valid.com" && password == "valid")
                    {
                        return Task.FromResult(SignInResult.Success);
                    }

                    return Task.FromResult(SignInResult.Failed);
                });

            return signInManagerMock.Object;
        }
    }

    [TestClass]
    public class Constructor_Should
    {
        //General class Arrange
        public static Mock<UserManager<TUser>> MockUserManager<TUser>() where TUser : class
        {
            var store = new Mock<IUserStore<TUser>>();
            var mgr = new Mock<UserManager<TUser>>(store.Object, null, null, null, null, null, null, null, null);
            mgr.Object.UserValidators.Add(new UserValidator<TUser>());
            mgr.Object.PasswordValidators.Add(new PasswordValidator<TUser>());
            return mgr;
        }

        //public static Mock<UserManager<TUser>> MockUserManager<TUser>() where TUser : class
        //{
        //    IList<IUserValidator<TUser>> UserValidators = new List<IUserValidator<TUser>>();
        //    IList<IPasswordValidator<TUser>> PasswordValidators = new List<IPasswordValidator<TUser>>();

        //    var store = new Mock<IUserStore<TUser>>();
        //    UserValidators.Add(new UserValidator<TUser>());
        //    PasswordValidators.Add(new PasswordValidator<TUser>());
        //    var mgr = new Mock<UserManager<TUser>>(store.Object, null, null, UserValidators, PasswordValidators, null, null, null, null, null);
        //    return mgr;
        //}

        public static Mock<SignInManager<TUser>> MockSignInManager<TUser>() where TUser : class
        {
            var context = new Mock<HttpContext>();
            var manager = MockUserManager<TUser>();
            return new Mock<SignInManager<TUser>>(manager.Object,
                new HttpContextAccessor { HttpContext = context.Object },
                new Mock<IUserClaimsPrincipalFactory<TUser>>().Object,
                null, null)
            { CallBase = true };
        }
/// <summary>
/// ----------------------TESTS ----------------------
/// </summary>
/// 
        [TestMethod]
        public void CreateInstance_WhenInvokedWithValidParameters()
        {
            //Arrange
            //var userManagerMock = GetMockUserManager();
            var userManagerMock = MockUserManager<User>();
            var signInManagerMock = MockProvider.SignInManager(userManagerMock.Object);
            var emailSenderMock = new Mock<IEmailSender>();
            var loggerMock = new Mock<ILogger<AccountController>>();
            var twitterServiceMock = new Mock<ITwitterService>();
            var userServiceMock = new Mock<IUserService>();
            var twitterAccountServiceMock = new Mock<ITwitterAccountService>();
            var tweetServiceMock = new Mock<ITweetService>();

            //Act
            var controller = new AccountController
                 (
                userManagerMock.Object,
                signInManagerMock,
                emailSenderMock.Object,
                loggerMock.Object,
                twitterServiceMock.Object,
                userServiceMock.Object,
                twitterAccountServiceMock.Object,
                tweetServiceMock.Object
                );

            //Assert
            Assert.IsNotNull(controller);
            Assert.IsInstanceOfType(controller, typeof(AccountController));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithNullUserManagerArgument()
        {
            //Arrange
            //var userManagerMock = new Mock<UserManager<User>>();
            var userManagerMock = MockUserManager<User>();
            var signInManagerMock = MockSignInManager<User>();
            var emailSenderMock = new Mock<IEmailSender>();
            var loggerMock = new Mock<ILogger<AccountController>>();
            var twitterServiceMock = new Mock<ITwitterService>();
            var userServiceMock = new Mock<IUserService>();
            var twitterAccountServiceMock = new Mock<ITwitterAccountService>();
            var tweetServiceMock = new Mock<ITweetService>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new AccountController
                 (
                //userManagerMock.Object,
                null,
                signInManagerMock.Object,
                emailSenderMock.Object,
                loggerMock.Object,
                twitterServiceMock.Object,
                userServiceMock.Object,
                twitterAccountServiceMock.Object,
                tweetServiceMock.Object
                ));
        }
    } */
}
