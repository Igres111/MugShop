using MugShop.Common;
using MugShop.Common.CategoriesResponses;
using MugShop.DTOs.CategoriesDTOs;

namespace MugShop.Service.Interfaces.CategoriesInterfaces
{
    public interface ICategory
    {
        public Task<GetAllCategoriesResponse> GetAllCategories();
        public Task<APIResponse> CreateCategory(string name);
        public Task<APIResponse> UpdateCategory(string name);
        public Task<APIResponse> DeleteCategory(int id);
    }
}
