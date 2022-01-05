using System.Net;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace Customers.API.E2ETests.Customers
{
    [TestClass]
    public class GetCustomerTests
    {
        [TestMethod]
        public async Task Get_Customer()
        {
            // Arrange
            var client = new RestClient("https://localhost:5001/api/");
            var request = new RestRequest("customers/1");

            // Act
            var response = await client.ExecuteAsync(request);

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }


        [TestMethod]
        public async Task Get_NonExisting_Customer()
        {
            // Arrange
            var client = new RestClient("https://localhost:5001/api/");
            var request = new RestRequest($"customers/{int.MaxValue}");

            // Act
            var response = await client.ExecuteAsync(request);

            // Assert
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}