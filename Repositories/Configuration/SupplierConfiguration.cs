using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repositories.Entities;

namespace Repositories.Configuration;

public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> builder)
    {
        builder.HasData
        (
            new Supplier
            {
                SupplierId = 1,
                CompanyName = "Tech Supplies Inc.",
                Address = "123 Tech Lane, Silicon Valley",
                Phone = "555-1234"
            },
            new Supplier
            {
                SupplierId = 2,
                CompanyName = "Sound Systems Co.",
                Address = "456 Audio Street, Music City",
                Phone = "555-5678"
            },
            new Supplier
            {
                SupplierId = 3,
                CompanyName = "Gadget World",
                Address = "789 Device Road, Innovation Park",
                Phone = "555-9012"
            }
        );
    }
}