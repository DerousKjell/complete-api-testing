using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customers.API.Controllers;
using Customers.API.Models;
using Customers.API.Repositories;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Customers.API.UnitTests.Controllers
{
    [TestClass]
    public class CustomersControllerTests
    {
        [TestMethod]
        public async Task Get_Existing_Customers()
        {
            // Arrange
            var customerRepository = A.Fake<ICustomerRepository>();
            A.CallTo(() => customerRepository.GetCustomerAsync(A<int>._)).Returns(new Customer { Id = 1, Name = "Tesla" });

            var sut = new CustomersController(customerRepository);

            // Act
            var response = await sut.Get(1);

            // Assert
            Assert.IsNotNull(response);
            var okResponse = response as OkObjectResult;
            Assert.IsNotNull(okResponse);
            Assert.AreEqual(200, okResponse.StatusCode);
            var responseValue = okResponse.Value as Customer;
            Assert.IsNotNull(responseValue);
            Assert.AreEqual(1, responseValue.Id);
        }

        [TestMethod]
        public async Task Get_Unknown_Customers()
        {
            // Arrange
            var customerRepository = A.Fake<ICustomerRepository>();
            A.CallTo(() => customerRepository.GetCustomerAsync(A<int>._)).Returns((Customer)null);

            var sut = new CustomersController(customerRepository);

            // Act
            var response = await sut.Get(1);

            // Assert
            Assert.IsNotNull(response);
            var notFoundResponse = response as NotFoundResult;
            Assert.IsNotNull(notFoundResponse);
            Assert.AreEqual(404, notFoundResponse.StatusCode);
        }


        [TestMethod]
        public async Task Get_Customers()
        {
            // Arrange
            var customerRepository = A.Fake<ICustomerRepository>();
            A.CallTo(() => customerRepository.GetCustomersAsync()).Returns(new List<Customer>
                { new Customer { Id = 1, Name = "Tesla" } });

            var sut = new CustomersController(customerRepository);

            // Act
            var response = await sut.Get();

            // Assert
            Assert.IsNotNull(response);
            var okResponse = response as OkObjectResult;
            Assert.IsNotNull(okResponse);
            Assert.AreEqual(200, okResponse.StatusCode);
            var responseValue = okResponse.Value as IEnumerable<Customer>;
            Assert.IsNotNull(responseValue);
            Assert.AreEqual(1, responseValue.Count());
        }
    }
}