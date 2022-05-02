using Microsoft.AspNetCore.Mvc;
using ShoppingCartApp.Repository.Interfaces;
using System.Linq;

namespace ShoppingCartApp.Components
{
    public class CategoryMenu : ViewComponent
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryMenu(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _categoryRepository.GetAllCategories.OrderBy(c => c.CategoryName);
            return View(categories);
        }
    }
}
