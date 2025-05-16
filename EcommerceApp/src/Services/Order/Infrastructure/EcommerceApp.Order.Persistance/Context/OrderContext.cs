using EcommerceApp.Order.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Order.Persistance.Context;

public class OrderContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-H1O7HUU;Database=EcommerceAppOrderDb;Trusted_Connection=True;TrustServerCertificate=True;");
    }

    public DbSet<Address> Addresses { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Ordering> Orderings { get; set; }
}
