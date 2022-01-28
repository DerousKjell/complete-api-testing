using Customers.API.Services;
using System;
using System.Threading.Tasks;

namespace Customers.API.IntegrationTests.Seedwork.Mocks
{
    public class MockedMailService : IMailService
    {
        public static Func<string, string, string, Task<SendMailResult>> SendMailAsyncFunc { get; set; }

        public Task<SendMailResult> SendMailAsync(string to, string subject, string body)
        {
            return SendMailAsyncFunc(to, subject, body);
        }
    }
}
