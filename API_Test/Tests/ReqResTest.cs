using API_Test.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace API_Test
{
    [TestClass]
    public class ReqResTest
    {
        // USING SAMPLE API HERE: https://reqres.in/

        // RestClient

        RestClient restClient = new RestClient(new RestClientOptions
        {
            BaseUrl = new Uri("https://reqres.in/")
        });

        private string jsonBody;

        [TestMethod]
        public void CreateUser()
        {
            // POST on the auth
            var authRequest = new RestRequest("/api/users");
            authRequest.AddJsonBody(new { name = "Adam", job = "Tester" });

            var authResponse = restClient.Post(authRequest);
            var statusCode = authResponse.StatusCode;
            statusCode.Should().Be(AssertHelper.StatusIs(201));
        }

        [TestMethod]
        public void GetUserList()
        {

            // GET specific user
            var authResponse = restClient.Get(new RestRequest("api/users?page=2"));

            // Deserialize the Token
            //var token = authResponse
            var statusCode = authResponse.StatusCode;
            statusCode.Should().Be((System.Net.HttpStatusCode)200);

        }

        [TestMethod]
        public void GetSpecificUser()
        {
            // GET specific user
            var request = new RestRequest("api/users/2", Method.Get);
            //var authResponse = await restClient.ExecuteGetAsync(request);

            var response = restClient.Execute(request);

            var jobject = JObject.Parse(response.Content);
            var user = JsonConvert.DeserializeObject<User>(jobject["data"].ToString());

            Console.WriteLine(user.first_name);
        }

        [TestMethod]
        public void LoginAuthToken()
        {
            // POST Login Successful
            var authRequest = new RestRequest("api/login");
            authRequest.AddJsonBody(new { email = "eve.holt@reqres.in", password = "cityslicka" });

            var authResponse = restClient.Post(authRequest);

            // Deserialize token
            var token = JObject.Parse(authResponse.Content)["token"];
            string tokenString = token.ToString();

            var statusCode = authResponse.StatusCode;
            tokenString.Should().Be("QpwL5tke4Pnpja7X4");
            Console.WriteLine(tokenString);
        }

        [TestMethod]
        public void LoginSuccessful()
        {
            // POST Login Successful
            var authRequest = new RestRequest("api/login");
            authRequest.AddJsonBody(new { email = "eve.holt@reqres.in", password = "cityslicka" });

            var authResponse = restClient.Post(authRequest);
            var statusCode = authResponse.StatusCode;
            statusCode.Should().Be(AssertHelper.StatusIs(200));

        }

        [TestMethod]
        public async Task LoginUnsuccessful()
        {
            // POST Login Successful
            var authRequest = new RestRequest("api/login");
            authRequest.AddJsonBody(new { email = "peter@klaven" });

            var restResponse = await restClient.ExecutePostAsync(authRequest);
            var statusCode = restResponse.StatusCode;
            statusCode.Should().Be(AssertHelper.StatusIs(400));
        }

        [TestMethod]
        public void DeleteUser()
        {
            // Delete User Successful
            var authRequest = new RestRequest("api/users/2");

            var restResponse = restClient.Delete(authRequest);
            var statusCode = restResponse.StatusCode;
            statusCode.Should().Be(AssertHelper.StatusIs(204));
        }

        
    }
}
