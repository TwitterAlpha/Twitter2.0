using BackUpSystem.Services.Auth.Contracts;
using BackUpSystem.Services.Data;
using BackUpSystem.Services.Data.Contracts;
using BackUpSystem.Utilities.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace BackUpSytem.Services.Data.UnitTests.TwitterServiceTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void CreateInstance_WhenInvokedWithValidParameters() 
        {
            //Arrange
            var authCreationServiceMock = new Mock<IOAuthCreationService>();
            var jsonDeserializerMock = new Mock<IJsonObjectDeserializer>();

            //Act
            var twitterService = new TwitterService(authCreationServiceMock.Object, jsonDeserializerMock.Object);

            //Assert
            Assert.IsNotNull(twitterService);
            Assert.IsInstanceOfType(twitterService, typeof(ITwitterService));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithNullAuthServiceParameter()
        {
            // Arrange
            //var authCreationServiceMock = new Mock<IOAuthCreationService>();
            var jsonDeserializerMock = new Mock<IJsonObjectDeserializer>();

            // Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new TwitterService(null, jsonDeserializerMock.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithNullJsonDeserializerParameter()
        {
            // Arrange
            var authCreationServiceMock = new Mock<IOAuthCreationService>();
            //var jsonDeserializerMock = new Mock<IJsonObjectDeserializer>();

            // Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new TwitterService(authCreationServiceMock.Object, null));
        }
    }
}
