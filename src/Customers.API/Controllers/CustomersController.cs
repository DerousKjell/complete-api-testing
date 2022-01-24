using System.Threading.Tasks;
using Customers.API.Models;
using Customers.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Customers.API.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        
        [HttpGet("{customerId}")]
        public async Task<IActionResult> Get(int customerId)
        {
            var customer = await _customerRepository.GetCustomerAsync(customerId);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var customers = await _customerRepository.GetCustomersAsync();
            return Ok(customers);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCustomerRequest request)
        {
            var customer = await _customerRepository.CreateCustomer(request);
            return Ok(customer);
        }

        [HttpPut("{customerId}")]
        public async Task<IActionResult> Put(int customerId, [FromBody] UpdateCustomerRequest request)
        {
            var customer = await _customerRepository.UpdateCustomer(customerId, request);
            return Ok(customer);
        }

        [HttpDelete("{customerId}")]
        public async Task<IActionResult> Delete(int customerId)
        {
            await _customerRepository.DeleteCustomer(customerId);
            return NoContent();
        }
    }
}
