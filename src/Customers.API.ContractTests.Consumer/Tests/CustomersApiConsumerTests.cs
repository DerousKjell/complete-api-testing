using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Customers.API.ContractTests.Consumer.ApiClients;
using Customers.API.ContractTests.Consumer.Pacts;
using PactNet.Matchers;
using PactNet.Mocks.MockHttpService;
using PactNet.Mocks.MockHttpService.Models;
using Xunit;

namespace Customers.API.ContractTests.Consumer.Tests
{
    public class CustomerApiConsumerTests : IClassFixture<ConsumerCustomerApiPact>, IDisposable
    {
        private readonly IMockProviderService _mockProviderService;
        private readonly string _mockProviderServiceBaseUri;

        public CustomerApiConsumerTests(ConsumerCustomerApiPact data)
        {
            _mockProviderService = data.MockProviderService;
            _mockProviderService.ClearInteractions(); 
            _mockProviderServiceBaseUri = data.MockProviderServiceBaseUri;
        }

        [Fact]
        public async Task GetCustomers()
        {
            //Arrange
            _mockProviderService
                .Given("There are customers")
                .UponReceiving("A GET request to retrieve customers")
                .With(new ProviderServiceRequest
                {
                    Method = HttpVerb.Get,
                    Path = "/api/customers",
                    Headers = new Dictionary<string, object>
                    {
                        { "Accept", "application/json" }
                    }
                })
                .WillRespondWith(new ProviderServiceResponse
                {
                    Status = 200,
                    Headers = new Dictionary<string, object>
                    {
                        { "Content-Type", "application/json; charset=utf-8" }
                    },
                    Body = Match.MinType(new
                    {
                        id = 1,
                        name = "Tesla"
                    }, 1)
                }); //NOTE: WillRespondWith call must come last as it will register the interaction

            var consumer = new CustomerApiClient(_mockProviderServiceBaseUri);

            //Act
            var result = await consumer.GetCustomers();

            //Assert
            Assert.NotNull(result);

            _mockProviderService.VerifyInteractions(); //NOTE: Verifies that interactions registered on the mock provider are called at least once
        }


        [Fact]
        public async Task GetCustomer()
        {
            //Arrange
            _mockProviderService
                .Given("There is a customer")
                .UponReceiving("A GET request to retrieve a customer")
                .With(new ProviderServiceRequest
                {
                    Method = HttpVerb.Get,
                    Path = "/api/customers/1",
                    Headers = new Dictionary<string, object>
                    {
                        { "Accept", "application/json" }
                    }
                })
                .WillRespondWith(new ProviderServiceResponse
                {
                    Status = 200,
                    Headers = new Dictionary<string, object>
                    {
                        { "Content-Type", "application/json; charset=utf-8" }
                    },
                    Body = new
                    {
                        id = Match.Type(1),
                        name = Match.Type("Tesla")
                    }
                });

            var consumer = new CustomerApiClient(_mockProviderServiceBaseUri);

            //Act
            var result = await consumer.GetCustomer(1);

            //Assert
            Assert.NotNull(result);

            _mockProviderService.VerifyInteractions(); //NOTE: Verifies that interactions registered on the mock provider are called at least once
        }

        public void Dispose()
        {
        
        }
    }
}