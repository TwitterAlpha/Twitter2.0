using BackUpSystem.Data.Models;
using BackUpSystem.Services.Data.Contracts;
using BackUpSystem.Utilities.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackUpSystem.Web.Controllers.UnitTests.SearchControllerTests
{
    [TestClass]
    public class Constructor_Should
    {
        

        [TestMethod]
        public void CreateInstance_WhenInvokedWithValidParameters()
        {
            //Arrange
            var twitterService = new Mock<ITwitterService>();
            var mappingProvider = new Mock<IMappingProvider>();

            //Act
            var controller = 
                new SearchController
                (
                    twitterService.Object,
                    mappingProvider.Object
                    );
               

            //Assert
            Assert.IsNotNull(controller);
            Assert.IsInstanceOfType(controller, typeof(SearchController));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithNullTwitterServiceArgument()
        {
            //Arrange
            var twitterService = new Mock<ITwitterService>();
            var mappingProvider = new Mock<IMappingProvider>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() =>
            new SearchController
                (
                    null,
                    mappingProvider.Object
                    ));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithNullMappingProviderArgument()
        {
            //Arrange
            var twitterService = new Mock<ITwitterService>();
            var mappingProvider = new Mock<IMappingProvider>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() =>
            new SearchController
                (
                    twitterService.Object,
                    null
                    ));
        }
    }
}
