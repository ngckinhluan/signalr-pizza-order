using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repositories.Entities;

namespace Repositories.Configuration;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasData
        (
            new Order
            {
                OrderId = 1,
                OrderDate = new DateOnly(2024, 9, 1),
                RequiredDate = new DateOnly(2024, 9, 10),
                ShippedDate = new DateOnly(2024, 9, 5),
                Freight = 25.50m,
                ShipAddress = "123 Elm Street, Springfield",
                CustomerId = 1
            },
            new Order
            {
                OrderId = 2,
                OrderDate = new DateOnly(2024, 8, 15),
                RequiredDate = new DateOnly(2024, 8, 25),
                ShippedDate = new DateOnly(2024, 8, 20),
                Freight = 15.75m,
                ShipAddress = "456 Oak Avenue, Rivertown",
                CustomerId = 2
            },
            new Order
            {
                OrderId = 3,
                OrderDate = new DateOnly(2024, 7, 20),
                RequiredDate = new DateOnly(2024, 7, 30),
                ShippedDate = new DateOnly(2024, 7, 25),
                Freight = 30.00m,
                ShipAddress = "789 Pine Road, Lakeview",
                CustomerId = 3
            }
        );
    }
}