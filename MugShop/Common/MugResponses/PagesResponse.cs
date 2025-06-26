using MugShop.DTOs.MugDTOs;

namespace MugShop.Common.MugResponses
{
    public class PagesResponse
    {
        public List<GetAllMugsDto> Items { get; set; } = new();
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
    }
}
