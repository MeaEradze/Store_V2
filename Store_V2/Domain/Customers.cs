using System.ComponentModel.DataAnnotations;

namespace Store.Domain
{
    public class Customers
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(100)]
        public string Address { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        public List<Carts> Carts { get; set; } = new List<Carts>();
        public List<Orders> Orders { get; set; } = new List<Orders>();
    }
}
