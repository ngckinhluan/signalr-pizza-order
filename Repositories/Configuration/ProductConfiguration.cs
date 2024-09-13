using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repositories.Entities;

namespace Repositories.Configuration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasData
        (
            new Product
            {
                ProductId = 1,
                ProductName = "Wireless Headphones",
                QuantityPerUnit = "1 pair",
                UnitPrice = 50.00m,
                ProductImage = "headphones.jpg",
                CategoryId = 1, 
                SupplierId = 1 
            },
            new Product
            {
                ProductId = 2,
                ProductName = "Bluetooth Speaker",
                QuantityPerUnit = "1 piece",
                UnitPrice = 25.00m,
                ProductImage = "speaker.jpg",
                CategoryId = 1,
                SupplierId = 2
            },
            new Product
            {
                ProductId = 3,
                ProductName = "Smartwatch",
                QuantityPerUnit = "1 piece",
                UnitPrice = 100.00m,
                ProductImage = "smartwatch.jpg",
                CategoryId = 2,
                SupplierId = 3
            }
        );

    }
}