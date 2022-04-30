using ShoppingCartApp.Repository.Entities;

namespace ShoppingCartApp.Repository.Interfaces
{
    public interface IProductListRepository
    {
        void CreateProductList(ProductList productList);
    }
}
