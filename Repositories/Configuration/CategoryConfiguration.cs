using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repositories.Entities;

namespace Repositories.Configuration;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasData
        (
            new Category
            {
                CategoryId = 1,
                CategoryName = "Electronics",
                Description = "Electronic Items"
            },
            new Category
            {
                CategoryId = 2,
                CategoryName = "Clothing",
                Description = "Clothing Items"
            },
            new Category
            {
                CategoryId = 3,
                CategoryName = "Grocery",
                Description = "Grocery Items"
            }
        );
    }
}