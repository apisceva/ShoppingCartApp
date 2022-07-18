using Microsoft.EntityFrameworkCore;
using ShoppingCartApp.Repository.Entities;
using ShoppingCartApp.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCartApp.Repository.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProductRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Product> AllProducts
        {
            get
            {
                return _appDbContext.Products.Include(c => c.Category);
            }
        }

        public Product GetProductById(int productId)
        {
            return _appDbContext.Products.FirstOrDefault(p => p.ProductId == productId);
        }

        public void AddNewProduct(Product newProduct)
        {
            // newProduct.NewProductAdded = DateTime.Now;
            _appDbContext.Products.Add(newProduct);
        }

        public void SaveChanges()
        {
            _appDbContext.SaveChanges();
        }
        public void Update(Product product)
        {
            _appDbContext.Products.Update(product);
        }

        public void Remove(Product product)
        {
            _appDbContext.Products.Remove(product);
        }

    }
}

