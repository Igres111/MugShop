namespace MugShop.Data.Entities
{
    public class OrderItem:BaseEntity
    {
        public int Id { get; set; }
        public Order Order { get; set; } = new Order(); 
        public int OrderId { get; set; }
        public int MugId { get; set; }
        public Mug Mug { get; set; } = new Mug();
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
