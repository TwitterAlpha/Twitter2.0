using BackUpSystem.Data.Models;
using BackUpSystem.Services.Data.Contracts;
using BackUpSystem.Utilities.Contracts;
using BackUpSystem.Web.Areas.Admin.Controllers;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace BackUpSystem.Web.Controllers.UnitTests.TweetControlerTests
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
            var tweetServiceMock = new Mock<ITweetService>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userManagerMock = MockUserManager<User>();


            //Act
            var controller = 
                new TweetController
                (
                    tweetServiceMock.Object,
                    userManagerMock.Object,
                    mappingProviderMock.Object);

            //Assert
            Assert.IsNotNull(controller);
            Assert.IsInstanceOfType(controller, typeof(TweetController));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithNullTweetServiceArgument()
        {
            //Arrange
            var tweetServiceMock = new Mock<ITweetService>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userManagerMock = MockUserManager<User>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() =>
            new TweetController
                (
                    null,
                    userManagerMock.Object,
                    mappingProviderMock.Object)
            );
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithNullMappingProviderArgument()
        {
            //Arrange
            var tweetServiceMock = new Mock<ITweetService>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userManagerMock = MockUserManager<User>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() =>
            new TweetController
                (
                    tweetServiceMock.Object,
                    null,
                    mappingProviderMock.Object)
            );
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithNullUserManagerArgument()
        {
            //Arrange
            var tweetServiceMock = new Mock<ITweetService>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userManagerMock = MockUserManager<User>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() =>
            new TweetController
                (
                    tweetServiceMock.Object,
                    userManagerMock.Object,
                    null)
            );
        }
    }
}
