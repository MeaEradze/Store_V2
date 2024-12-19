namespace Store.Domain
{
    public class OrderItems
    {
        public int Id { get; set; }
        public int CartItemId { get; set; }
        public int OrderId { get; set; }
    }
}