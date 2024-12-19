namespace Store.Domain
{
    public class CartItems
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public int CartId { get; set; }   
    }
}