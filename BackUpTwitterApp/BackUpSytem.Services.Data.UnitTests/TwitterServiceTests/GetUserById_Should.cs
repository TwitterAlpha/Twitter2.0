using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackUpSytem.Services.Data.UnitTests.TwitterServiceTests
{
    [TestClass]
    public class GetUserById_Should
    {
        [TestMethod]
        public void GetUser_WhenInvokedWithValidParameter()
        {
            //Arrange
            var authCreationServiceMock = new Mock<IOAuthCreationService>();
            var jsonDeserializerMock = new Mock<IJsonObjectDeserializer>();

            //Act
            var twitterService = new TwitterService(authCreationServiceMock.Object, jsonDeserializerMock.Object);

        }
    }
}
