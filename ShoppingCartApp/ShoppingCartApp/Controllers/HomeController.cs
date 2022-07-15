using Microsoft.AspNetCore.Mvc;
using ShoppingCartApp.Repository.Interfaces;
using ShoppingCartApp.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository _productRepository;

        public HomeController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                AllProducts = _productRepository.AllProducts
            };

            return View(homeViewModel);
        }       
    }
}
