using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Store.Domain
{
    public class OrderItems
    {
        public int Id { get; set; }
        public int CartItemId { get; set; }
        public CartItems CartItem { get; set; }
        public int OrderId { get; set; }
        public Orders Order { get; set; }
    }
}
