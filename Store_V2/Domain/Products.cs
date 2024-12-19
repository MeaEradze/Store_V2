namespace Store.Domain
{
    public class Products
    {
        public int Id { get; set; }
        public string ProductTitle { get; set; }
        public string  ProductDescription { get; set; }
        public decimal UnitPrice { get; set; }
        public int ProductStock { get; set; } = 0;
    }
}
