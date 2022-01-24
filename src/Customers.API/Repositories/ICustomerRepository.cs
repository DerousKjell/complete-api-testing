using System.Collections.Generic;
using System.Threading.Tasks;
using Customers.API.Models;

namespace Customers.API.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer> GetCustomerAsync(int customerId);

        Task<IEnumerable<Customer>> GetCustomersAsync();

        Task<Customer> CreateCustomer(CreateCustomerRequest request);

        Task<Customer> UpdateCustomer(int customerId, UpdateCustomerRequest request);

        Task DeleteCustomer(int customerId);
    }
}