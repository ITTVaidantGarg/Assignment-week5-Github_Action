using ReqresApiAutomation.Config;
using ReqresApiAutomation.RequestModels;
using RestSharp;

namespace ReqresApiAutomation.Clients
{
    public class ReqresClient
    {
        private readonly RestClient _client;

        public ReqresClient()
        {
            _client = new RestClient(TestConfig.BaseUrl);
        }

        private RestRequest CreateRequest(string resource, Method method)
        {
            RestRequest request = new RestRequest(resource, method);
            request.AddHeader("x-api-key", TestConfig.ApiKey);
            return request;
        }

        public RestResponse GetUser(int userId)
        {
            RestRequest request = CreateRequest($"/users/{userId}", Method.Get);
            return _client.Execute(request);
        }

        public RestResponse PostUser(CreateUserRequest body)
        {
            RestRequest request = CreateRequest("/users", Method.Post);
            request.AddJsonBody(body);
            return _client.Execute(request);
        }

        public RestResponse UpdateUser(int userId, UpdateUserRequest body)
        {
            RestRequest request = CreateRequest($"/users/{userId}", Method.Put);
            request.AddJsonBody(body);
            return _client.Execute(request);
        }

        public RestResponse PatchUser(int userId, PatchUserRequest body)
        {
            RestRequest request = CreateRequest($"/users/{userId}", Method.Patch);
            request.AddJsonBody(body);
            return _client.Execute(request);
        }

        public RestResponse DeleteUser(int userId)
        {
            RestRequest request = CreateRequest($"/users/{userId}", Method.Delete);
            return _client.Execute(request);
        }
    }
}
