namespace ECommerceBackend.Dtos
{
    public class OrderCreateDto
    {
        public decimal TotalAmount { get; set; }
        public List<OrderItemDto> Items { get; set; }
    }

    public class OrderItemDto
    {
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}