using EcommerceApp.Message.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Message.DAL.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<UserMessage> UserMessage { get; set; }
}