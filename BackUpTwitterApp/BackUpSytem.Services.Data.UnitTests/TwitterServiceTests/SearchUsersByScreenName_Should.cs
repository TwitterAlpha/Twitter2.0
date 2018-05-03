using BackUpSystem.DTO;
using BackUpSystem.Services.Auth.Contracts;
using BackUpSystem.Services.Data;
using BackUpSystem.Utilities.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackUpSytem.Services.Data.UnitTests.TwitterServiceTests
{
    [TestClass]
    public class SearchUsersByScreenName_Should
    {
        [TestMethod]
        public async Task ReturnCollectionOfTwitterAcounts_WhenInvokedWithValidParameter()
        {
            //Arrange
            var apiServiceMock = new Mock<IOAuthCreationService>();
            var jsonDeserializerMock = new Mock<IJsonObjectDeserializer>();

            var screenName = "Grigor";
            var resourceUrl = "https://api.twitter.com/1.1/users/search.json?q=";
            var jsonResponse = "JsonResponse";
            var twitterAccount = new TwitterAccountApiDto() { Name = "Marto Stamatov" };
            ICollection<TwitterAccountApiDto> expectedResult = new List<TwitterAccountApiDto>
            {
                twitterAccount
            };

            apiServiceMock
                .Setup(x => x.GetTwitterApiCallData($"{resourceUrl}{screenName}&count=20", null))
                .ReturnsAsync(jsonResponse);

            jsonDeserializerMock
                .Setup(x => x.Deserialize<ICollection<TwitterAccountApiDto>>(jsonResponse))
                .Returns(expectedResult);

            var twitterService = new TwitterService(apiServiceMock.Object, jsonDeserializerMock.Object);

            //Act
            var actualResult = await twitterService.SearchUsersByScreenName(screenName);

            //Assert
            Assert.IsNotNull(actualResult);
            Assert.IsInstanceOfType(actualResult, typeof(ICollection<TwitterAccountApiDto>));
        }

        [TestMethod]
        public async Task ReturnCollectionOf1TwitterAccount_WhenInvokedWithValidParameter()
        {
            //Arrange
            var apiServiceMock = new Mock<IOAuthCreationService>();
            var jsonDeserializerMock = new Mock<IJsonObjectDeserializer>();

            var screenName = "Grigor";
            var resourceUrl = "https://api.twitter.com/1.1/users/search.json?q=";
            var jsonResponse = "JsonResponse";
            var twitterAccount = new TwitterAccountApiDto() { Name = "Marto Stamatov" };
            var expectedResult = new List<TwitterAccountApiDto>
            {
                twitterAccount
            };

            apiServiceMock
                .Setup(x => x.GetTwitterApiCallData($"{resourceUrl}{screenName}&count=20", null))
                .ReturnsAsync(jsonResponse);

            jsonDeserializerMock
                .Setup(x => x.Deserialize<ICollection<TwitterAccountApiDto>>(jsonResponse))
                .Returns(expectedResult);

            var twitterService = new TwitterService(apiServiceMock.Object, jsonDeserializerMock.Object);

            //Act
            var actualResult = await twitterService.SearchUsersByScreenName(screenName);

            //Assert
            Assert.AreEqual(actualResult.Count, 1);
        }

        [TestMethod]
        public async Task CallGetTwitterApiCallDataMethodOnce_WhenInvokedWithValidParameters()
        {
            //Arrange
            var apiServiceMock = new Mock<IOAuthCreationService>();
            var jsonDeserializerMock = new Mock<IJsonObjectDeserializer>();

            string screenName = "Grigor";
            var resourceUrl = "https://api.twitter.com/1.1/users/search.json?q=";
            var jsonResponse = "JsonResponse";
            var twitterAccount = new TwitterAccountApiDto() { Name = "Marto Stamatov" };
            var expectedResult = new List<TwitterAccountApiDto>
            {
                twitterAccount
            };

            apiServiceMock
                .Setup(x => x.GetTwitterApiCallData($"{resourceUrl}{screenName}&count=20", null))
                .ReturnsAsync(jsonResponse);

            jsonDeserializerMock
                .Setup(x => x.Deserialize<ICollection<TwitterAccountApiDto>>(jsonResponse))
                .Returns(expectedResult);

            var twitterService = new TwitterService(apiServiceMock.Object, jsonDeserializerMock.Object);

            //Act
            var actualResult = await twitterService.SearchUsersByScreenName(screenName);

            //Assert
            apiServiceMock.Verify(x => x.GetTwitterApiCallData($"{resourceUrl}{screenName}&count=20", null), Times.Once);
        }

        [TestMethod]
        public async Task CallGetJsonDeserializerMethodOnce_WhenInvokedWithValidParameters()
        {
            //Arrange
            var apiServiceMock = new Mock<IOAuthCreationService>();
            var jsonDeserializerMock = new Mock<IJsonObjectDeserializer>();

            string screenName = "Grigor";
            var resourceUrl = "https://api.twitter.com/1.1/users/search.json?q=";
            var jsonResponse = "JsonResponse";
            var twitterAccount = new TwitterAccountApiDto() { Name = "Marto Stamatov" };
            var expectedResult = new List<TwitterAccountApiDto>
            {
                twitterAccount
            };

            apiServiceMock
                .Setup(x => x.GetTwitterApiCallData($"{resourceUrl}{screenName}&count=20", null))
                .ReturnsAsync(jsonResponse);

            jsonDeserializerMock
                .Setup(x => x.Deserialize<ICollection<TwitterAccountApiDto>>(jsonResponse))
                .Returns(expectedResult);

            var twitterService = new TwitterService(apiServiceMock.Object, jsonDeserializerMock.Object);

            //Act
            var actualResult = await twitterService.SearchUsersByScreenName(screenName);

            //Assert
            jsonDeserializerMock.Verify(x => x.Deserialize<ICollection<TwitterAccountApiDto>>(jsonResponse), Times.Once);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithNullScreenNameInvalidParameter()
        {
            //Arrange
            var apiServiceMock = new Mock<IOAuthCreationService>();
            var jsonDeserializerMock = new Mock<IJsonObjectDeserializer>();

            string screenName = null;
            var resourceUrl = "https://api.twitter.com/1.1/users/search.json?q=";
            var jsonResponse = "JsonResponse";
            var twitterAccount = new TwitterAccountApiDto() { Name = "Marto Stamatov" };
            var expectedResult = new List<TwitterAccountApiDto>
            {
                twitterAccount
            };

            apiServiceMock
                .Setup(x => x.GetTwitterApiCallData($"{resourceUrl}{screenName}&count=20", null))
                .ReturnsAsync(jsonResponse);

            jsonDeserializerMock
                .Setup(x => x.Deserialize<ICollection<TwitterAccountApiDto>>(jsonResponse))
                .Returns(expectedResult);

            var twitterService = new TwitterService(apiServiceMock.Object, jsonDeserializerMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await twitterService.SearchUsersByScreenName(screenName));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithEmptyScreenNameInvalidParameters()
        {
            //Arrange
            var apiServiceMock = new Mock<IOAuthCreationService>();
            var jsonDeserializerMock = new Mock<IJsonObjectDeserializer>();

            string screenName = string.Empty;
            var resourceUrl = "https://api.twitter.com/1.1/users/search.json?q=";
            var jsonResponse = "JsonResponse";
            var twitterAccount = new TwitterAccountApiDto() { Name = "Marto Stamatov" };
            var expectedResult = new List<TwitterAccountApiDto>
            {
                twitterAccount
            };

            apiServiceMock
                .Setup(x => x.GetTwitterApiCallData($"{resourceUrl}{screenName}&count=20", null))
                .ReturnsAsync(jsonResponse);

            jsonDeserializerMock
                .Setup(x => x.Deserialize<ICollection<TwitterAccountApiDto>>(jsonResponse))
                .Returns(expectedResult);

            var twitterService = new TwitterService(apiServiceMock.Object, jsonDeserializerMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentException>(async () => await twitterService.SearchUsersByScreenName(screenName));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenJsonResponseIsNull()
        {
            //Arrange
            var apiServiceMock = new Mock<IOAuthCreationService>();
            var jsonDeserializerMock = new Mock<IJsonObjectDeserializer>();

            string screenName = "Grigor";
            var resourceUrl = "https://api.twitter.com/1.1/users/search.json?q=";
            string jsonResponse = null;
            var twitterAccount = new TwitterAccountApiDto() { Name = "Marto Stamatov" };
            var expectedResult = new List<TwitterAccountApiDto>
            {
                twitterAccount
            };

            apiServiceMock
                .Setup(x => x.GetTwitterApiCallData($"{resourceUrl}{screenName}&count=20", null))
                .ReturnsAsync(jsonResponse);

            jsonDeserializerMock
                .Setup(x => x.Deserialize<ICollection<TwitterAccountApiDto>>(jsonResponse))
                .Returns(expectedResult);

            var twitterService = new TwitterService(apiServiceMock.Object, jsonDeserializerMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await twitterService.SearchUsersByScreenName(screenName));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenJsonResponseIsEmptyString()
        {
            //Arrange
            var apiServiceMock = new Mock<IOAuthCreationService>();
            var jsonDeserializerMock = new Mock<IJsonObjectDeserializer>();

            string screenName = "Grigor";
            var resourceUrl = "https://api.twitter.com/1.1/users/search.json?q=";
            var jsonResponse = string.Empty;
            var twitterAccount = new TwitterAccountApiDto() { Name = "Marto Stamatov" };
            var expectedResult = new List<TwitterAccountApiDto>
            {
                twitterAccount
            };

            apiServiceMock
                .Setup(x => x.GetTwitterApiCallData($"{resourceUrl}{screenName}&count=20", null))
                .ReturnsAsync(jsonResponse);

            jsonDeserializerMock
                .Setup(x => x.Deserialize<ICollection<TwitterAccountApiDto>>(jsonResponse))
                .Returns(expectedResult);

            var twitterService = new TwitterService(apiServiceMock.Object, jsonDeserializerMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentException>(async () => await twitterService.SearchUsersByScreenName(screenName));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenJsonDeserializerReturnsNull()
        {
            //Arrange
            var apiServiceMock = new Mock<IOAuthCreationService>();
            var jsonDeserializerMock = new Mock<IJsonObjectDeserializer>();

            string screenName = "Grigor";
            var resourceUrl = "https://api.twitter.com/1.1/users/search.json?q=";
            var jsonResponse = "JsonResponse";
            ICollection<TwitterAccountApiDto> expectedResult = null;

            apiServiceMock
                .Setup(x => x.GetTwitterApiCallData($"{resourceUrl}{screenName}&count=20", null))
                .ReturnsAsync(jsonResponse);

            jsonDeserializerMock
                .Setup(x => x.Deserialize<ICollection<TwitterAccountApiDto>>(jsonResponse))
                .Returns(expectedResult);

            var twitterService = new TwitterService(apiServiceMock.Object, jsonDeserializerMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentException>(async () => await twitterService.SearchUsersByScreenName(screenName));
        }
    }
}
