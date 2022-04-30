using ShoppingCartApp.Repository.Entities;
using ShoppingCartApp.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCartApp.Repository.Repositories.Fake
{
    public class MockProductRepository : IProductRepository
    {
        private readonly ICategoryRepository _categoryRepository = new MockCategoryRepository();

        public IEnumerable<Product> AllProducts =>
            new List<Product>
            {
                new Product { ProductId = 1, Name = "Rustic Bread", Price=0.45M, ShortDescription = "1 units (250 g) | 1,80 €/kg", LongDescription = "The products prepared in the oven can contain as ingredients or as traces the following allergens: gluten, crustaceans shellfish, eggs, fish, peanuts, soybean, milk and dairy products, tree nuts, celery, mustard, sesame, sulphites, lupin and molluscan shellfish.", Category = _categoryRepository.AllCategories.ToList()[0], ImageUrl = "\\Images\\bread.png", InStock = true,  ImageThumbnailUrl = "\\Images\\breadsmall.jpg" },
                new Product { ProductId = 2, Name = "Cherry Tomatoes", Price=2.69M, ShortDescription = "Tray 200 g | 13,45 €/kg", LongDescription = "Dulcita cherry on the vine tomatoes", Category = _categoryRepository.AllCategories.ToList()[1], ImageUrl = "\\Images\\cherry.jpg", InStock = true,  ImageThumbnailUrl ="\\Images\\cherrysmall.jpg" },
                new Product { ProductId = 3, Name = "Golden Apple", Price=0.38M, ShortDescription = "Piece 210 g approx. | 1,79 €/kg", LongDescription = " ", Category = _categoryRepository.AllCategories.ToList()[2], ImageUrl = "\\Images\\apple.jpg", InStock = true,  ImageThumbnailUrl = "\\Images\\applesmall.jpg" },
                new Product { ProductId = 4, Name = "Coca-Cola", Price=1.84M, ShortDescription = "Coca-Cola soft drink, 2L", LongDescription = " ", Category = _categoryRepository.AllCategories.ToList()[3], ImageUrl ="\\Images\\colasmall.jpg" , InStock = true,  ImageThumbnailUrl = "\\Images\\colasmall.jpg" },
                new Product { ProductId = 5, Name = "Fleshy chunks pork ribs", Price=3.54M, ShortDescription = "Tray 530 g approx. | 6,67 €/kg", LongDescription = " ", Category = _categoryRepository.AllCategories.ToList()[4], ImageUrl = "\\Images\\pork.jpg", InStock = true,  ImageThumbnailUrl = "\\Images\\porksmall.jpg" },
                new Product { ProductId = 6, Name = "Lay's Ready salted crisps", Price=1.48M, ShortDescription = "Package 207 g | 7,15 €/kg", LongDescription = " ", Category = _categoryRepository.AllCategories.ToList()[5], ImageUrl = "\\Images\\lays.jpg", InStock = true,  ImageThumbnailUrl = "\\Images\\layssmall.jpg" },
            };



        public void AddNewProduct(Product newProduct)
        {
            throw new NotImplementedException();
        }



        public Product GetProductById(int productId)
        {
            return AllProducts.FirstOrDefault(p => p.ProductId == productId);
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }

}

