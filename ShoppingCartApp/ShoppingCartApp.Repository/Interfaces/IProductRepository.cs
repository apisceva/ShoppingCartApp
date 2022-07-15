using ShoppingCartApp.Repository.Entities;
using System.Collections.Generic;

namespace ShoppingCartApp.Repository.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> AllProducts { get; }
        Product GetProductById(int productId);
        void AddNewProduct(Product newProduct);
        void SaveChanges();
        void Update(Product product);
        void Remove(Product product);
    }
}
