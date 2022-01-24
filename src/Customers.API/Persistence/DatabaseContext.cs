using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Customers.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Customers.API.Persistence
{
    public class DatabaseContext : DbContext, IDbContext
    {
        public DatabaseContext()
        {
            
        }

        public DatabaseContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Customer> Customers { get; set; }

        public DatabaseFacade GetDatabase()
        {
            return Database;
        }

        public async Task SaveChangesAsync()
        {
            await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}