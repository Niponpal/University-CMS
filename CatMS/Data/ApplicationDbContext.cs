using CatMS.Auth_IdentityModel;
using CatMS.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Reflection;

namespace CatMS.Data;

public class ApplicationDbContext : IdentityDbContext<
    IdentityModel.User,
    IdentityModel.Role,
    long,
    IdentityModel.UserClaim,
    IdentityModel.UserRole,
    IdentityModel.UserLogin,
    IdentityModel.RoleClaim,
    IdentityModel.UserToken>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // DbSet properties for your entities go here
    public DbSet<Cat> Cats { get; set; }
    public DbSet<Seller> Sellers { get; set; }
    public DbSet<Buyer> Buyers { get; set; }

    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cat>()
           .HasOne(c => c.Seller)
           .WithMany(s => s.Cats)
           .HasForeignKey(c => c.SellerId)
           .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Order>()
          .HasOne(c => c.Buyer)
          .WithMany(s => s.Order)
          .HasForeignKey(c => c.BuyerId)
          .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Order>()
          .HasOne(c => c.Cat)
          .WithMany(s => s.Order)
          .HasForeignKey(c => c.CatId)
          .OnDelete(DeleteBehavior.Cascade);


        // Buyer → Cat (1-M)
        modelBuilder.Entity<Cat>()
            .HasOne(c => c.Buyer)
            .WithMany(b => b.Cats)
            .HasForeignKey(c => c.BuyerId)
            .OnDelete(DeleteBehavior.SetNull);



        base.OnModelCreating(modelBuilder);
        // Automatically apply configurations
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.ConfigureWarnings(warnings =>
        warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        optionsBuilder.LogTo(Console.WriteLine);
        optionsBuilder.UseLoggerFactory(new LoggerFactory(new[] { new Microsoft.Extensions.Logging.Debug.DebugLoggerProvider() }));
    }




}