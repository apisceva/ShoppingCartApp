using ShoppingCartApp.Repository.Entities;
using System.Collections.Generic;

namespace ShoppingCartApp.ViewModels
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public string CurrentCategory { get; set; }
    }
}
