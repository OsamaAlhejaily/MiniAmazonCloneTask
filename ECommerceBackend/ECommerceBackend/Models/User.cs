namespace ECommerceBackend.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public ICollection<Order> Orders { get; set; }
        public ICollection<Product> CreatedProducts { get; set; }
    }
}
