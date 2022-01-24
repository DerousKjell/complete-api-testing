using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Customers.API.IntegrationTests.Seedwork;
using Customers.API.Models;
using Newtonsoft.Json;
using Xunit;

namespace Customers.API.IntegrationTests.Controllers
{
    public class CustomersControllerTests : IClassFixture<CustomWebApplicationFactory>
    {
        readonly HttpClient _client;

        public CustomersControllerTests(CustomWebApplicationFactory fixture)
        {
            _client = fixture.CreateClient();
        }

        [Fact]
        public async Task Get_Existing_Customer()
        {
            // Act
            var response = await _client.GetAsync("/api/customers/1");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var customer = JsonConvert.DeserializeObject<Customer>(await response.Content.ReadAsStringAsync());
            Assert.NotNull(customer);
            Assert.Equal(1, customer.Id);
        }

        [Fact]
        public async Task Get_Unknown_Customer()
        {
            // Act
            var response = await _client.GetAsync($"/api/customers/{int.MaxValue}");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task Get_Customers()
        {
            // Act
            var response = await _client.GetAsync("/api/customers");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var customers = JsonConvert.DeserializeObject<IEnumerable<Customer>>(await response.Content.ReadAsStringAsync());
            Assert.NotNull(customers);
        }

        [Fact]
        public async Task Create_Customer()
        {
            // Act
            var request = new { Name = "MyTestCompany", Email = "info@mytestcompany.com" };
            var json = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("/api/customers", json);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var customers = JsonConvert.DeserializeObject<Customer>(await response.Content.ReadAsStringAsync());
            Assert.NotNull(customers);
        }
    }
}