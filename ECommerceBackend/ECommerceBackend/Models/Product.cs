namespace ECommerceBackend.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int CreatedBy { get; set; }

        public User Creator { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
