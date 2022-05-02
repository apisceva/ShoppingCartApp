using ShoppingCartApp.Repository.Entities;
using System.Collections.Generic;

namespace ShoppingCartApp.Repository.Interfaces

{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAllCategories { get; }
    }
}
