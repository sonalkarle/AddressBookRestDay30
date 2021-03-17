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
        
        /// <summary>
        /// Uc3: Add employee in to the list
        /// </summary>
        [Test]
        public void GivenEmployee_onpost_shouldreturnAddEmployee()
        {
            RestRequest request = new RestRequest("/AddressBook", Method.POST);
            JObject jObject = new JObject();
            jObject.Add("firstname", "Sona");
            jObject.Add("lastname", "karle");
            jObject.Add("Address", "Kurla");
            jObject.Add("City" , "Mumbai");
            jObject.Add("Zip", "400 066");
            jObject.Add("Phonenumber", "98061840");


            request.AddParameter("application/json", jObject, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.Created);
            Contact dataresponse = JsonConvert.DeserializeObject<Contact>(response.Content);
            Assert.AreEqual("Sona", dataresponse.firstname);
            Assert.AreEqual("87549612", dataresponse.Phonenumber);

           

        }
        
      
        

    }
}