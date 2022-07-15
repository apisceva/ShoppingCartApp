using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShoppingCartApp.Repository.Entities;
using ShoppingCartApp.Repository.Interfaces;
using ShoppingCartApp.ViewModels;
using System.Linq;

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
            return SetCategories();
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
            SetCategories();
            return View("Index", newProduct);
        }
        public IActionResult ProductCreated()
        {
            ViewBag.ProductCreatedMessage = "Thank you! Your product is added!";
            return View();
        }
    }
}

    

        

