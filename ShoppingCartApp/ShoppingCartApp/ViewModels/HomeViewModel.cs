using ShoppingCartApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartApp.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Product> AllProducts  { get; set; }
    }
}
