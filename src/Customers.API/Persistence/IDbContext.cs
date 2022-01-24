using System;
using System.Threading.Tasks;
using Customers.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Customers.API.Persistence
{
    public interface IDbContext : IDisposable
    {
        DbSet<Customer> Customers { get; set; }

        Task SaveChangesAsync();

        DatabaseFacade GetDatabase();
    }
}