using System.Threading.Tasks;
using Customers.API.Persistence;
using Customers.API.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Customers.API.UnitTests.Repositories
{
    [TestClass]
    public class CustomerRepositoryTests : TestBase
    {

        [TestMethod]
        public async Task Get_Customers()
        {
            // Arrange
            var sut = new CustomerRepository(_context);

            // Act
            var customers = await sut.GetCustomersAsync();

            // Assert
            Assert.IsNotNull(customers);
        }


        [TestMethod]
        public async Task Get_Existing_Customer()
        {
            // Arrange
            var sut = new CustomerRepository(_context);

            // Act
            var customer = await sut.GetCustomerAsync(1);

            // Assert
            Assert.IsNotNull(customer);
        }


        [TestMethod]
        public async Task Get_Unknown_Customer()
        {
            // Arrange
            var sut = new CustomerRepository(_context);

            // Act
            var customer = await sut.GetCustomerAsync(int.MaxValue);

            // Assert
            Assert.IsNull(customer);
        }
    }
}