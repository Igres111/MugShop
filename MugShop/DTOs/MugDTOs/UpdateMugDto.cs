namespace MugShop.DTOs.MugDTOs
{
    public class UpdateMugDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Color { get; set; } = string.Empty;
        public bool InStock { get; set; }
        public int CategoryId { get; set; }
    }
}
