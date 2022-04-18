using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingCartApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartApp.Controllers
{
    [Authorize]
    public class ProductListController : Controller
    {
        private readonly IProductListRepository _productListRepository;
        private readonly ShoppingCart _shoppingCart;

        public ProductListController(IProductListRepository productListRepository, ShoppingCart shoppingCart)
        {
            _productListRepository = productListRepository;
            _shoppingCart = shoppingCart;
        }

        // GET: /<controller>/
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(ProductList productList)
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            if (_shoppingCart.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Your cart is empty, add some products first");
            }

            if (ModelState.IsValid)
            {
                _productListRepository.CreateProductList(productList);
                _shoppingCart.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }
            return View(productList);
        }

        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thank you! Your product list is ready!";
            return View();
        }
    }
}
    

