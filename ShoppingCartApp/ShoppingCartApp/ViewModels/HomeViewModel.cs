using ShoppingCartApp.Repository.Entities;
using System.Collections.Generic;

namespace ShoppingCartApp.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Product> AllProducts  { get; set; }
    }
}
