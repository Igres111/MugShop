using Microsoft.EntityFrameworkCore;
using MugShop.Common;
using MugShop.Common.CategoriesResponses;
using MugShop.Data;
using MugShop.Data.Entities;
using MugShop.DTOs.CategoriesDTOs;
using MugShop.Service.Interfaces.CategoriesInterfaces;

namespace MugShop.Service.Implementations.CategoryRepos
{
    public class CategoryRepo : ICategory
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
                .ToListAsync();

            if (categories == null)
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
            }).ToList();

            return new GetAllCategoriesResponse
            {
                IsSuccess = true,
                Categories = result
            };
        }
        public async Task<APIResponse> CreateCategory(string name)
        {
            var categoryExists = await _context.Categories
                .AnyAsync(c => c.Name == name && c.DeletedAt == null);
            if (categoryExists)
            {
                return new APIResponse
                {
                    IsSuccess = false,
                    Error = "Category already exists."
                };
            }
            var category = new Category
            {
                Name = name,
                CreatedAt = DateTime.UtcNow
            };
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return new APIResponse
            {
                IsSuccess = true
            };
        }
        public async Task<APIResponse> UpdateCategory(string name)
        {
            var category = await _context.Categories
                .FirstOrDefaultAsync(c => c.Name == name && c.DeletedAt == null);
            if (category == null)
            {
                return new APIResponse
                {
                    IsSuccess = false,
                    Error = "Category not found."
                };
            }
            category.Name = name != null ? name : category.Name;
            category.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return new APIResponse
            {
                IsSuccess = true,
            };
        }
        public async Task<APIResponse> DeleteCategory(int id)
        {
            var category = await _context.Categories
                .FirstOrDefaultAsync(c => c.Id == id && c.DeletedAt == null);
            if (category == null)
            {
                return new APIResponse
                {
                    IsSuccess = false,
                    Error = "Category not found."
                };
            }
            category.DeletedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return new APIResponse
            {
                IsSuccess = true,
            };
        }
    }
}
