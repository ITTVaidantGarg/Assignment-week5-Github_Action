using ReqresApiAutomation.TestData;
using ReqresApiAutomation.Base;
using RestSharp;
using System.Net;

namespace ReqresApiAutomation.Tests
{
    [TestFixture]
    public class DeleteUserTests : TestBase
    {
      
        [Test]
        public void DeleteUser_ShouldReturn204_WithEmptyBody()
        {
            RestResponse response = client.DeleteUser(UserTestData.ValidUserId);

            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent),
                    "The API should return status 204 (No Content).");

                Assert.That(string.IsNullOrEmpty(response.Content), Is.True,
                    "The response body should be empty for a 204 status.");
            });
        }
    }
}