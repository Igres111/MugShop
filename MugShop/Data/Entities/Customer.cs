namespace MugShop.Data.Entities
{
    public class Customer:BaseEntity
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
