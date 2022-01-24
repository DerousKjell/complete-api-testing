using Customers.API.Services;
using System.Threading.Tasks;

namespace Customers.API.IntegrationTests.Seedwork.Mocks
{
    public class MockedMailService : IMailService
    {
        public Task SendMailAsync(string to, string subject, string body)
        {
            return Task.CompletedTask;
        }
    }
}
