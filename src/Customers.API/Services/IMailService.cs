using System.Threading.Tasks;

namespace Customers.API.Services
{
    public interface IMailService
    {
        Task<SendMailResult> SendMailAsync(string to, string subject, string body);
    }

    public class SendMailResult
    {
        public bool IsSuccess { get; set; }
    }
}
