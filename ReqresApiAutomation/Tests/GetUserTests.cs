using NUnit.Framework;
using ReqresApiAutomation.Base;
using ReqresApiAutomation.ResponseModels;
using ReqresApiAutomation.TestData;
using RestSharp;
using System.Net;
using System.Text.Json;

namespace ReqresApiAutomation.Tests
{
    public class GetUserTests : TestBase
    {
        [Test]
        public void GetUser_ShouldReturn200_WithValidSchema()
        {
            RestResponse response = client.GetUser(UserTestData.ValidUserId);
            GetUserResponse result = JsonSerializer.Deserialize<GetUserResponse>(response.Content!)!;


            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.ContentType, Does.Contain("application/json"));

            Assert.That(result.data, Is.Not.Null);
            Assert.That(result.support, Is.Not.Null);

            Assert.That(result.data.id, Is.TypeOf<int>());
            Assert.That(result.data.email, Is.Not.Null.And.Not.Empty);
            Assert.That(result.data.first_name, Is.Not.Null.And.Not.Empty);
            Assert.That(result.data.last_name, Is.Not.Null.And.Not.Empty);
        }
    }
}
