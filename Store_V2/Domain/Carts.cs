namespace Store.Domain
{
    public class Carts
    {
        public int Id { get; set; }
        public List<CartItems> CartItems { get; set; } = new List<CartItems>();
        public int CustomerId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime LastEditedDate { get; set; }   
    }
}
