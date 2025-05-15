using Ecommerce.Discount.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Ecommerce.Discount.Context;

public class DapperContext : DbContext
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;

    public DapperContext(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString = _configuration.GetConnectionString("local");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-H1O7HUU;Database=EcommerceAppDiscountDb;Trusted_Connection=true;TrustServerCertificate=True;");
    }

    public DbSet<Coupon> Coupons { get; set; }

    public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
}
