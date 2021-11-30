using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Webshop.Configurations;
using Webshop.Models;

namespace Webshop
{
    public class webshopContextFortesting : DbContext
    {

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=WebShop;Trusted_Connection=True;");

        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder
                .Entity<Product>()
                .HasData(
                new Product
                {
                    ProductId = 1,
                    ProductName = "Space Suit 1",
                    Price = 699,
                    CategoryId = 1,
                    Availability = 10
                },
                new Product
                {
                ProductId = 2,
                    ProductName = "Space Shuttle",
                    Price = 699,
                    CategoryId = 2,
                    Availability = 10
                }
                );

            modelbuilder
                .Entity<Category>()
                .HasData(
                new Category
                {
                    CategoryId = 1,
                    CategoryName = "Space Suits"
                },
                new Category
                {
                    CategoryId = 2,
                    CategoryName = "Space Vehicles"
                }
                );
                
            modelbuilder
                .ApplyConfiguration(new ProductConfig())
                .ApplyConfiguration(new CategoryConfig());

        }
    }


}
