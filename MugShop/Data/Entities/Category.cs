namespace MugShop.Data.Entities
{
    public class Category:BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Mug> Mugs { get; set; } = new List<Mug>();
    }
}
