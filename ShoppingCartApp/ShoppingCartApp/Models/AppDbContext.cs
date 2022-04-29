using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShoppingCartApp.ViewModels;

namespace ShoppingCartApp.Models
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<ProductList> ProductLists { get; set; }
        public DbSet<ProductListDetail> ProductListDetails { get; set; }

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
                CategoryId = 1,
                ImageUrl = "\\Images\\bread.png",
                InStock = true,
                ImageThumbnailUrl = "\\Images\\breadsmall.jpg",
            }) ;

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 2,
                Name = "Cherry Tomatoes",
                Price = 2.69M,
                ShortDescription = "Cherry Tomatoes",
                LongDescription =
                  "Dulcita cherry on the vine tomatoes",
                CategoryId = 2,
                ImageUrl = "\\Images\\cherry.jpg",
                InStock = true,
                ImageThumbnailUrl = "\\Images\\cherrysmall.jpg",
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 3,
                Name = "Golden Apple",
                Price = 0.38M,
                ShortDescription = "Piece 210 g approx. | 1,79 €/kg",
                LongDescription = " ",
                CategoryId = 3,
                ImageUrl = "\\Images\\apple.jpg",
                InStock = true,
                ImageThumbnailUrl = "\\Images\\applesmall.jpg",
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 4,
                Name = "Coca-Cola",
                Price = 1.84M,
                ShortDescription = "Coca-Cola soft drink, 2L",
                LongDescription = " ",
                CategoryId = 4,
                ImageUrl = "\\Images\\colasmall.jpg",
                InStock = true,
                ImageThumbnailUrl = "\\Images\\colasmall.jpg",
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 5,
                Name = "Fleshy chunks pork ribs",
                Price = 3.54M,
                ShortDescription = "Tray 530 g approx. | 6,67 €/kg",
                LongDescription = " ",
                CategoryId = 5,
                ImageUrl = "\\Images\\pork.jpg",
                InStock = true,
                ImageThumbnailUrl = "\\Images\\porksmall.jpg",
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 6,
                Name = "Lay's Ready salted crisps",
                Price = 1.48M,
                ShortDescription = "Package 207 g | 7,15 €/kg",
                LongDescription = " ",
                CategoryId = 6,
                ImageUrl = "\\Images\\lays.jpg",
                InStock = true,
                ImageThumbnailUrl = "\\Images\\layssmall.jpg",

            });

        }
    }
}
