using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ShoppingCartApp.Repository.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
       
    }
}
