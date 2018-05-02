using BackUpSystem.DTO;
using BackUpSystem.DTO.ApiDtos;
using BackUpSystem.Services.Auth.Contracts;
using BackUpSystem.Services.Data;
using BackUpSystem.Utilities.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackUpSytem.Services.Data.UnitTests.TwitterServiceTests
{
    [TestClass]
    public class GetTimeLine_Should
    {
        [TestMethod]
        public async Task ReturnCollectionOfTwitterAcounts_WhenInvokedWithValidParameter()
        {
            //Arrange
            var apiServiceMock = new Mock<IOAuthCreationService>();
            var jsonDeserializerMock = new Mock<IJsonObjectDeserializer>();

            var favUsersIds = "100,545,6969";
            var resourceUrl = "https://api.twitter.com/1.1/users/lookup.json?user_id=";
            var jsonResponse = "JsonResponse";
            var status = new TweetApiDto() { Id = "1905", TweetAuthor = "Marto Stamatov", TweetUrl = "SomeUrl" };
            var twitterAccount = new TwitterAccountApiDto() { UserName = "Marto Stamatov", CurrentStatus = status };
            ICollection<TwitterAccountApiDto> twitterAccounts = new List<TwitterAccountApiDto>
            {
                twitterAccount
            };

            apiServiceMock
                .Setup(x => x.GetTwitterApiCallData(resourceUrl + favUsersIds, null))
                .ReturnsAsync(jsonResponse);

            jsonDeserializerMock
                .Setup(x => x.Deserialize<ICollection<TwitterAccountApiDto>>(jsonResponse))
                .Returns(twitterAccounts);

            var expectedResult = twitterAccounts
                .Select(u => u.CurrentStatus)
                .OrderByDescending(t => t.CreatedAt)
                .ToList();

            var twitterService = new TwitterService(apiServiceMock.Object, jsonDeserializerMock.Object);

            //Act
            var actualResult = await twitterService.GetTimeline(favUsersIds);

            //Assert
            Assert.IsNotNull(actualResult);
            Assert.IsInstanceOfType(actualResult, typeof(ICollection<TweetApiDto>));
        }

        [TestMethod]
        public async Task ReturnCollectionOf1TwitterAccount_WhenInvokedWithValidParameter()
        {
            //Arrange
            var apiServiceMock = new Mock<IOAuthCreationService>();
            var jsonDeserializerMock = new Mock<IJsonObjectDeserializer>();

            var favUsersIds = "100,545,6969";
            var resourceUrl = "https://api.twitter.com/1.1/users/lookup.json?user_id=";
            var jsonResponse = "JsonResponse";
            var status = new TweetApiDto() { Id = "1905", TweetAuthor = "Marto Stamatov", TweetUrl = "SomeUrl" };
            var twitterAccount = new TwitterAccountApiDto() { UserName = "Marto Stamatov", CurrentStatus = status };
            ICollection<TwitterAccountApiDto> twitterAccounts = new List<TwitterAccountApiDto>
            {
                twitterAccount
            };

            apiServiceMock
                .Setup(x => x.GetTwitterApiCallData(resourceUrl + favUsersIds, null))
                .ReturnsAsync(jsonResponse);

            jsonDeserializerMock
                .Setup(x => x.Deserialize<ICollection<TwitterAccountApiDto>>(jsonResponse))
                .Returns(twitterAccounts);

            var expectedResult = twitterAccounts
                .Select(u => u.CurrentStatus)
                .OrderByDescending(t => t.CreatedAt)
                .ToList();

            var twitterService = new TwitterService(apiServiceMock.Object, jsonDeserializerMock.Object);

            //Act
            var actualResult = await twitterService.GetTimeline(favUsersIds);

            //Assert
            Assert.AreEqual(actualResult.Count, 1);
        }


        [TestMethod]
        public async Task ReturnCollectionWithTweetUrlEqualToExpectedOne_WhenInvokedWithValidParameter()
        {
            //Arrange
            var apiServiceMock = new Mock<IOAuthCreationService>();
            var jsonDeserializerMock = new Mock<IJsonObjectDeserializer>();

            var favUsersIds = "100,545,6969";
            var resourceUrl = "https://api.twitter.com/1.1/users/lookup.json?user_id=";
            var jsonResponse = "JsonResponse";
            var status = new TweetApiDto() { Id = "1905", TweetAuthor = "Marto Stamatov", TweetUrl = "SomeUrl" };
            var twitterAccount = new TwitterAccountApiDto() { UserName = "Marto Stamatov", CurrentStatus = status };
            ICollection<TwitterAccountApiDto> twitterAccounts = new List<TwitterAccountApiDto>
            {
                twitterAccount
            };

            apiServiceMock
                .Setup(x => x.GetTwitterApiCallData(resourceUrl + favUsersIds, null))
                .ReturnsAsync(jsonResponse);

            jsonDeserializerMock
                .Setup(x => x.Deserialize<ICollection<TwitterAccountApiDto>>(jsonResponse))
                .Returns(twitterAccounts);

            var expectedResult = twitterAccounts
                .Select(u => u.CurrentStatus)
                .OrderByDescending(t => t.CreatedAt)
                .ToList();

            var twitterService = new TwitterService(apiServiceMock.Object, jsonDeserializerMock.Object);

            //Act
            var actualResult = await twitterService.GetTimeline(favUsersIds);

            //Assert
            Assert.AreEqual(actualResult.FirstOrDefault().TweetUrl, status.TweetUrl);
        }

        [TestMethod]
        public async Task CallGetTwitterApiCallDataMethodOnce_WhenInvokedWithValidParameters()
        {
            //Arrange
            var apiServiceMock = new Mock<IOAuthCreationService>();
            var jsonDeserializerMock = new Mock<IJsonObjectDeserializer>();

            var favUsersIds = "100,545,6969";
            var resourceUrl = "https://api.twitter.com/1.1/users/lookup.json?user_id=";
            var jsonResponse = "JsonResponse";
            var status = new TweetApiDto() { Id = "1905", TweetAuthor = "Marto Stamatov", TweetUrl = "SomeUrl" };
            var twitterAccount = new TwitterAccountApiDto() { UserName = "Marto Stamatov", CurrentStatus = status };
            ICollection<TwitterAccountApiDto> twitterAccounts = new List<TwitterAccountApiDto>
            {
                twitterAccount
            };

            apiServiceMock
                .Setup(x => x.GetTwitterApiCallData(resourceUrl + favUsersIds, null))
                .ReturnsAsync(jsonResponse);

            jsonDeserializerMock
                .Setup(x => x.Deserialize<ICollection<TwitterAccountApiDto>>(jsonResponse))
                .Returns(twitterAccounts);

            var expectedResult = twitterAccounts
                .Select(u => u.CurrentStatus)
                .OrderByDescending(t => t.CreatedAt)
                .ToList();

            var twitterService = new TwitterService(apiServiceMock.Object, jsonDeserializerMock.Object);

            //Act
            var actualResult = await twitterService.GetTimeline(favUsersIds);

            //Assert
            apiServiceMock.Verify(x => x.GetTwitterApiCallData(resourceUrl + favUsersIds, null), Times.Once);
        }

        [TestMethod]
        public async Task CallGetJsonDeserializerMethodOnce_WhenInvokedWithValidParameters()
        {
            //Arrange
            var apiServiceMock = new Mock<IOAuthCreationService>();
            var jsonDeserializerMock = new Mock<IJsonObjectDeserializer>();

            var favUsersIds = "100,545,6969";
            var resourceUrl = "https://api.twitter.com/1.1/users/lookup.json?user_id=";
            var jsonResponse = "JsonResponse";
            var status = new TweetApiDto() { Id = "1905", TweetAuthor = "Marto Stamatov", TweetUrl = "SomeUrl" };
            var twitterAccount = new TwitterAccountApiDto() { UserName = "Marto Stamatov", CurrentStatus = status };
            ICollection<TwitterAccountApiDto> twitterAccounts = new List<TwitterAccountApiDto>
            {
                twitterAccount
            };

            apiServiceMock
                .Setup(x => x.GetTwitterApiCallData(resourceUrl + favUsersIds, null))
                .ReturnsAsync(jsonResponse);

            jsonDeserializerMock
                .Setup(x => x.Deserialize<ICollection<TwitterAccountApiDto>>(jsonResponse))
                .Returns(twitterAccounts);

            var expectedResult = twitterAccounts
                .Select(u => u.CurrentStatus)
                .OrderByDescending(t => t.CreatedAt)
                .ToList();

            var twitterService = new TwitterService(apiServiceMock.Object, jsonDeserializerMock.Object);

            //Act
            var actualResult = await twitterService.GetTimeline(favUsersIds);

            //Assert
            jsonDeserializerMock.Verify(x => x.Deserialize<ICollection<TwitterAccountApiDto>>(jsonResponse), Times.Once);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithNullfavUsersIdsInvalidParameter()
        {
            //Arrange
            var apiServiceMock = new Mock<IOAuthCreationService>();
            var jsonDeserializerMock = new Mock<IJsonObjectDeserializer>();

            string favUsersIds = null;
            var resourceUrl = "https://api.twitter.com/1.1/users/lookup.json?user_id=";
            var jsonResponse = "JsonResponse";
            var status = new TweetApiDto() { Id = "1905", TweetAuthor = "Marto Stamatov", TweetUrl = "SomeUrl" };
            var twitterAccount = new TwitterAccountApiDto() { UserName = "Marto Stamatov", CurrentStatus = status };
            ICollection<TwitterAccountApiDto> twitterAccounts = new List<TwitterAccountApiDto>
            {
                twitterAccount
            };

            apiServiceMock
                .Setup(x => x.GetTwitterApiCallData(resourceUrl + favUsersIds, null))
                .ReturnsAsync(jsonResponse);

            jsonDeserializerMock
                .Setup(x => x.Deserialize<ICollection<TwitterAccountApiDto>>(jsonResponse))
                .Returns(twitterAccounts);

            var expectedResult = twitterAccounts
                .Select(u => u.CurrentStatus)
                .OrderByDescending(t => t.CreatedAt)
                .ToList();

            var twitterService = new TwitterService(apiServiceMock.Object, jsonDeserializerMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await twitterService.GetTimeline(favUsersIds));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithEmptyfavUsersIdsInvalidParameters()
        {
            //Arrange
            var apiServiceMock = new Mock<IOAuthCreationService>();
            var jsonDeserializerMock = new Mock<IJsonObjectDeserializer>();

            string favUsersIds = string.Empty;
            var resourceUrl = "https://api.twitter.com/1.1/users/lookup.json?user_id=";
            var jsonResponse = "JsonResponse";
            var status = new TweetApiDto() { Id = "1905", TweetAuthor = "Marto Stamatov", TweetUrl = "SomeUrl" };
            var twitterAccount = new TwitterAccountApiDto() { UserName = "Marto Stamatov", CurrentStatus = status };
            ICollection<TwitterAccountApiDto> twitterAccounts = new List<TwitterAccountApiDto>
            {
                twitterAccount
            };

            apiServiceMock
                .Setup(x => x.GetTwitterApiCallData(resourceUrl + favUsersIds, null))
                .ReturnsAsync(jsonResponse);

            jsonDeserializerMock
                .Setup(x => x.Deserialize<ICollection<TwitterAccountApiDto>>(jsonResponse))
                .Returns(twitterAccounts);

            var expectedResult = twitterAccounts
                .Select(u => u.CurrentStatus)
                .OrderByDescending(t => t.CreatedAt)
                .ToList();

            var twitterService = new TwitterService(apiServiceMock.Object, jsonDeserializerMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentException>(async () => await twitterService.GetTimeline(favUsersIds));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenJsonResponseIsNull()
        {
            //Arrange
            var apiServiceMock = new Mock<IOAuthCreationService>();
            var jsonDeserializerMock = new Mock<IJsonObjectDeserializer>();

            string favUsersIds = "100,545,6969";
            var resourceUrl = "https://api.twitter.com/1.1/users/lookup.json?user_id=";
            string jsonResponse = null;
            var status = new TweetApiDto() { Id = "1905", TweetAuthor = "Marto Stamatov", TweetUrl = "SomeUrl" };
            var twitterAccount = new TwitterAccountApiDto() { UserName = "Marto Stamatov", CurrentStatus = status };
            ICollection<TwitterAccountApiDto> twitterAccounts = new List<TwitterAccountApiDto>
            {
                twitterAccount
            };

            apiServiceMock
                .Setup(x => x.GetTwitterApiCallData(resourceUrl + favUsersIds, null))
                .ReturnsAsync(jsonResponse);

            jsonDeserializerMock
                .Setup(x => x.Deserialize<ICollection<TwitterAccountApiDto>>(jsonResponse))
                .Returns(twitterAccounts);

            var expectedResult = twitterAccounts
                .Select(u => u.CurrentStatus)
                .OrderByDescending(t => t.CreatedAt)
                .ToList();

            var twitterService = new TwitterService(apiServiceMock.Object, jsonDeserializerMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await twitterService.GetTimeline(favUsersIds));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenJsonResponseIsEmptyString()
        {
            //Arrange
            var apiServiceMock = new Mock<IOAuthCreationService>();
            var jsonDeserializerMock = new Mock<IJsonObjectDeserializer>();

            string favUsersIds = "100,545,6969";
            var resourceUrl = "https://api.twitter.com/1.1/users/lookup.json?user_id=";
            string jsonResponse = string.Empty;
            var status = new TweetApiDto() { Id = "1905", TweetAuthor = "Marto Stamatov", TweetUrl = "SomeUrl" };
            var twitterAccount = new TwitterAccountApiDto() { UserName = "Marto Stamatov", CurrentStatus = status };
            ICollection<TwitterAccountApiDto> twitterAccounts = new List<TwitterAccountApiDto>
            {
                twitterAccount
            };

            apiServiceMock
                .Setup(x => x.GetTwitterApiCallData(resourceUrl + favUsersIds, null))
                .ReturnsAsync(jsonResponse);

            jsonDeserializerMock
                .Setup(x => x.Deserialize<ICollection<TwitterAccountApiDto>>(jsonResponse))
                .Returns(twitterAccounts);

            var expectedResult = twitterAccounts
                .Select(u => u.CurrentStatus)
                .OrderByDescending(t => t.CreatedAt)
                .ToList();

            var twitterService = new TwitterService(apiServiceMock.Object, jsonDeserializerMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentException>(async () => await twitterService.GetTimeline(favUsersIds));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenJsonDeserializerReturnsNull()
        {
            //Arrange
            var apiServiceMock = new Mock<IOAuthCreationService>();
            var jsonDeserializerMock = new Mock<IJsonObjectDeserializer>();

            string favUsersIds = "100,545,6969";
            var resourceUrl = "https://api.twitter.com/1.1/users/lookup.json?user_id=";
            var jsonResponse = "JsonResponse";
            var status = new TweetApiDto() { Id = "1905", TweetAuthor = "Marto Stamatov", TweetUrl = "SomeUrl" };
            var twitterAccount = new TwitterAccountApiDto() { UserName = "Marto Stamatov", CurrentStatus = status };
            ICollection<TwitterAccountApiDto> twitterAccounts = null;

            apiServiceMock
                .Setup(x => x.GetTwitterApiCallData(resourceUrl + favUsersIds, null))
                .ReturnsAsync(jsonResponse);

            jsonDeserializerMock
                .Setup(x => x.Deserialize<ICollection<TwitterAccountApiDto>>(jsonResponse))
                .Returns(twitterAccounts);

            //var expectedResult = twitterAccounts
            //    .Select(u => u.CurrentStatus)
            //    .OrderByDescending(t => t.CreatedAt)
            //    .ToList();

            var twitterService = new TwitterService(apiServiceMock.Object, jsonDeserializerMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentException>(async () => await twitterService.GetTimeline(favUsersIds));
        }
    }
}
