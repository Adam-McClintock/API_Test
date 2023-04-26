using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Test
{
    [TestClass]
    public class Covid19_Tests 
    {
        // USING SAMPLE API HERE: https://api.covid19api.com/

        // RestClient

        RestClient restClient = new RestClient(new RestClientOptions
        {
            BaseUrl = new Uri("https://api.covid19api.com/")
        });

        [TestMethod]
        public void GetCountries()
        {
            // GET Covid Countries 
            var response = CommonAPI.SendGetRequest("countries");
            response.StatusCode.Should().Be(AssertHelper.StatusIs(200));
        }

        [TestMethod]
        public void GetSummary()
        {
            // GET Covid Countries 
            var response = CommonAPI.SendGetRequest("summary");
            response.StatusCode.Should().Be(AssertHelper.StatusIs(200));
        }

        [TestMethod]
        public void GetDayOneTotal()
        {
            // GET Covid Countries 
            var response = CommonAPI.SendGetRequest("total/dayone/country/south-africa/status/confirmed");
            response.StatusCode.Should().Be(AssertHelper.StatusIs(200));
        }

        [TestMethod]
        public void GetCountryTotal()
        {
            var response = CommonAPI.SendGetRequestWithParameters
                ("total/dayone/country/south-africa/status/confirmed", 
                "from", "2020-03-01T00:00:00Z", 
                "to", "2020-04-01T00:00:00Z");

            response.StatusCode.Should().Be(AssertHelper.StatusIs(200));
        }
    }
}
