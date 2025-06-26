namespace MugShop.DTOs.MugDTOs
{
    public class FilterInfoDto
    {
        public string? Color { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? SortBy { get; set; } = string.Empty;
    }
}
