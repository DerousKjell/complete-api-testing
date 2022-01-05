using System.Net;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace Customers.API.E2ETests.Customers
{
    [TestClass]
    public class GetCustomersTests
    {
        [TestMethod]
        public async Task Get_Customers()
        {
            // Arrange
            var client = new RestClient("https://localhost:5001/api/");
            var request = new RestRequest("customers");

            // Act
            var response = await client.ExecuteAsync(request);

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

    }
}