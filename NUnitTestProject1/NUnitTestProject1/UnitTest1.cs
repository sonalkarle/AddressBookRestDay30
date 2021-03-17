using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;

namespace NUnitTestProject1
{
    public class Tests
    {
        RestClient client;
        [SetUp]

        public void Setup()
        {
            client = new RestClient("http://localhost:3000");
        }
        /// <summary>
        /// UC1: Retrive the data from the json file
        /// </summary>
        /// <returns></returns>
        private IRestResponse getConatct()
        {
            RestRequest request = new RestRequest("/AddressBook", Method.GET);
            IRestResponse response = client.Execute(request);
            return response;
        }


        /// <summary>
        /// UC2: Get count of the person in the file
        /// </summary>
        [Test]
        public void Return_GivenEmployeeList()
        {
            IRestResponse response = getConatct();
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            List<Contact> list = JsonConvert.DeserializeObject<List<Contact>>(response.Content);
            Assert.AreEqual(5, list.Count);

        }
        
        
        

    }
}