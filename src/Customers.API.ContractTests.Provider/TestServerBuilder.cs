using System.IO;
using System.Net;
using System.Reflection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Customers.API.ContractTests.Provider
{
    public class TestServerBuilder
    {
        public static IWebHost CreateTestServer()
        {
            var currentPath = Path.GetDirectoryName(Assembly.GetAssembly(typeof(CustomerApiTests)).Location);
            var hostBuilder = WebHost.CreateDefaultBuilder()
                .UseContentRoot(currentPath)
                .UseStartup<Startup>()
                .UseKestrel(options =>
                {
                    options.Listen(IPAddress.Loopback, Constants.Port);
                });

            return hostBuilder.Start();
        }
    }
}