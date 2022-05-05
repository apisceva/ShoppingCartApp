using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShoppingCartApp.Repository.Entities;
using ShoppingCartApp.Repository.Interfaces;
using ShoppingCartApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        // GET: /<controller>/
        //public IActionResult List()
        //{
        //    //ViewBag.CurrentCategory = "Bakery";

        //    //return View(_productRepository.AllProducts);
        //    ProductsListViewModel productsListViewModel = new ProductsListViewModel();
        //    productsListViewModel.Products = _productRepository.AllProducts;

        //    productsListViewModel.CurrentCategory = "AllProducts";
        //    return View(productsListViewModel);
        //}
        public ViewResult List(string categoryId, string searchText)
        {
            SetCategories();


            IEnumerable<Product> products;
            string currentCategory;

            if (string.IsNullOrEmpty(categoryId))
            {
                products = _productRepository.AllProducts.OrderBy(p => p.ProductId);
                currentCategory = "All products";
            }
            else
            {
                products = _productRepository.AllProducts.Where(p => p.CategoryId.ToString() == categoryId)
                    .OrderBy(p => p.ProductId);
                currentCategory = _categoryRepository.GetAllCategories.FirstOrDefault(c => c.CategoryName == categoryId)?.CategoryName;
            }

            return View(new ProductsListViewModel
            {
                Products = products,
                CurrentCategory = currentCategory
            });
        }


        public IActionResult Details(int id)
        {
            var product = _productRepository.GetProductById(id);
            if (product == null)
                return NotFound();

            return View(product);
        }
        private void SetCategories()
        {
            var allCategories = _categoryRepository.GetAllCategories.ToList();

            var categoryListItems = allCategories.Select(t =>
            {
                return new SelectListItem
                {
                    Text = t.CategoryName,
                    Value = t.CategoryId.ToString()
                };
            }).ToList();

            var emptySelectListItem = new SelectListItem
            {
                Text = "Please select category",
                Value = 0.ToString()
            };
            categoryListItems = categoryListItems.Prepend(emptySelectListItem).ToList();

            TempData["Categories"] = categoryListItems;
        }

    }
}
