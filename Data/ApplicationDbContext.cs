using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ContosoPizza.Authentication;
using ContosoPizza.Models;

namespace ContosoPizza.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Pizza> Pizzas { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<ApplicationUser>().ToTable("users");
            // modelBuilder.Entity<Pizza>().ToTable("pizzas");
            // modelBuilder.Entity<Pizza>().Property(p => p.Id).HasColumnName("id");
            // modelBuilder.Entity<Pizza>().Property(p => p.Name).HasColumnName("name");
            // modelBuilder.Entity<Pizza>().Property(p => p.IsGlutenFree).HasColumnName("is_gluten_free");
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }
    }
}