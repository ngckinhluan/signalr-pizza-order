using Microsoft.EntityFrameworkCore;
using Repositories.Configuration;
using Repositories.Entities;

namespace Repositories.Context;

public class RepositoryContext(DbContextOptions options) : DbContext(options)
{

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AccountConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new SupplierConfiguration());
    }
    
    public virtual DbSet<Account>? Accounts { get; set; }
    public virtual DbSet<Category>? Categories { get; set; }
    public virtual DbSet<Customer>? Customers { get; set; }
    public virtual DbSet<Order>? Orders { get; set; }
    public virtual DbSet<OrderDetail>? OrderDetails { get; set; }
    public virtual DbSet<Product>? Products { get; set; }
    public virtual DbSet<Supplier>? Suppliers { get; set; }
}