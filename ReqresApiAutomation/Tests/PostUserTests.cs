using NUnit.Framework;
using ReqresApiAutomation.Base;
using ReqresApiAutomation.RequestModels;
using ReqresApiAutomation.ResponseModels;
using RestSharp;
using System.Net;
using System.Text.Json;

namespace ReqresApiAutomation.Tests
{
    public class PostUserTests : TestBase
    {
        [Test]
        public void CreateUser_ShouldReturn201_WithCorrectResponse()
        {
            CreateUserRequest body = new CreateUserRequest
            {
                name = "Vaidant",
                job = "QA Engineer"
            };
            RestResponse response = client.PostUser(body);
            CreateUserResponse result = JsonSerializer.Deserialize<CreateUserResponse>(response.Content!)!;

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
            Assert.That(result.name, Is.EqualTo("Vaidant"));
            Assert.That(result.job, Is.EqualTo("QA Engineer"));
            Assert.That(result.id, Is.Not.Null.And.Not.Empty);
            Assert.That(result.createdAt, Is.Not.Null.And.Not.Empty);
        }
    }
}
