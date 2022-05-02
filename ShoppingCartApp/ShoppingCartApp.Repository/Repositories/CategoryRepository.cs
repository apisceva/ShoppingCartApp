using ShoppingCartApp.Repository.Entities;
using ShoppingCartApp.Repository.Interfaces;
using System.Collections.Generic;

namespace ShoppingCartApp.Repository.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _appDbContext;
        public CategoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Category> GetAllCategories => _appDbContext.Categories;
    }
}
