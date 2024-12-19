using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Store.Domain
{
    public class OrderItems
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CartItemId { get; set; }

        [ForeignKey("CartItemId")]
        public CartItems CartItem { get; set; }

        [Required]
        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        public Orders Order { get; set; }
    }
}
