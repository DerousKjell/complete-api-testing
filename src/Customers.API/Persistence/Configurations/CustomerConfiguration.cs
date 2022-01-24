using System.Collections.Generic;
using Customers.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Customers.API.Persistence.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(x => x.Name).IsRequired();

            var customers = new List<Customer>
            {
                new() { Id = 1, Name = "Tesla" },
                new() { Id = 2, Name = "SpaceX" },
                new() { Id = 3, Name = "Neuralink" },
                new() { Id = 4, Name = "The boring company" },
            };

            builder.HasData(customers);
        }
    }
}