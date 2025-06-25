using MugShop.DTOs.CategoriesDTOs;

namespace MugShop.Common.CategoriesResponses
{
    public class GetAllCategoriesResponse:APIResponse
    {
        public List<GetAllCategoriesDto> Categories { get; set; } = new List<GetAllCategoriesDto>();
    }
}
