//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace ShoppingCartApp.Models
//{
//    public class ProductRepository : IProductRepository
//    {
//        private readonly AppDbContext _appDbContext;

//        public ProductRepository(AppDbContext appDbContext)
//        {
//            _appDbContext = appDbContext;
//        }

//        public IEnumerable<Product> AllProducts
//        {
//            get
//            {
//                return _appDbContext.Pies.Include(c => c.Category);
//            }
//        }


//        public Product GetProductById(int productId)
//        {
//            return _appDbContext.Products.FirstOrDefault(p => p.ProductId == productId);
//        }
//    }
//}

