using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Store.Domain
{
    public class Products
    {
        public int Id { get; set; }
        public string ProductTitle { get; set; }
        public string ProductDescription { get; set; }
        public decimal UnitPrice { get; set; }
        public int ProductStock { get; set; } = 0;
        public List<CartItems> CartItems { get; set; } = new List<CartItems>();
    }
}
