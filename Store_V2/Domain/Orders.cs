using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Store.Domain
{
    public class Orders
    {
        [Key]
        public int Id { get; set; }

        public List<OrderItems> OrderItems { get; set; } = new List<OrderItems>();

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public Customers Customer { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }
    }
}
