using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using eVisitor.Models.Responses;
using RestSharp;
using Newtonsoft.Json;
using eVisitor.Models;
using System.Collections.Generic;

namespace eVisitor.Tests
{
    [TestClass]
    public class HandleResponseTest
    {
        [TestMethod]
        public void MethodShouldReturnStatusCodeOKIfServiceRespondedWithOK()
        {
            var client = new Client(new Core.Authentication("username", "password"));
            RestResponse response = new RestResponse();
            CitiesResponse cityResponse = new CitiesResponse();
            cityResponse.Records = new List<City>();
            cityResponse.Records.Add(new Models.City());

            response.Content = JsonConvert.SerializeObject(cityResponse);
            response.StatusCode = System.Net.HttpStatusCode.OK;
            var clientResponse = client.HandleResponse<CitiesResponse>(response);
            Assert.AreEqual(clientResponse.StatusCode, System.Net.HttpStatusCode.OK);
        }
        [TestMethod]
        public void MethodShouldReturnWhateverStatusCodeServiceReturned()
        {
            var client = new Client(new Core.Authentication("username", "password"));
            RestResponse response = new RestResponse();
            CitiesResponse cityResponse = new CitiesResponse();
            cityResponse.Records = new List<City>();
            cityResponse.Records.Add(new Models.City());

            response.Content = JsonConvert.SerializeObject(cityResponse);
            response.StatusCode = System.Net.HttpStatusCode.Ambiguous;
            var clientResponse = client.HandleResponse<CitiesResponse>(response);
            Assert.AreEqual(clientResponse.StatusCode, System.Net.HttpStatusCode.Ambiguous);
        }
        [TestMethod]
        public void MethodShouldNotThrowWhenStatusCodeIsNotOKAndEVisitorDoesNotRespondWithAppropriateResponseObject()
        {
            var client = new Client(new Core.Authentication("username", "password"));
            RestResponse response = new RestResponse();
            CitiesResponse cityResponse = new CitiesResponse();
            cityResponse.Records = new List<City>();
            cityResponse.Records.Add(new Models.City());

            response.Content = JsonConvert.SerializeObject(cityResponse);
            response.StatusCode = System.Net.HttpStatusCode.Ambiguous;
            var clientResponse = client.HandleResponse<CitiesResponse>(response);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void MethodShouldAuthErrorIfResponseIsNullObject() {
            var client = new Client(new Core.Authentication("username", "password"));
            RestResponse response = new RestResponse();
            
            response.StatusCode = System.Net.HttpStatusCode.OK;
            var clientResponse = client.HandleResponse<CitiesResponse>(null);
            Assert.AreEqual(clientResponse.StatusCode,System.Net.HttpStatusCode.Unauthorized);
            Assert.AreEqual(clientResponse.Error.UserMessage, "Greška eVisitor authorizacije.Korisničko ime, lozinka ili šifra objekta nisu dobro uneseni");
        }
        [TestMethod]
        public void ErrorObjectShouldBeNullIfStatusCodeIsOK()
        {
            var client = new Client(new Core.Authentication("username", "password"));
            RestResponse response = new RestResponse();
            CitiesResponse cityResponse = new CitiesResponse();
            cityResponse.Records = new List<City>();
            cityResponse.Records.Add(new Models.City());

            response.Content = JsonConvert.SerializeObject(cityResponse);

            response.StatusCode = System.Net.HttpStatusCode.OK;
            var clientResponse = client.HandleResponse<CitiesResponse>(response);
            Assert.AreEqual(clientResponse.StatusCode, System.Net.HttpStatusCode.OK);
            Assert.AreEqual(clientResponse.Error, null);
        }
    }
}
