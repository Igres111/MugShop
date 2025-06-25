using Microsoft.EntityFrameworkCore;
using MugShop.Common;
using MugShop.Common.MugResponses;
using MugShop.Data;
using MugShop.Data.Entities;
using MugShop.DTOs.MugDTOs;
using MugShop.Helpers;
using MugShop.Service.Interfaces.MugInterfaces;

namespace MugShop.Service.Implementations
{
    public class MugRepo : IMug
    {
        public readonly AppDbContext _appDbContext;
        public readonly SKUGenerator _skuGenerator;
        public MugRepo(AppDbContext appDbContext, SKUGenerator skuGenerator)
        {
            _appDbContext = appDbContext;
            _skuGenerator = skuGenerator;
        }
        public async Task<APIResponse> CreateMug(CreateMugDto mugInfo)
        {
            var categoryExists = await _appDbContext.Categories
                .Where(c => c.DeletedAt == null)
                .FirstOrDefaultAsync(c => c.Id == mugInfo.CategoryId);
            if (categoryExists == null)
            {
                return new APIResponse
                {
                    IsSuccess = false,
                    Error = "Category not found"
                };
            }
            if (string.IsNullOrWhiteSpace(mugInfo.Name) || string.IsNullOrWhiteSpace(mugInfo.Color))
            {
                return new APIResponse
                {
                    IsSuccess = false,
                    Error = "Name and Color cannot be empty"
                };
            }

            var newSKU = _skuGenerator.GenerateSKU(mugInfo.Name, mugInfo.Color, categoryExists.Name);

            var existsSKU = await _appDbContext.Mugs.AnyAsync(m => m.SKU == newSKU);
            if (existsSKU)
            {
                return new APIResponse
                {
                    IsSuccess = false,
                    Error = "SKU already exists"
                };
            }
            var newMug = new Mug
            {
                Name = mugInfo.Name,
                Description = mugInfo.Description,
                Price = mugInfo.Price,
                Color = mugInfo.Color,
                InStock = mugInfo.InStock,
                CategoryId = mugInfo.CategoryId,
                SKU = newSKU,
                UpdatedAt = DateTime.UtcNow,
            };
            await _appDbContext.Mugs.AddAsync(newMug);
            await _appDbContext.SaveChangesAsync();
            return new APIResponse
            {
                IsSuccess = true
            };
        }
        public async Task<GetAllMugsResponse> GetAllMugs()
        {
           var mugsExist = await _appDbContext.Mugs
                .Where(mugs => mugs.DeletedAt == null)
                .ToListAsync();
            if(mugsExist.Count == 0)
            {
                return new GetAllMugsResponse
                {
                    IsSuccess = false,
                    Error = "No mugs found"
                };
            }

            var mugsToReturn = mugsExist.Select(mugs => new GetAllMugsDto
            {
                Id = mugs.Id,
                Name = mugs.Name,
                Description = mugs.Description,
                Price = mugs.Price,
                Color = mugs.Color,
                InStock = mugs.InStock,
                CategoryId = mugs.CategoryId,
                SKU = mugs.SKU,
            }).ToList();

            return new GetAllMugsResponse
            {
                IsSuccess = true,
                Mugs = mugsToReturn
            };
        }
    }
}
