
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
    public class PatchUserTests : TestBase
    {
        [Test]
        public void PatchUser_ShouldReturn200_AndUpdateJob()
        {
            PatchUserRequest body = new PatchUserRequest{ 
                job = "Lead QA" 
            };
            RestResponse response = client.PatchUser(UserTestData.ValidUserId, body);
            PatchUserResponse result = JsonSerializer.Deserialize<PatchUserResponse>(response.Content!)!;

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(result.job, Is.EqualTo("Lead QA"));
            Assert.That(result.updatedAt, Is.Not.Null.And.Not.Empty);
        }
    }
}