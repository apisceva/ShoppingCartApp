﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartApp.Models
{
    public interface IProductListRepository
    {
        void CreateProductList(ProductList productList);
    }
}
