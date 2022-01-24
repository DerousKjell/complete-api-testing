using Customers.API.IntegrationTests.Seedwork.Mocks;
using Customers.API.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Customers.API.IntegrationTests.Seedwork
{
    public class CustomWebApplicationFactory : WebApplicationFactory<Startup>
    {

        protected override IHostBuilder CreateHostBuilder()
        {
            return base.CreateHostBuilder();
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder
                .ConfigureTestServices((services) =>
                {
                    services.AddTransient<IMailService, MockedMailService>();
                });
        }
    }
}
