using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data
{
    public class ProductContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;");
            optionsBuilder.UseLazyLoadingProxies();

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryProduct>()
                .HasKey(cp => new { cp.CategoryId, cp.ProductId });

            modelBuilder.Entity<CategoryProduct>()
                .HasOne(cp => cp.Category)
                .WithMany(category => category.CategoryProducts)
                .HasForeignKey(cp => cp.CategoryId);

            modelBuilder.Entity<CategoryProduct>()
                .HasOne(cp => cp.Product)
                .WithMany(product => product.CategoryProducts)
                .HasForeignKey(cp => cp.ProductId);

            modelBuilder.Entity<Category>()
                .HasData(
                    new Category()
                    {
                        Id = 1,
                        Name = "Packed food",
                        Description = ""
                    },
                    new Category()
                    {
                        Id = 2,
                        Name = "Fruit",
                        Description = ""
                    },
                    new Category()
                    {
                        Id = 3,
                        Name = "Vegetable",
                        Description = ""
                    },
                    new Category()
                    {
                        Id = 4,
                        Name = "Milk products",
                        Description = ""
                    },
                    new Category()
                    {
                        Id = 5,
                        Name = "Meat",
                        Description = ""
                    }
                );



        }
        
    }
}
