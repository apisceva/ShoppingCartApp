using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        private readonly ICategoryRepository _categoryRepository;

        public AllProductController(
            IProductRepository productRepository,
            ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            var products = _productRepository.AllProducts;

            return View(products);
        }

        //GET
        public ActionResult Edit(int productId)
        {
            SetCategories();

            var product = _productRepository.GetProductById(productId);
            if (product == null)
            {
                return NotFound();
            }
            var productViewModel = new NewProductViewModel()
            {
                Name = product.Name,
                ProductId = product.ProductId,
                CategoryID = product.CategoryId,
                ShortDescription = product.ShortDescription,
                LongDescription = product.LongDescription,
                Price = product.Price,
            };
            return View("Edit", productViewModel);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _productRepository.Remove(product);
                _productRepository.SaveChanges();

                return RedirectToAction("Index");
            }       
            return View("Index");
        }
        private ActionResult SetCategories()
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
            return View(new NewProductViewModel());
        }

        //GET
        public ActionResult Delete(int productId)
        {
            SetCategories();

            var product = _productRepository.GetProductById(productId);
            if (product == null)
            {
                return NotFound();
            }
            var productViewModel = new NewProductViewModel()
            {
                Name = product.Name,
                ProductId = product.ProductId,
                CategoryID = product.CategoryId,
                ShortDescription = product.ShortDescription,
                LongDescription = product.LongDescription,
                Price = product.Price,
            };
            return View("Delete", productViewModel);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Product product)
        {
            if (ModelState.IsValid)
            {
                _productRepository.Remove(product);
                _productRepository.SaveChanges();

                return RedirectToAction("Index");
            }
            return View("Index");
        }
    }
}
