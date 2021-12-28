using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Customers.API.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Xunit;

namespace Customers.API.IntegrationTests.Controllers
{
    public class CustomersControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        readonly HttpClient _client;

        public CustomersControllerTests(WebApplicationFactory<Startup> fixture)
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
    }
}