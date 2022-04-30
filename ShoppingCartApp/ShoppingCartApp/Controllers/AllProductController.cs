﻿using Microsoft.AspNetCore.Mvc;
using ShoppingCartApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartApp.Controllers
{
    public class AllProductController : Controller
    {
        //private readonly IProductRepository _productRepository;
        private AppDbContext Context { get; }
        public AllProductController(AppDbContext _context)
        {
            this.Context = _context;
        }

        //public AllProductController(IProductRepository productRepository)
        //{
        //    _productRepository = productRepository;
        //}

        public IActionResult Index()
        {
            List<Product> products = (from product in this.Context.Products.Take(50)

                                        select product).ToList();
            return View();
        }
    }
}
