using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;

namespace API_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // RestClient

            var restClient = new RestClient(new RestClientOptions
            {
                BaseUrl = new Uri("https://gorest.co.in")
            });


            // GET specific user
            var authResponse = restClient.Get(new RestRequest("/public/v2/users/678"));

            // Deserialize the Token
            //var token = authResponse

            Console.WriteLine(authResponse.Content);
        }

        [TestMethod] 
        public void TestMethod2() 
        {
            // RestClient

            var restClient = new RestClient(new RestClientOptions
            {
                BaseUrl = new Uri("https://gorest.co.in")
            });


            // POST on the auth
            var authRequest = new RestRequest("/public/v2/users");
            var authBody = @"
                    {'name':'Adam Macc',
                        'email':'test@test.com',
                        'gender':'male',
                        'status':'active'}";

            authRequest.AddStringBody(authBody, DataFormat.Json);

            var authResponse = restClient.Post(authRequest);
            

            // Deserialize the Token
            //var token = authResponse

            //Console.WriteLine(authRequest.Content);
        }

        [TestMethod]
        public void TestMethod3()
        {
            // RestClient

            var restClient = new RestClient(new RestClientOptions
            {
                BaseUrl = new Uri("https://gorest.co.in")
            });


            // GET specific user
            var authResponse = restClient.Get(new RestRequest("/public/v2/users"));

            // Deserialize the Token
            //var token = authResponse
            var statusCode = authResponse.StatusCode;
            statusCode.Should().Be((System.Net.HttpStatusCode)200);

            //Assert.IsTrue(authResponse);
        }
        [TestMethod]
        public void TestMethod4()
        {
            // RestClient

            var restClient = new RestClient(new RestClientOptions
            {
                BaseUrl = new Uri("https://gorest.co.in")
            });


            // GET specific user
            var authResponse = restClient.Get(new RestRequest("/public/v2/users"));

            // Deserialize the Token
            //var token = authResponse
            var statusCode = authResponse.StatusCode;
            statusCode.Should().Be((System.Net.HttpStatusCode)200);

            //Assert.IsTrue(authResponse);
        }
    }
}
