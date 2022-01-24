using System.Threading.Tasks;

namespace Customers.API.Services
{
    public class SmtpMailService : IMailService
    {
        public Task SendMailAsync(string to, string subject, string body)
        {
            // This should be used in a live environment (dev, uat, prd)
            return Task.CompletedTask;
        }
    }
}
