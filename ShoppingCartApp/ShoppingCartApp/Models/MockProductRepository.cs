using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartApp.Models
{
    public class MockProductRepository : IProductRepository
    {
        private readonly ICategoryRepository _categoryRepository = new MockCategoryRepository();

        public IEnumerable<Product> AllProducts =>
            new List<Product>
            {
                new Product { ProductId = 1, Name = "Rustic Bread", Price=1.45M, ShortDescription = "Rustic Bread", LongDescription = "The products prepared in the oven can contain as ingredients or as traces the following allergens: gluten, crustaceans shellfish, eggs, fish, peanuts, soybean, milk and dairy products, tree nuts, celery, mustard, sesame, sulphites, lupin and molluscan shellfish.", Category = _categoryRepository.AllCategories.ToList()[0], ImageUrl = "", InStock = true,  /*ImageThumbnailUrl*/ },
                new Product { ProductId = 2, Name = "Cherry Tomatoes", Price=2.69M, ShortDescription = "Cherry Tomatoes", LongDescription = "Dulcita cherry on the vine tomatoes", Category = _categoryRepository.AllCategories.ToList()[1], ImageUrl = "", InStock = true,  /*ImageThumbnailUrl*/ },
                new Product { ProductId = 3, Name = "Golden Apple", Price=0.38M, ShortDescription = "Piece 210 g approx. | 1,79 €/kg", LongDescription = " ", Category = _categoryRepository.AllCategories.ToList()[2], ImageUrl = "", InStock = true,  /*ImageThumbnailUrl*/ },
                new Product { ProductId = 4, Name = "Coca-Cola", Price=1.84M, ShortDescription = "Coca-Cola soft drink, 2L", LongDescription = " ", Category = _categoryRepository.AllCategories.ToList()[3], ImageUrl = "", InStock = true,  /*ImageThumbnailUrl*/ },
                new Product { ProductId = 5, Name = "Fleshy chunks pork ribs", Price=3.54M, ShortDescription = "Tray 530 g approx. | 6,67 €/kg", LongDescription = " ", Category = _categoryRepository.AllCategories.ToList()[4], ImageUrl = "", InStock = true,  /*ImageThumbnailUrl*/ },
                new Product { ProductId = 6, Name = "Lay's Ready salted crisps", Price=1.48M, ShortDescription = "Package 207 g | 7,15 €/kg", LongDescription = " ", Category = _categoryRepository.AllCategories.ToList()[5], ImageUrl = "", InStock = true,  /*ImageThumbnailUrl*/ },
            };

        public Product GetProductById(int productId)
        {
            return AllProducts.FirstOrDefault(p => p.ProductId == productId);
        }
    }
  
}

