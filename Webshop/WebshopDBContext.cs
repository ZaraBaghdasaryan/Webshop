using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop.Models;
using Microsoft.EntityFrameworkCore;
using Webshop.Configurations;

namespace Webshop
{
    class WebshopDBContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<OrderProducts> OrderProducts { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Webshop;Trusted_Connection=True;");



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
                .Entity<Customer>()
                .HasData(
                new Customer
                {
                    Id = 1,
                    FirstName = "Anna",
                    LastName = "Johnson",
                    Address = "Vägen 11, 447 74 Vägen",
                    IsLoggedin = true,
                    Email = "annabanan@gmail.com",
                    Password = "1234"
                }
                );

            modelbuilder
                .ApplyConfiguration(new ProductConfig())
                .ApplyConfiguration(new CategoryConfig())
                .ApplyConfiguration(new OrderConfig());
                

        }
    }
}
