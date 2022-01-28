using System.Threading.Tasks;

namespace Customers.API.Services
{
    public class SmtpMailService : IMailService
    {
        public Task<SendMailResult> SendMailAsync(string to, string subject, string body)
        {
            return Task.FromResult(new SendMailResult { IsSuccess = true });
        }
    }
}
