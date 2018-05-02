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
    public class GetUsersTimeLine_Should
    {
        [TestMethod]
        public async Task ReturnCollectionOfTwitterAcounts_WhenInvokedWithValidParameter()
        {
            //Arrange
            var apiServiceMock = new Mock<IOAuthCreationService>();
            var jsonDeserializerMock = new Mock<IJsonObjectDeserializer>();

            var userId = "1905";
            var resourceUrl = "https://api.twitter.com/1.1/statuses/user_timeline.json?user_id=";
            var jsonResponse = "JsonResponse";
            var tweet = new TweetApiDto() { Id = "1905", TweetAuthor = "Marto Stamatov", TweetUrl = "SomeUrl" };
            
            ICollection<TweetApiDto> tweets = new List<TweetApiDto>
            {
                tweet
            };

            apiServiceMock
                .Setup(x => x.GetTwitterApiCallData($"{resourceUrl}{userId}&count=20", null))
                .ReturnsAsync(jsonResponse);

            jsonDeserializerMock
                .Setup(x => x.Deserialize<ICollection<TweetApiDto>>(jsonResponse))
                .Returns(tweets);

            var twitterService = new TwitterService(apiServiceMock.Object, jsonDeserializerMock.Object);

            //Act
            var actualResult = await twitterService.GetUsersTimeline(userId);

            //Assert
            Assert.IsNotNull(actualResult);
            Assert.IsInstanceOfType(actualResult, typeof(ICollection<TweetApiDto>));
        }

        [TestMethod]
        public async Task ReturnCollectionOf1tweet_WhenInvokedWithValidParameter()
        {
            //Arrange
            var apiServiceMock = new Mock<IOAuthCreationService>();
            var jsonDeserializerMock = new Mock<IJsonObjectDeserializer>();

            var userId = "1905";
            var resourceUrl = "https://api.twitter.com/1.1/statuses/user_timeline.json?user_id=";
            var jsonResponse = "JsonResponse";
            var tweet = new TweetApiDto() { Id = "1905", TweetAuthor = "Marto Stamatov", TweetUrl = "SomeUrl" };
            
            ICollection<TweetApiDto> tweets = new List<TweetApiDto>
            {
                tweet
            };

            apiServiceMock
                .Setup(x => x.GetTwitterApiCallData($"{resourceUrl}{userId}&count=20", null))
                .ReturnsAsync(jsonResponse);

            jsonDeserializerMock
                .Setup(x => x.Deserialize<ICollection<TweetApiDto>>(jsonResponse))
                .Returns(tweets);

            var twitterService = new TwitterService(apiServiceMock.Object, jsonDeserializerMock.Object);

            //Act
            var actualResult = await twitterService.GetUsersTimeline(userId);

            //Assert
            Assert.AreEqual(actualResult.Count, 1);
        }


        [TestMethod]
        public async Task ReturnCollectionWithTweetUrlEqualToExpectedOne_WhenInvokedWithValidParameter()
        {
            //Arrange
            var apiServiceMock = new Mock<IOAuthCreationService>();
            var jsonDeserializerMock = new Mock<IJsonObjectDeserializer>();

            var userId = "1905";
            var resourceUrl = "https://api.twitter.com/1.1/statuses/user_timeline.json?user_id=";
            var jsonResponse = "JsonResponse";
            var tweet = new TweetApiDto() { Id = "1905", TweetAuthor = "Marto Stamatov", TweetUrl = "SomeUrl" };
            
            ICollection<TweetApiDto> tweets = new List<TweetApiDto>
            {
                tweet
            };

            apiServiceMock
                .Setup(x => x.GetTwitterApiCallData($"{resourceUrl}{userId}&count=20", null))
                .ReturnsAsync(jsonResponse);

            jsonDeserializerMock
                .Setup(x => x.Deserialize<ICollection<TweetApiDto>>(jsonResponse))
                .Returns(tweets);

            var twitterService = new TwitterService(apiServiceMock.Object, jsonDeserializerMock.Object);

            //Act
            var actualResult = await twitterService.GetUsersTimeline(userId);

            //Assert
            Assert.AreEqual(actualResult.FirstOrDefault().TweetUrl, tweet.TweetUrl);
        }

        [TestMethod]
        public async Task CallGetTwitterApiCallDataMethodOnce_WhenInvokedWithValidParameters()
        {
            //Arrange
            var apiServiceMock = new Mock<IOAuthCreationService>();
            var jsonDeserializerMock = new Mock<IJsonObjectDeserializer>();

            var userId = "1905";
            var resourceUrl = "https://api.twitter.com/1.1/statuses/user_timeline.json?user_id=";
            var jsonResponse = "JsonResponse";
            var tweet = new TweetApiDto() { Id = "1905", TweetAuthor = "Marto Stamatov", TweetUrl = "SomeUrl" };
            
            ICollection<TweetApiDto> tweets = new List<TweetApiDto>
            {
                tweet
            };

            apiServiceMock
                .Setup(x => x.GetTwitterApiCallData($"{resourceUrl}{userId}&count=20", null))
                .ReturnsAsync(jsonResponse);

            jsonDeserializerMock
                .Setup(x => x.Deserialize<ICollection<TweetApiDto>>(jsonResponse))
                .Returns(tweets);

            var twitterService = new TwitterService(apiServiceMock.Object, jsonDeserializerMock.Object);

            //Act
            var actualResult = await twitterService.GetUsersTimeline(userId);

            //Assert
            apiServiceMock.Verify(x => x.GetTwitterApiCallData($"{resourceUrl}{userId}&count=20", null), Times.Once);
        }

        [TestMethod]
        public async Task CallGetJsonDeserializerMethodOnce_WhenInvokedWithValidParameters()
        {
            //Arrange
            var apiServiceMock = new Mock<IOAuthCreationService>();
            var jsonDeserializerMock = new Mock<IJsonObjectDeserializer>();

            var userId = "1905";
            var resourceUrl = "https://api.twitter.com/1.1/statuses/user_timeline.json?user_id=";
            var jsonResponse = "JsonResponse";
            var tweet = new TweetApiDto() { Id = "1905", TweetAuthor = "Marto Stamatov", TweetUrl = "SomeUrl" };
            
            ICollection<TweetApiDto> tweets = new List<TweetApiDto>
            {
                tweet
            };

            apiServiceMock
                .Setup(x => x.GetTwitterApiCallData($"{resourceUrl}{userId}&count=20", null))
                .ReturnsAsync(jsonResponse);

            jsonDeserializerMock
                .Setup(x => x.Deserialize<ICollection<TweetApiDto>>(jsonResponse))
                .Returns(tweets);

            var twitterService = new TwitterService(apiServiceMock.Object, jsonDeserializerMock.Object);

            //Act
            var actualResult = await twitterService.GetUsersTimeline(userId);

            //Assert
            jsonDeserializerMock.Verify(x => x.Deserialize<ICollection<TweetApiDto>>(jsonResponse), Times.Once);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithNulluserIdInvalidParameter()
        {
            //Arrange
            var apiServiceMock = new Mock<IOAuthCreationService>();
            var jsonDeserializerMock = new Mock<IJsonObjectDeserializer>();

            string userId = null;
            var resourceUrl = "https://api.twitter.com/1.1/statuses/user_timeline.json?user_id=";
            var jsonResponse = "JsonResponse";
            var tweet = new TweetApiDto() { Id = "1905", TweetAuthor = "Marto Stamatov", TweetUrl = "SomeUrl" };
            
            ICollection<TweetApiDto> tweets = new List<TweetApiDto>
            {
                tweet
            };

            apiServiceMock
                .Setup(x => x.GetTwitterApiCallData($"{resourceUrl}{userId}&count=20", null))
                .ReturnsAsync(jsonResponse);

            jsonDeserializerMock
                .Setup(x => x.Deserialize<ICollection<TweetApiDto>>(jsonResponse))
                .Returns(tweets);

            var twitterService = new TwitterService(apiServiceMock.Object, jsonDeserializerMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await twitterService.GetUsersTimeline(userId));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithEmptyuserIdInvalidParameters()
        {
            //Arrange
            var apiServiceMock = new Mock<IOAuthCreationService>();
            var jsonDeserializerMock = new Mock<IJsonObjectDeserializer>();

            string userId = string.Empty;
            var resourceUrl = "https://api.twitter.com/1.1/statuses/user_timeline.json?user_id=";
            var jsonResponse = "JsonResponse";
            var tweet = new TweetApiDto() { Id = "1905", TweetAuthor = "Marto Stamatov", TweetUrl = "SomeUrl" };
            
            ICollection<TweetApiDto> tweets = new List<TweetApiDto>
            {
                tweet
            };

            apiServiceMock
                .Setup(x => x.GetTwitterApiCallData($"{resourceUrl}{userId}&count=20", null))
                .ReturnsAsync(jsonResponse);

            jsonDeserializerMock
                .Setup(x => x.Deserialize<ICollection<TweetApiDto>>(jsonResponse))
                .Returns(tweets);

            var twitterService = new TwitterService(apiServiceMock.Object, jsonDeserializerMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentException>(async () => await twitterService.GetUsersTimeline(userId));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenJsonResponseIsNull()
        {
            //Arrange
            var apiServiceMock = new Mock<IOAuthCreationService>();
            var jsonDeserializerMock = new Mock<IJsonObjectDeserializer>();

            string userId = "1905";
            var resourceUrl = "https://api.twitter.com/1.1/statuses/user_timeline.json?user_id=";
            string jsonResponse = null;
            var tweet = new TweetApiDto() { Id = "1905", TweetAuthor = "Marto Stamatov", TweetUrl = "SomeUrl" };
            
            ICollection<TweetApiDto> tweets = new List<TweetApiDto>
            {
                tweet
            };

            apiServiceMock
                .Setup(x => x.GetTwitterApiCallData($"{resourceUrl}{userId}&count=20", null))
                .ReturnsAsync(jsonResponse);

            jsonDeserializerMock
                .Setup(x => x.Deserialize<ICollection<TweetApiDto>>(jsonResponse))
                .Returns(tweets);

            var twitterService = new TwitterService(apiServiceMock.Object, jsonDeserializerMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await twitterService.GetUsersTimeline(userId));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenJsonResponseIsEmptyString()
        {
            //Arrange
            var apiServiceMock = new Mock<IOAuthCreationService>();
            var jsonDeserializerMock = new Mock<IJsonObjectDeserializer>();

            string userId = "1905";
            var resourceUrl = "https://api.twitter.com/1.1/statuses/user_timeline.json?user_id=";
            string jsonResponse = string.Empty;
            var tweet = new TweetApiDto() { Id = "1905", TweetAuthor = "Marto Stamatov", TweetUrl = "SomeUrl" };
            
            ICollection<TweetApiDto> tweets = new List<TweetApiDto>
            {
                tweet
            };

            apiServiceMock
                .Setup(x => x.GetTwitterApiCallData($"{resourceUrl}{userId}&count=20", null))
                .ReturnsAsync(jsonResponse);

            jsonDeserializerMock
                .Setup(x => x.Deserialize<ICollection<TweetApiDto>>(jsonResponse))
                .Returns(tweets);

            var twitterService = new TwitterService(apiServiceMock.Object, jsonDeserializerMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentException>(async () => await twitterService.GetUsersTimeline(userId));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenJsonDeserializerReturnsNull()
        {
            //Arrange
            var apiServiceMock = new Mock<IOAuthCreationService>();
            var jsonDeserializerMock = new Mock<IJsonObjectDeserializer>();

            string userId = "1905";
            var resourceUrl = "https://api.twitter.com/1.1/statuses/user_timeline.json?user_id=";
            var jsonResponse = "JsonResponse";
            var tweet = new TweetApiDto() { Id = "1905", TweetAuthor = "Marto Stamatov", TweetUrl = "SomeUrl" };
            
            ICollection<TweetApiDto> tweets = null;

            apiServiceMock
                .Setup(x => x.GetTwitterApiCallData($"{resourceUrl}{userId}&count=20", null))
                .ReturnsAsync(jsonResponse);

            jsonDeserializerMock
                .Setup(x => x.Deserialize<ICollection<TweetApiDto>>(jsonResponse))
                .Returns(tweets);

            var twitterService = new TwitterService(apiServiceMock.Object, jsonDeserializerMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentException>(async () => await twitterService.GetUsersTimeline(userId));
        }
    }
}
