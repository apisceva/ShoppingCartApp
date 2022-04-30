using ShoppingCartApp.Repository.Entities;
using System.Collections.Generic;

namespace ShoppingCartApp.ViewModels
{
    public class AllProductViewModel
    {
        public IEnumerable<Product> Products { get; set; }
    }
}
