using System;
using System.Collections.Generic;
using System.IO;
using PactNet;
using PactNet.Infrastructure.Outputters;
using Xunit;
using Xunit.Abstractions;

namespace Customers.API.ContractTests.Provider
{
    public class CustomerApiTests
    {
        private readonly ITestOutputHelper _output;
        
        
        public CustomerApiTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void EnsureCustomerApiHonoursPactWithConsumer()
        {
            TestServerBuilder.CreateTestServer();

            var config = new PactVerifierConfig
            {
                Outputters = new List<IOutput>
                {
                    new XUnitOutput(_output)
                },
                Verbose = true //Output verbose verification logs to the test output
            };

            new PactVerifier(config)
                .ServiceProvider("Customer API", $"http://localhost:{Constants.Port}")
                .HonoursPactWith("Consumer")
                .PactUri(GetPactDirectory())
                .Verify();
        }

        private string GetPactDirectory()
        {
            return
                $@"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName}\Customers.API.ContractTests.Consumer\bin\Debug\pacts\consumer-customer_api.json";

        }
    }
}