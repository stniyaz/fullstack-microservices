using EcommerceApp.Comment.Entities;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Comment.Context;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1442;initial catalog=EcommerceAppCommentDb;user=sa;Password=Salam123$;TrustServerCertificate=True;");
    }

    public DbSet<UserComment> UserComments { get; set; }
}
