using System.ComponentModel.DataAnnotations;

namespace Store.Domain
{
    public class Customers
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public List<Carts> Carts { get; set; } = new List<Carts>();
        public List<Orders> Orders { get; set; } = new List<Orders>();
    }
}
