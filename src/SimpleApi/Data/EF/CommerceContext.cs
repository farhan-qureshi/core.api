using Microsoft.EntityFrameworkCore;
using core.api.commerce.Models;

namespace core.api.commerce.Data.EF
{
    public class CommerceContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<SubProduct> SubProducts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LOCALHOST\LOCALHOST;Database=Commerce;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData
                (
                new Product 
                { 
                    ProductId = 1, Description = "first product description", Title = "first product title"
                },
                new Product
                {
                    ProductId = 2, Description = "second product description", Title = "second product title"
                });

            modelBuilder.Entity<SubProduct>().HasData
                (
                    new SubProduct { Description = "sub product 1", SubProductId = 1, Title = "first sub product", ProductId = 1 },
                    new SubProduct { Description = "sub product 2", SubProductId = 2, Title = "second sub product", ProductId = 2 },
                    new SubProduct { Description = "sub product 3", SubProductId = 3, Title = "third sub product", ProductId = 1 }
                );
        }
    }
}
