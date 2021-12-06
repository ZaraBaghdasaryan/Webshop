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
                    ProductName = "Space Suit Purple",
                    Price = 699,
                    CategoryId = 1,
                    Availability = 10
                },
                  new Product
                  {
                      ProductId = 2,
                      ProductName = "Space Suit Black",
                      Price = 699,
                      CategoryId = 1,
                      Availability = 10
                  },
                    new Product
                    {
                        ProductId = 3,
                        ProductName = "Space Suit Yellow",
                        Price = 699,
                        CategoryId = 1,
                        Availability = 10
                    }, new Product
                    {
                        ProductId = 4,
                        ProductName = "Space Suit Blue",
                        Price = 699,
                        CategoryId = 1,
                        Availability = 10
                    }, new Product
                    {
                        ProductId = 5,
                        ProductName = "Space Suit Dark Blue",
                        Price = 699,
                        CategoryId = 1,
                        Availability = 10
                    },
                new Product
                {
                    ProductId = 6,
                    ProductName = "Space Shuttle Black",
                    Price = 699,
                    CategoryId = 2,
                    Availability = 10
                },
                new Product
                {
                    ProductId = 7,
                    ProductName = "Space Shuttle Blue",
                    Price = 699,
                    CategoryId = 2,
                    Availability = 10
                },
                new Product
                {
                    ProductId = 8,
                    ProductName = "Space Shuttle Dark Blue",
                    Price = 699,
                    CategoryId = 2,
                    Availability = 10
                },
                new Product
                {
                    ProductId = 9,
                    ProductName = "Space Shuttle Silver",
                    Price = 699,
                    CategoryId = 2,
                    Availability = 10
                },
                new Product
                {
                    ProductId = 10,
                    ProductName = "Space Shuttle Red",
                    Price = 699,
                    CategoryId = 2,
                    Availability = 10
                },
                 new Product
                 {
                     ProductId = 11,
                     ProductName = "Learn to be weightless",
                     Price = 699,
                     CategoryId = 3,
                     Availability = 10
                 },
                  new Product
                  {
                      ProductId = 12,
                      ProductName = "Free fall training",
                      Price = 699,
                      CategoryId = 3,
                      Availability = 10
                  },
                   new Product
                   {
                       ProductId = 13,
                       ProductName = "Moon walk training",
                       Price = 699,
                       CategoryId = 3,
                       Availability = 10
                   },
                    new Product
                    {
                        ProductId = 14,
                        ProductName = "Survival on Mars",
                        Price = 699,
                        CategoryId = 3,
                        Availability = 10
                    },
                     new Product
                     {
                         ProductId = 15,
                         ProductName = "Conquer your deepest fears of cosmos",
                         Price = 699,
                         CategoryId = 3,
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
                },
                new Category
                {
                    CategoryId = 3,
                    CategoryName = "Astronaut Training"
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
                    IsLoggedin = false,
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
