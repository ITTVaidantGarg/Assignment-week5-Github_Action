

using NUnit.Framework;
using ReqresApiAutomation.Base;
using ReqresApiAutomation.RequestModels;
using ReqresApiAutomation.ResponseModels;
using ReqresApiAutomation.TestData;
using RestSharp;
using System.Net;
using System.Text.Json;

namespace ReqresApiAutomation.Tests
{
    public class PutUserTests : TestBase
    {
        [Test]
        public void UpdateUser_ShouldReturn200()
        {
            UpdateUserRequest body = new UpdateUserRequest
            {
                name = "Vaidant Garg",
                job = "Senior QA"
            };
            RestResponse response = client.UpdateUser(UserTestData.ValidUserId, body);
            UpdateUserResponse result = JsonSerializer.Deserialize<UpdateUserResponse>(response.Content!)!;

            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(result.name, Is.EqualTo("Vaidant Garg"));
                Assert.That(result.job, Is.EqualTo("Senior QA"));
                Assert.That(result.updatedAt, Is.Not.Null.And.Not.Empty);
            });
        }
    }
}