using System;
using PactNet;
using PactNet.Mocks.MockHttpService;

namespace Customers.API.ContractTests.Consumer.Pacts
{
    public class ConsumerCustomerApiPact : IDisposable
    {
        public IPactBuilder PactBuilder { get; }
        public IMockProviderService MockProviderService { get; }

        public int MockServerPort => 9222;
        public string MockProviderServiceBaseUri => $"http://localhost:{MockServerPort}";

        public ConsumerCustomerApiPact()
        {
            // TODO: Investigate why PactDir parameter is not working. As of now it seems that the pact file is always created in the \bin\debug directory.
            PactBuilder = new PactBuilder(new PactConfig { SpecificationVersion = "2.0.0", PactDir = @"..\mypacts", LogDir = @"c:\temp\logs" });

            PactBuilder
              .ServiceConsumer("Consumer")
              .HasPactWith("Customer API");

            MockProviderService = PactBuilder.MockService(MockServerPort); 
        }

        public void Dispose()
        {
            PactBuilder.Build(); //NOTE: Will save the pact file once finished
        }
    }
}