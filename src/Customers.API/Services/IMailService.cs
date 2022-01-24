﻿using System.Threading.Tasks;

namespace Customers.API.Services
{
    public interface IMailService
    {
        Task SendMailAsync(string to, string subject, string body);
    }
}
