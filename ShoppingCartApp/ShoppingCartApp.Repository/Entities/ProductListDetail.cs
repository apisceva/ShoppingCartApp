namespace ShoppingCartApp.Repository.Entities
{
    public class ProductListDetail
    {
        public int ProductListDetailId { get; set; }
        public int ProductListId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public Product Product { get; set; }
        public ProductList ProductList { get; set; }
    }
}
