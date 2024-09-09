using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repositories.Entities;

namespace Repositories.Configuration;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.HasData
        (
            new Account
            {
                AccountId = 1,
                Type = "Savings",
                FullName = "John Doe",
                Password = "password123",
                UserName = "johndoe"
            },
            new Account
            {
                AccountId = 2,
                Type = "Checking",
                FullName = "Jane Smith",
                Password = "mypassword",
                UserName = "janesmith"
            },
            new Account
            {
                AccountId = 3,
                Type = "Business",
                FullName = "Michael Johnson",
                Password = "securepass",
                UserName = "michaelj"
            }
        );
    }
}