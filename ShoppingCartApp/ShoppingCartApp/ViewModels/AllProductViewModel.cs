using ShoppingCartApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartApp.ViewModels
{
    public class AllProductViewModel
    {
        public IEnumerable<Product> Products { get; set; }
    }
}
