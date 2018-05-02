using BackUpSystem.DTO;
using BackUpSystem.Services.Auth.Contracts;
using BackUpSystem.Services.Data;
using BackUpSystem.Utilities.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;

namespace BackUpSytem.Services.Data.UnitTests.TwitterServiceTests
{
    [TestClass]
    public class GetUserByScreenName_Should
    {
        [TestMethod]
        public async Task ReturnTwitterAcountObject_WhenInvokedWithValidParameter()
        {
            //Arrange
            var apiServiceMock = new Mock<IOAuthCreationService>();
            var jsonDeserializerMock = new Mock<IJsonObjectDeserializer>();

            var screenName = "Elon Musk";
            var resourceUrl = "https://api.twitter.com/1.1/users/show.json?screen_name=";
            var jsonResponse = "JsonResponse";
            var expectedResult = new TwitterAccountApiDto() { Name = "Marto Stamatov" };

            apiServiceMock
                .Setup(x => x.GetTwitterApiCallData(resourceUrl + screenName, null))
                .ReturnsAsync(jsonResponse);

            jsonDeserializerMock
                .Setup(x => x.Deserialize<TwitterAccountApiDto>(jsonResponse))
                .Returns(expectedResult);

            var twitterService = new TwitterService(apiServiceMock.Object, jsonDeserializerMock.Object);

            //Act
            var actualResult = await twitterService.GetUserByScreenName(screenName);

            //Assert
            Assert.IsNotNull(actualResult);
            Assert.IsInstanceOfType(actualResult, typeof(TwitterAccountApiDto));
            Assert.AreEqual(actualResult.Name, expectedResult.Name);
        }

        [TestMethod]
        public async Task CallGetTwitterApiCallDataMethodOnce_WhenInvokedWithValidParameters()
        {
            //Arrange
            var apiServiceMock = new Mock<IOAuthCreationService>();
            var jsonDeserializerMock = new Mock<IJsonObjectDeserializer>();

            string screenName = "Elon Musk";
            var resourceUrl = "https://api.twitter.com/1.1/users/show.json?screen_name=";
            var jsonResponse = "JsonResponse";
            var expectedResult = new TwitterAccountApiDto() { Name = "Marto Stamatov" };

            apiServiceMock
                .Setup(x => x.GetTwitterApiCallData(resourceUrl + screenName, null))
                .ReturnsAsync(jsonResponse);

            jsonDeserializerMock
                .Setup(x => x.Deserialize<TwitterAccountApiDto>(jsonResponse))
                .Returns(expectedResult);

            var twitterService = new TwitterService(apiServiceMock.Object, jsonDeserializerMock.Object);

            //Act
            var actualResult = await twitterService.GetUserByScreenName(screenName);

            //Assert
            apiServiceMock.Verify(x => x.GetTwitterApiCallData(resourceUrl + screenName, null), Times.Once);
        }

