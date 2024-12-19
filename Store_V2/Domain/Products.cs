using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Store.Domain
{
    public class Products
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string ProductTitle { get; set; }

        [MaxLength(500)]
        public string ProductDescription { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }

        [Required]
        public int ProductStock { get; set; } = 0;

        public List<CartItems> CartItems { get; set; } = new List<CartItems>();
    }
}
