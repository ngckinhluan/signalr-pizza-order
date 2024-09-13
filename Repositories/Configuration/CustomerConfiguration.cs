using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repositories.Entities;

namespace Repositories.Configuration;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasData
        (
            new Customer
            {
                CustomerID = 1,
                ContactName = "Alice Johnson",
                Address = "123 Maple Street, Springfield",
                Phone = "555-1234",
                Password = "alice123"
            },
            new Customer
            {
                CustomerID = 2,
                ContactName = "Bob Smith",
                Address = "456 Oak Avenue, Rivertown",
                Phone = "555-5678",
                Password = "bobsecure"
            },
            new Customer
            {
                CustomerID = 3,
                ContactName = "Catherine Lee",
                Address = "789 Pine Road, Lakeview",
                Phone = "555-9012",
                Password = "catlee2024"
            }
        );
    }
}