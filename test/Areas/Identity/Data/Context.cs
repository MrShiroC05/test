using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace test.Data;

public class Context : IdentityDbContext<IdentityUser>
{
    public Context(DbContextOptions<Context> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.Entity<TableRevenue>().HasKey(p => new { p.UserId, p.CartId });
    }
    public DbSet<Food> Food { get; set; }
    public DbSet<Category> Category { get; set; }
    public DbSet<Cart> Cart { get; set; }
    public DbSet<TableRevenue> TableRevenue {  get; set; }
}
