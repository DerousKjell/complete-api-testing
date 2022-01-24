using Customers.API.Models;
using Customers.API.Repositories;
using Customers.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Customers.API.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMailService _mailService;

        public CustomersController(ICustomerRepository customerRepository, IMailService mailService)
        {
            _customerRepository = customerRepository;
            _mailService = mailService;
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

            if (!string.IsNullOrWhiteSpace(request.Email))
            {
                await _mailService.SendMailAsync(customer.Email, "Thank you for your registration", "Hi there..");
            }

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
