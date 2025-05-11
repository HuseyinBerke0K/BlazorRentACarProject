using AracKiralama.Models;
using Microsoft.EntityFrameworkCore;
using YourProject.Models;

namespace YourProject.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }  // Product tablosu
        public DbSet<AppUser> AppUsers { get; set; }  // AppUser tablosu
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>().HasNoKey();  // Anahtar olmayan varlýk
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Product>().HasKey(p => p.RentId);
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    }
}
