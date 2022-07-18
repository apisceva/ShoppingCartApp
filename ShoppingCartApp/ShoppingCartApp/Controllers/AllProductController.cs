using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShoppingCartApp.Repository;
using ShoppingCartApp.Repository.Entities;
using ShoppingCartApp.Repository.Interfaces;
using ShoppingCartApp.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        [HttpPost] //httpPut
        [ValidateAntiForgeryToken]
        public IActionResult Edit(NewProductViewModel productVM) //viewmodel
        {
            if (ModelState.IsValid)
            {
                var dbProduct = _productRepository.AllProducts.FirstOrDefault(s => s.ProductId == productVM.ProductId);
                dbProduct.Name = productVM.Name;
                dbProduct.ShortDescription = productVM.ShortDescription;
                dbProduct.LongDescription = productVM.LongDescription;
                dbProduct.Price = productVM.Price;
                dbProduct.CategoryId = productVM.CategoryID;

                _productRepository.Update(dbProduct); //update (viewmodel)
                _productRepository.SaveChanges();

                return RedirectToAction("ProductUpdated");
            }      
            return View("Index");
        }
        public IActionResult ProductUpdated()
        {
            ViewBag.ProductUpdatedMessage = "Thank you! Product is updated successfully!";
            return View();
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

        //Delete
        [HttpGet] //to httpDelete (ajax call)
        public IActionResult Delete(int productId) 
        {
            var product = _productRepository.GetProductById(productId);
            if (product == null)
            {
                return NotFound();
            }
            _productRepository.Remove(product);   
            _productRepository.SaveChanges();

                return RedirectToAction("Index");

        }
      
    }
}
