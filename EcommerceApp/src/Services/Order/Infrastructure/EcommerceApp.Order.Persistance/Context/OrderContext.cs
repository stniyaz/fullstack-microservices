using EcommerceApp.Order.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Order.Persistance.Context;

public class OrderContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1440;Database=EcommerceAppOrderDb;User=sa;Password=Salam123$;TrustServerCertificate=True;");
    }

    public DbSet<Address> Addresses { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Ordering> Orderings { get; set; }
}
