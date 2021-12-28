using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customers.API.Models;

namespace Customers.API.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IEnumerable<Customer> _customers = new List<Customer>
        {
            new() { Id = 1, Name = "Tesla" },
            new() { Id = 2, Name = "SpaceX" },
            new() { Id = 3, Name = "Neuralink" },
            new() { Id = 4, Name = "The boring company" },
        };

        public Task<Customer> GetCustomerAsync(int customerId)
        {
            var customer = _customers.FirstOrDefault(x => x.Id == customerId);
            return Task.FromResult(customer);
        }

        public Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            return Task.FromResult(_customers);
        }
    }
}