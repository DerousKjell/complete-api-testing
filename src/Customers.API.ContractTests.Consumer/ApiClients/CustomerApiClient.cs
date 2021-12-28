using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Customers.API.ContractTests.Consumer.Contracts;
using Newtonsoft.Json;

namespace Customers.API.ContractTests.Consumer.ApiClients
{
    public class CustomerApiClient
    {
        private readonly HttpClient _client;

        public CustomerApiClient(string baseUri = null)
        {
            _client = new HttpClient { BaseAddress = new Uri(baseUri ?? "http://my-api") };
        }

        public async Task<Customer> GetCustomer(int customerId)
        {
            using var request = new HttpRequestMessage(HttpMethod.Get, $"/api/customers/{customerId}");
            request.Headers.Add("Accept", "application/json");

            using var response = await _client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();
            var status = response.StatusCode;
            
            if (status != HttpStatusCode.OK)
            {
                throw new Exception(response.ReasonPhrase);
            }

            return JsonConvert.DeserializeObject<Customer>(content);

        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            using var request = new HttpRequestMessage(HttpMethod.Get, "/api/customers") ;
            request.Headers.Add("Accept", "application/json");

            using var response = await _client.SendAsync(request);

            var content = await response.Content.ReadAsStringAsync();
            var status = response.StatusCode;

            if (status != HttpStatusCode.OK)
            {
                throw new Exception(response.ReasonPhrase);
            }

            return JsonConvert.DeserializeObject<IEnumerable<Customer>>(content);
        }
    }
}