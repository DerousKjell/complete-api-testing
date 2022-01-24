using Customers.API.Persistence;
using Microsoft.EntityFrameworkCore;
using System;

namespace Customers.API.UnitTests
{
    public class DatabaseContextFactory
    {
        public static IDbContext Create()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new DatabaseContext(options);

            context.Database.EnsureCreated();
            
            return context;
        }

        public static void Destroy(IDbContext context)
        {
            context.GetDatabase().EnsureDeleted();

            context.Dispose();
        }
    }
}
