using Microsoft.EntityFrameworkCore;
using MugShop.Common.CategoriesResponses;
using MugShop.Data;
using MugShop.DTOs.CategoriesDTOs;
using MugShop.Service.Interfaces.CategoriesInterfaces;

namespace MugShop.Service.Implementations.CategoryRepos
{
    public class CategoryRepo:ICategory
    {
        public readonly AppDbContext _context;
        public CategoryRepo(AppDbContext context)
        {
            _context = context;
        }
        public async Task<GetAllCategoriesResponse> GetAllCategories()
        {
            var categories = await _context.Categories
                .Where(c => c.DeletedAt == null)
                .Include(c => c.Mugs)
                .ToListAsync();

            if(categories == null )
            {
                return new GetAllCategoriesResponse
                {
                    IsSuccess = false,
                    Error = "No categories found."
                };
            }

            var result = categories.Select(c => new GetAllCategoriesDto
            {
                Id = c.Id,
                Name = c.Name,
                Mugs = c.Mugs
            }).ToList();

            return new GetAllCategoriesResponse
            {
                IsSuccess = true,
                Categories = result
            };
        }
    }
}
