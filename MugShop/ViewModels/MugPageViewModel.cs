using MugShop.DTOs.CategoriesDTOs;
using MugShop.DTOs.MugDTOs;

namespace MugShop.ViewModels
{
    public class MugPageViewModel
    {
        public List<GetAllMugsDto> Mugs { get; set; } = new List<GetAllMugsDto>();
        public List<GetAllCategoriesDto> Categories { get; set; } = new List<GetAllCategoriesDto>();
        public string? SelectedColor { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public List<string> AvailableColors { get; set; } = new List<string>();
    }
}
