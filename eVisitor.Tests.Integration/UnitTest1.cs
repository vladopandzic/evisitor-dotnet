using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using eVisitor.Core;
using eVisitor.Models;
using eVisitor.Models.Responses;

namespace eVisitor.Tests.Integration
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ShouldReturnCities()
        {
            Authentication auth = new Authentication("50387820629", "Petarbla123");

            Client evClient = new eVisitor.Client(auth);

            eVisitor.Models.EVisitorResponse<CitiesResponse> response = evClient.Cities(new Models.Criterias.Criteria());
            Assert.IsTrue(response.Data.Records.Count > 500);
        }
    }
}
