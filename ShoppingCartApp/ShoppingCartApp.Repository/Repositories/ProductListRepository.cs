using ShoppingCartApp.Repository.Entities;
using ShoppingCartApp.Repository.Interfaces;
using System;
using System.Collections.Generic;

namespace ShoppingCartApp.Repository.Repositories
{
    public class ProductListRepository : IProductListRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly ShoppingCart _shoppingCart;

        public ProductListRepository(AppDbContext appDbContext, ShoppingCart shoppingCart)
        {
            _appDbContext = appDbContext;
            _shoppingCart = shoppingCart;
        }

        public void CreateProductList(ProductList productList)
        {
            productList.ProductListPlaced = DateTime.Now;
            _appDbContext.ProductLists.Add(productList);

            var shoppingCartItems = _shoppingCart.ShoppingCartItems;
            //productList.ProductListTotal = _shoppingCart.GetShoppingCartTotal();

            productList.ProductListDetails = new List<ProductListDetail>();
            //adding the product list with its details

            foreach (var shoppingCartItem in shoppingCartItems)
            {
                var productListDetail = new ProductListDetail()
                {
                    Amount = shoppingCartItem.Amount,
                    ProductId = shoppingCartItem.Product.ProductId,
                    ProductListId = productList.ProductListId,
                    Price = shoppingCartItem.Product.Price
                };

                _appDbContext.ProductLists.Add(productList);
            }



            _appDbContext.SaveChanges();
        }
    }
}
