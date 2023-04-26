using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Test
{
    [TestClass]
    public static class CommonAPI
    {
        private static RestClient restClient = new RestClient(new RestClientOptions
        {
            BaseUrl = new Uri("https://api.covid19api.com/")
        });


        public static RestResponse SendGetRequest(string query)
        {
            var request = BuildRequest(query);
            var response = CallAPI(request);
            return response;
        }

        public static RestRequest BuildRequest(string query)
        {
            var request = new RestRequest(query);
            return request;
        }

        public static RestResponse CallAPI(RestRequest request)
        {
            var response = restClient.Execute(request);
            return response;
        }

        public static Dictionary<string,string> SetParameters
            (string key1, string value1, string key2, string value2)
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add(key1, value1);
            parameters.Add(key2, value2);
            return parameters;
        }

        public static RestResponse SendGetRequestWithParameters
            (string query, string paramKey1, string paramValue1, string paramKey2, string paramValue2)
        {
            var request = BuildRequest(query);

            var parameters = SetParameters(paramKey1, paramValue1, paramKey2, paramValue2);

            foreach (var param in parameters)
            {
                request.AddQueryParameter(param.Key, param.Value);
            }

            var response = CallAPI(request);
            return response;
        }
    }
}
