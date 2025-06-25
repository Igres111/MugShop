namespace MugShop.Data.Entities
{
    public class Order:BaseEntity
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string OrderStatus { get; set; } = string.Empty;
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = new Customer();
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
