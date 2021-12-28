using System.Threading.Tasks;
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
    }
}
