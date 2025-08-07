using ITI_Project.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace ITI_Project.Context
{
    public class MyContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=laptop-41k38dlj;Database=ITI_Project;Trusted_Connection=True;TrustServerCertificate=True";
            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //*-------------------------------------------------------------------*//
            var users =new List<User>
            {
                new User { UserId = 1, FirstName = "Ahmed", LastName = "Ali", Email = "ahmed.ali@example.com", Password = "Password123" },
                new User { UserId = 2, FirstName = "Mona", LastName = "Hassan", Email = "mona.hassan@example.com", Password = "MonaPass456" },
                new User { UserId = 3, FirstName = "Khaled", LastName = "Youssef", Email = "khaled.youssef@example.com", Password = "Khaled789!" },
                new User { UserId = 4, FirstName = "Salma", LastName = "Ibrahim", Email = "salma.ibrahim@example.com", Password = "SalmaPass12" },
                new User { UserId = 5, FirstName = "Tamer", LastName = "Saad", Email = "tamer.saad@example.com", Password = "Tamer_12345" },
                new User { UserId = 6, FirstName = "Rana", LastName = "Farouk", Email = "rana.farouk@example.com", Password = "RanaPass987" },
                new User { UserId = 7, FirstName = "Youssef", LastName = "Hamed", Email = "youssef.hamed@example.com", Password = "Youss_2023" },
                new User { UserId = 8, FirstName = "Nour", LastName = "Gamal", Email = "nour.gamal@example.com", Password = "NourPass321" },
                new User { UserId = 9, FirstName = "Omar", LastName = "ElSayed", Email = "omar.elsayed@example.com", Password = "OmarPass444" },
                new User { UserId = 10, FirstName = "Laila", LastName = "Adel", Email = "laila.adel@example.com", Password = "Laila2022$" }
            };
            //*-------------------------------------------------------------------*//
            var categories = new List<Category>
            {
                 new Category { Id = 1,Name = "Electronics", Description = "Devices and gadgets like phones, laptops, and TVs." },
                 new Category { Id = 2,Name = "Books", Description = "A wide variety of books from fiction to non-fiction." },
                 new Category { Id = 3,Name = "Clothing", Description = "Apparel for men, women, and children of all ages." },
                 new Category { Id = 4,Name = "Home Decor", Description = "Items to decorate and furnish your home beautifully." },
                 new Category { Id = 5,Name = "Sports", Description = "Gear and clothing for different types of sports activities." },
            };
            //*-------------------------------------------------------------------*//
            var products = new List<Product>
            {
                  new Product { Id = 1,Title = "Smartphone", Description = "Latest model with powerful processor and camera.", Price = 8999.99m, Quantity = 50, ImagePath = "images/smartphone.jpg", CategoryId = 1 },
                  new Product { Id = 2,Title = "Running Shoes", Description = "Comfortable and durable shoes for daily running.", Price = 799.50m, Quantity = 100, ImagePath = "images/shoes.jpg", CategoryId = 5 },
                  new Product { Id = 3,Title = "Leather Wallet", Description = "Genuine leather wallet with multiple card slots.", Price = 299.00m, Quantity = 75, ImagePath = "images/wallet.jpg", CategoryId = 3 },
                  new Product { Id = 4,Title = "Bluetooth Headphones", Description = "Wireless headphones with noise cancellation.", Price = 1299.99m, Quantity = 30, ImagePath = "images/headphones.jpg", CategoryId = 1 },
                  new Product { Id = 5,Title = "Fiction Novel", Description = "Bestselling novel with an intriguing storyline.", Price = 99.00m, Quantity = 80, ImagePath = "images/novel.jpg", CategoryId = 2 },
                  new Product { Id = 6,Title = "Table Lamp", Description = "LED table lamp with adjustable brightness.", Price = 399.50m, Quantity = 90, ImagePath = "images/lamp.jpg", CategoryId = 4 }
            };
            //*-------------------------------------------------------------------*//
            modelBuilder
                .Entity<User>()
                .HasData(users);
            //*-------------------------------------------------------------------*//
            modelBuilder
                .Entity<Category>()
                .HasData(categories);
            //*-------------------------------------------------------------------*//
            modelBuilder
                .Entity<Product>()
                .HasData(products);
            //*-------------------------------------------------------------------*//
            base.OnModelCreating(modelBuilder);
        }

        //*-------------------------------------------------------------------*//
        #region Tables
        //*-------------------------------------------------------------------*//
        public virtual DbSet<User> Users { get; set; }
        //*-------------------------------------------------------------------*//
        public virtual DbSet<Category> Categories { get; set; }
        //*-------------------------------------------------------------------*//
        public virtual DbSet<Product> Products { get; set; }
        //*-------------------------------------------------------------------*//

        #endregion
        //*-------------------------------------------------------------------*//
    }
}
