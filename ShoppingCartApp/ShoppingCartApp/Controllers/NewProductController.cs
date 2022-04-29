using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShoppingCartApp.Models;
using ShoppingCartApp.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartApp.Controllers
{
    public class NewProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public NewProductController(
            IProductRepository productRepository,
            ICategoryRepository categoryRepository
            )
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public ActionResult Index()
        {
            var allCategories = _categoryRepository.AllCategories.ToList();

            var categoryListItems = allCategories.Select(t =>
            {
                return new SelectListItem
                {
                    Text = t.CategoryName,
                    Value = t.CategoryId.ToString()
                };
            }).ToList();

            TempData["Categories"] = categoryListItems;

            return View(new NewProductViewModel());
        }

        // POST: NewProductController/Create
        [HttpPost]
        public ActionResult Create(NewProductViewModel newProduct)
        {
            if (ModelState.IsValid)
            {
                Product p = new Product()
                {
                    Name = newProduct.Name,
                    CategoryId = newProduct.CategoryID,
                    ShortDescription = newProduct.ShortDescription,
                    LongDescription = newProduct.LongDescription,
                    Price = newProduct.Price
                };

                _productRepository.AddNewProduct(p);
                _productRepository.SaveChanges();

                return RedirectToAction("ProductCreated");

            }
            return View(newProduct);
        }


        public IActionResult ProductCreated()
        {
            ViewBag.ProductCreatedMessage = "Thank you! Your product is created!";
            return View();
        }
    }
}

    

        

