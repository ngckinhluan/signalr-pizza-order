using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repositories.Entities;

namespace Repositories.Configuration;

public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
{
    public void Configure(EntityTypeBuilder<OrderDetail> builder)
    {
        builder.HasData
        (
            new OrderDetail
            {
                OrderDetailId = 1,
                OrderId = 1,
                ProductId = 1,
                UnitPrice = 50.00m,
                Quantity = 2
            },
            new OrderDetail
            {
                OrderDetailId = 2,
                OrderId = 2,
                ProductId = 2,
                UnitPrice = 25.00m,
                Quantity = 5
            },
            new OrderDetail
            {
                OrderDetailId = 3,
                OrderId = 3,
                ProductId = 3,
                UnitPrice = 100.00m,
                Quantity = 1
            }
        );
    }
}