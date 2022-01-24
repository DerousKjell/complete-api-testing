using Customers.API.Persistence;
using System;

namespace Customers.API.UnitTests
{
    public class TestBase : IDisposable
    {
        protected readonly IDbContext _context;

        public TestBase()
        {
            _context = DatabaseContextFactory.Create();
        }

        public void Dispose()
        {
            DatabaseContextFactory.Destroy(_context);
        }
    }
}