        [TestMethod]
        public async Task CallGetJsonDeserializerMethodOnce_WhenInvokedWithValidParameters()
        {
            //Arrange
            var apiServiceMock = new Mock<IOAuthCreationService>();
            var jsonDeserializerMock = new Mock<IJsonObjectDeserializer>();

            string screenName = "Elon Musk";
            var resourceUrl = "https://api.twitter.com/1.1/users/show.json?screen_name=";
            var jsonResponse = "JsonResponse";
            var expectedResult = new TwitterAccountApiDto() { Name = "Marto Stamatov" };

            apiServiceMock
                .Setup(x => x.GetTwitterApiCallData(resourceUrl + screenName, null))
                .ReturnsAsync(jsonResponse);

            jsonDeserializerMock
                .Setup(x => x.Deserialize<TwitterAccountApiDto>(jsonResponse))
                .Returns(expectedResult);

            var twitterService = new TwitterService(apiServiceMock.Object, jsonDeserializerMock.Object);

            //Act
            var actualResult = await twitterService.GetUserByScreenName(screenName);

            //Assert
            jsonDeserializerMock.Verify(x => x.Deserialize<TwitterAccountApiDto>(jsonResponse), Times.Once);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithNullScreenNameInvalidParameter()
        {
            //Arrange
            var apiServiceMock = new Mock<IOAuthCreationService>();
            var jsonDeserializerMock = new Mock<IJsonObjectDeserializer>();

            string screenName = null;
            var resourceUrl = "https://api.twitter.com/1.1/users/show.json?screen_name=";
            var jsonResponse = "JsonResponse";
            var expectedResult = new TwitterAccountApiDto() { Name = "Marto Stamatov" };

            apiServiceMock
                .Setup(x => x.GetTwitterApiCallData(resourceUrl + screenName, null))
                .ReturnsAsync(jsonResponse);

            jsonDeserializerMock
                .Setup(x => x.Deserialize<TwitterAccountApiDto>(jsonResponse))
                .Returns(expectedResult);

            var twitterService = new TwitterService(apiServiceMock.Object, jsonDeserializerMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await twitterService.GetUserByScreenName(screenName));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithEmptyScreenNameInvalidParameters()
        {
            //Arrange
            var apiServiceMock = new Mock<IOAuthCreationService>();
            var jsonDeserializerMock = new Mock<IJsonObjectDeserializer>();

            string screenName = string.Empty;
            var resourceUrl = "https://api.twitter.com/1.1/users/show.json?screen_name=";
            var jsonResponse = "JsonResponse";
            var expectedResult = new TwitterAccountApiDto() { Name = "Marto Stamatov" };

            apiServiceMock
                .Setup(x => x.GetTwitterApiCallData(resourceUrl + screenName, null))
                .ReturnsAsync(jsonResponse);

            jsonDeserializerMock
                .Setup(x => x.Deserialize<TwitterAccountApiDto>(jsonResponse))
                .Returns(expectedResult);

            var twitterService = new TwitterService(apiServiceMock.Object, jsonDeserializerMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentException>(async () => await twitterService.GetUserByScreenName(screenName));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenJsonResponseIsNull()
        {
            //Arrange
            var apiServiceMock = new Mock<IOAuthCreationService>();
            var jsonDeserializerMock = new Mock<IJsonObjectDeserializer>();

            string screenName = "Elon Musk";
            var resourceUrl = "https://api.twitter.com/1.1/users/show.json?screen_name=";
            string jsonResponse = null;
            var expectedResult = new TwitterAccountApiDto() { Name = "Marto Stamatov" };

            apiServiceMock
                .Setup(x => x.GetTwitterApiCallData(resourceUrl + screenName, null))
                .ReturnsAsync(jsonResponse);

            jsonDeserializerMock
                .Setup(x => x.Deserialize<TwitterAccountApiDto>(jsonResponse))
                .Returns(expectedResult);

            var twitterService = new TwitterService(apiServiceMock.Object, jsonDeserializerMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await twitterService.GetUserByScreenName(screenName));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenJsonResponseIsEmptyString()
        {
            //Arrange
            var apiServiceMock = new Mock<IOAuthCreationService>();
            var jsonDeserializerMock = new Mock<IJsonObjectDeserializer>();

            string screenName = "Elon Musk";
            var resourceUrl = "https://api.twitter.com/1.1/users/show.json?screen_name=";
            var jsonResponse = string.Empty;
            var expectedResult = new TwitterAccountApiDto() { Name = "Marto Stamatov" };

            apiServiceMock
                .Setup(x => x.GetTwitterApiCallData(resourceUrl + screenName, null))
                .ReturnsAsync(jsonResponse);

            jsonDeserializerMock
                .Setup(x => x.Deserialize<TwitterAccountApiDto>(jsonResponse))
                .Returns(expectedResult);

            var twitterService = new TwitterService(apiServiceMock.Object, jsonDeserializerMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentException>(async () => await twitterService.GetUserByScreenName(screenName));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenJsonDeserializerReturnsNull()
        {
            //Arrange
            var apiServiceMock = new Mock<IOAuthCreationService>();
            var jsonDeserializerMock = new Mock<IJsonObjectDeserializer>();

            string screenName = "Elon Musk";
            var resourceUrl = "https://api.twitter.com/1.1/users/show.json?screen_name=";
            var jsonResponse = "JsonResponse";
            TwitterAccountApiDto expectedResult = null;

            apiServiceMock
                .Setup(x => x.GetTwitterApiCallData(resourceUrl + screenName, null))
                .ReturnsAsync(jsonResponse);

            jsonDeserializerMock
                .Setup(x => x.Deserialize<TwitterAccountApiDto>(jsonResponse))
                .Returns(expectedResult);

            var twitterService = new TwitterService(apiServiceMock.Object, jsonDeserializerMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentException>(async () => await twitterService.GetUserByScreenName(screenName));
        }
    }
}
