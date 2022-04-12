using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartApp.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed categories
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 1, CategoryName = "Bakery", Description = "Bakery Products" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 2, CategoryName = "Vegetables", Description = "All Vegetables" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 3, CategoryName = "Fruits", Description = "All Fruits" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 4, CategoryName = "Drinks", Description = "All Drinks" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 5, CategoryName = "Meat", Description = "All Meat" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 6, CategoryName = "Snacks", Description = "All Snacks" });

            //seed products

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 1,
                Name = "Rustic Bread",
                Price = 1.45M,
                ShortDescription = "Rustic Bread",
                LongDescription =
                    "The products prepared in the oven can contain as ingredients or as traces the following allergens: gluten, crustaceans shellfish, eggs, fish, peanuts, soybean, milk and dairy products, tree nuts, celery, mustard, sesame, sulphites, lupin and molluscan shellfish.",
                ImageUrl = "",
                InStock = true,
                //ImageThumbnailUrl = "",
                AllergyInformation = ""
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 2,
                Name = "Cherry Tomatoes",
                Price = 2.69M,
                ShortDescription = "Cherry Tomatoes",
                LongDescription =
                  "Dulcita cherry on the vine tomatoes",
                ImageUrl = "",
                InStock = true,
                //ImageThumbnailUrl = "",
                AllergyInformation = ""
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 3,
                Name = "Golden Apple",
                Price = 0.38M,
                ShortDescription = "Piece 210 g approx. | 1,79 €/kg",
                LongDescription = " ",
                ImageUrl = "",
                InStock = true,
                /*ImageThumbnailUrl*/
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 4,
                Name = "Coca-Cola",
                Price = 1.84M,
                ShortDescription = "Coca-Cola soft drink, 2L",
                LongDescription = " ",
                ImageUrl = "",
                InStock = true,  
                /*ImageThumbnailUrl*/
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 5,
                Name = "Fleshy chunks pork ribs",
                Price = 3.54M,
                ShortDescription = "Tray 530 g approx. | 6,67 €/kg",
                LongDescription = " ",
                ImageUrl = "",
                InStock = true,  
                /*ImageThumbnailUrl*/
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 6,
                Name = "Lay's Ready salted crisps",
                Price = 1.48M,
                ShortDescription = "Package 207 g | 7,15 €/kg",
                LongDescription = " ",
                ImageUrl = "",
                InStock = true,  
                /*ImageThumbnailUrl*/

            });

        }
    }
}
