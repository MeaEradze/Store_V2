namespace Store.Domain
{
    public class Orders
    {
        public int Id { get; set; }
        public List<OrderItems> OrderItems { get; set; } = new List<OrderItems>();
        public decimal TotalPrice { get; set; }
        public int CustomerId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
