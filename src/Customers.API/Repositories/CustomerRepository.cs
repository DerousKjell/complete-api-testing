using System.Collections.Generic;
using System.Threading.Tasks;
using Customers.API.Models;
using Customers.API.Persistence;
using Customers.API.SeedWork.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Customers.API.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDbContext _context;

        public CustomerRepository(IDbContext context)
        {
            _context = context;
        }
        
        public async Task<Customer> GetCustomerAsync(int customerId)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == customerId);
            return customer;
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            var customers = await _context.Customers.ToListAsync();
            return customers;
        }

        public async Task<Customer> CreateCustomer(CreateCustomerRequest request)
        {
            var customer = new Customer
            {
                Name = request.Name
            };

            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
            
            return await GetCustomerAsync(customer.Id);
        }

        public async Task<Customer> UpdateCustomer(int customerId, UpdateCustomerRequest request)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == customerId);

            if (customer == null)
            {
                throw new NotFoundException();
            }

            customer.Name = request.Name;
            await _context.SaveChangesAsync();

            return await GetCustomerAsync(customerId);
        }

        public async Task DeleteCustomer(int customerId)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == customerId);
            
            if (customer == null)
            {
                throw new NotFoundException();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }
    }
}