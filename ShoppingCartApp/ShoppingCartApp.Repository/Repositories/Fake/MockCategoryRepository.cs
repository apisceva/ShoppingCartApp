using ShoppingCartApp.Repository.Entities;
using ShoppingCartApp.Repository.Interfaces;
using System.Collections.Generic;

namespace ShoppingCartApp.Repository.Repositories.Fake
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> AllCategories =>
            new List<Category>
            {
                new Category{CategoryId=1, CategoryName="Bakery", Description="Bakery Products"},
                new Category{CategoryId=2, CategoryName="Vegetables", Description="All Vegetables"},
                new Category{CategoryId=3, CategoryName="Fruits", Description="All Fruits"},
                new Category{CategoryId=4, CategoryName="Drinks", Description="All Drinks"},
                new Category{CategoryId=5, CategoryName="Meat", Description="All Meat"},
                new Category{CategoryId=6, CategoryName="Snacks", Description="All Snacks"}

            };
    }
}
