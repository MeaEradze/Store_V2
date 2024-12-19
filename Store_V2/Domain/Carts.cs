using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Store.Domain
{
    public class Carts
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customers Customer { get; set; }
        public List<CartItems> CartItems { get; set; } = new List<CartItems>();
        public decimal TotalPrice { get; set; }
        public DateTime LastEditedDate { get; set; }
    }
}
