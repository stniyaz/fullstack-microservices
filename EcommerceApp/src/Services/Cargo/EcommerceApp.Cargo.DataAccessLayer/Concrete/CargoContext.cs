using EcommerceApp.Cargo.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Cargo.DataAccessLayer.Concrete;

public class CargoContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1441;initial catalog=EcommerceAppCargoDb;user=sa;Password=Salam123$;TrustServerCertificate=True;");
    }

    public DbSet<CargoCompany> CargoCompanies { get; set; }
    public DbSet<CargoCustomer> CargoCustomers { get; set; }
    public DbSet<CargoDetail> CargoDetails { get; set; }
    public DbSet<CargoOperation> CargoOperations { get; set; }
}
