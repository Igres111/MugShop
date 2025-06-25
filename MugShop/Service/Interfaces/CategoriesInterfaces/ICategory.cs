using MugShop.Common.CategoriesResponses;

namespace MugShop.Service.Interfaces.CategoriesInterfaces
{
    public interface ICategory
    {
        public Task<GetAllCategoriesResponse> GetAllCategories();
    }
}
