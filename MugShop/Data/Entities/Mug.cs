namespace MugShop.Data.Entities
{
    public class Mug : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Color { get; set; } = string.Empty;
        public string SKU { get; set; } = string.Empty;
        public bool InStock { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; } = new Category();
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
