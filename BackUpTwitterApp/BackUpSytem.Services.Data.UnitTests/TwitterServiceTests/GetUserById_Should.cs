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
    public class GetUserById_Should
    {
        [TestMethod]
        public async Task ReturnTwitterAcountObject_WhenInvokedWithValidParameter()
        {
            //Arrange
            var apiServiceMock = new Mock<IOAuthCreationService>();
            var jsonDeserializerMock = new Mock<IJsonObjectDeserializer>();

            var id = "100";
            var resourceUrl = "https://api.twitter.com/1.1/users/show.json?user_id=";
            var jsonResponse = "JsonResponse";
            var expectedResult = new TwitterAccountApiDto() { Name = "Marto Stamatov" };

            apiServiceMock
                .Setup(x => x.GetTwitterApiCallData(resourceUrl + id, null))
                .ReturnsAsync(jsonResponse);

            jsonDeserializerMock
                .Setup(x => x.Deserialize<TwitterAccountApiDto>(jsonResponse))
                .Returns(expectedResult);

            var twitterService = new TwitterService(apiServiceMock.Object, jsonDeserializerMock.Object);

            //Act
            var actualResult = await twitterService.GetUserById(id);

            //Assert
            Assert.IsNotNull(actualResult);
            Assert.AreEqual(actualResult.Name, expectedResult.Name);
        }

        [TestMethod]
        public async Task CallGetTwitterApiCallDataMethodOnce_WhenInvokedWithValidParameters()
        {
            //Arrange
            var apiServiceMock = new Mock<IOAuthCreationService>();
            var jsonDeserializerMock = new Mock<IJsonObjectDeserializer>();

            string id = "100";
            var resourceUrl = "https://api.twitter.com/1.1/users/show.json?user_id=";
            var jsonResponse = "JsonResponse";
            var expectedResult = new TwitterAccountApiDto() { Name = "Marto Stamatov" };

            apiServiceMock
                .Setup(x => x.GetTwitterApiCallData(resourceUrl + id, null))
                .ReturnsAsync(jsonResponse);

            jsonDeserializerMock
                .Setup(x => x.Deserialize<TwitterAccountApiDto>(jsonResponse))
                .Returns(expectedResult);

            var twitterService = new TwitterService(apiServiceMock.Object, jsonDeserializerMock.Object);

            //Act
            var actualResult = await twitterService.GetUserById(id);

            //Assert
            apiServiceMock.Verify(x => x.GetTwitterApiCallData(resourceUrl + id, null), Times.Once);
        }

        [TestMethod]
        public async Task CallGetJsonDeserializerMethodOnce_WhenInvokedWithValidParameters()
        {
            //Arrange
            var apiServiceMock = new Mock<IOAuthCreationService>();
            var jsonDeserializerMock = new Mock<IJsonObjectDeserializer>();

            string id = "100";
            var resourceUrl = "https://api.twitter.com/1.1/users/show.json?user_id=";
            var jsonResponse = "JsonResponse";
            var expectedResult = new TwitterAccountApiDto() { Name = "Marto Stamatov" };

            apiServiceMock
                .Setup(x => x.GetTwitterApiCallData(resourceUrl + id, null))
                .ReturnsAsync(jsonResponse);

            jsonDeserializerMock
                .Setup(x => x.Deserialize<TwitterAccountApiDto>(jsonResponse))
                .Returns(expectedResult);

            var twitterService = new TwitterService(apiServiceMock.Object, jsonDeserializerMock.Object);

            //Act
            var actualResult = await twitterService.GetUserById(id);

            //Assert
            jsonDeserializerMock.Verify(x => x.Deserialize<TwitterAccountApiDto>(jsonResponse), Times.Once);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithNullIdInvalidParameters()
        {
            //Arrange
            var apiServiceMock = new Mock<IOAuthCreationService>();
            var jsonDeserializerMock = new Mock<IJsonObjectDeserializer>();

            string id = null;
            var resourceUrl = "https://api.twitter.com/1.1/users/show.json?user_id=";
            var jsonResponse = "JsonResponse";
            var expectedResult = new TwitterAccountApiDto() { Name = "Marto Stamatov" };

            apiServiceMock
                .Setup(x => x.GetTwitterApiCallData(resourceUrl + id, null))
                .ReturnsAsync(jsonResponse);

            jsonDeserializerMock
                .Setup(x => x.Deserialize<TwitterAccountApiDto>(jsonResponse))
                .Returns(expectedResult);

            var twitterService = new TwitterService(apiServiceMock.Object, jsonDeserializerMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await twitterService.GetUserById(id));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithEmptyIdInvalidParameters()
        {
            //Arrange
            var apiServiceMock = new Mock<IOAuthCreationService>();
            var jsonDeserializerMock = new Mock<IJsonObjectDeserializer>();

            string id = string.Empty;
            var resourceUrl = "https://api.twitter.com/1.1/users/show.json?user_id=";
            var jsonResponse = "JsonResponse";
            var expectedResult = new TwitterAccountApiDto() { Name = "Marto Stamatov" };

            apiServiceMock
                .Setup(x => x.GetTwitterApiCallData(resourceUrl + id, null))
                .ReturnsAsync(jsonResponse);

            jsonDeserializerMock
                .Setup(x => x.Deserialize<TwitterAccountApiDto>(jsonResponse))
                .Returns(expectedResult);

            var twitterService = new TwitterService(apiServiceMock.Object, jsonDeserializerMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentException>(async () => await twitterService.GetUserById(id));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenJsonResponseIsNull()
        {
            //Arrange
            var apiServiceMock = new Mock<IOAuthCreationService>();
            var jsonDeserializerMock = new Mock<IJsonObjectDeserializer>();

            string id = null;
            var resourceUrl = "https://api.twitter.com/1.1/users/show.json?user_id=";
            string jsonResponse = null;
            var expectedResult = new TwitterAccountApiDto() { Name = "Marto Stamatov" };

            apiServiceMock
                .Setup(x => x.GetTwitterApiCallData(resourceUrl + id, null))
                .ReturnsAsync(jsonResponse);

            jsonDeserializerMock
                .Setup(x => x.Deserialize<TwitterAccountApiDto>(jsonResponse))
                .Returns(expectedResult);

            var twitterService = new TwitterService(apiServiceMock.Object, jsonDeserializerMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await twitterService.GetUserById(id));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenJsonResponseIsEmptyString()
        {
            //Arrange
            var apiServiceMock = new Mock<IOAuthCreationService>();
            var jsonDeserializerMock = new Mock<IJsonObjectDeserializer>();

            string id = string.Empty;
            var resourceUrl = "https://api.twitter.com/1.1/users/show.json?user_id=";
            var jsonResponse = string.Empty;
            var expectedResult = new TwitterAccountApiDto() { Name = "Marto Stamatov" };

            apiServiceMock
                .Setup(x => x.GetTwitterApiCallData(resourceUrl + id, null))
                .ReturnsAsync(jsonResponse);

            jsonDeserializerMock
                .Setup(x => x.Deserialize<TwitterAccountApiDto>(jsonResponse))
                .Returns(expectedResult);

            var twitterService = new TwitterService(apiServiceMock.Object, jsonDeserializerMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentException>(async () => await twitterService.GetUserById(id));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenJsonDeserializerReturnsNull()
        {
            //Arrange
            var apiServiceMock = new Mock<IOAuthCreationService>();
            var jsonDeserializerMock = new Mock<IJsonObjectDeserializer>();

            string id = string.Empty;
            var resourceUrl = "https://api.twitter.com/1.1/users/show.json?user_id=";
            var jsonResponse = string.Empty;
            TwitterAccountApiDto expectedResult = null;

            apiServiceMock
                .Setup(x => x.GetTwitterApiCallData(resourceUrl + id, null))
                .ReturnsAsync(jsonResponse);

            jsonDeserializerMock
                .Setup(x => x.Deserialize<TwitterAccountApiDto>(jsonResponse))
                .Returns(expectedResult);

            var twitterService = new TwitterService(apiServiceMock.Object, jsonDeserializerMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentException>(async () => await twitterService.GetUserById(id));
        }
    }
}
