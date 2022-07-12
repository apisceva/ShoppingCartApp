using Microsoft.AspNetCore.Mvc;
using ShoppingCartApp.Repository;
using ShoppingCartApp.Repository.Entities;
using ShoppingCartApp.Repository.Interfaces;
using ShoppingCartApp.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCartApp.Controllers
{
    public class AllProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public AllProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            var products = _productRepository.AllProducts;

            return View(products);
        }

    }
}
