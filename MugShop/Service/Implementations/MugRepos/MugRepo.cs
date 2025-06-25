using Microsoft.EntityFrameworkCore;
using MugShop.Common;
using MugShop.Common.MugResponses;
using MugShop.Data;
using MugShop.Data.Entities;
using MugShop.DTOs.MugDTOs;
using MugShop.Helpers;
using MugShop.Service.Interfaces.MugInterfaces;

namespace MugShop.Service.Implementations.MugRepos
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
        public async  Task<APIResponse> UpdateMug(UpdateMugDto mugInfo)
        {
          var mugExists = await _appDbContext.Mugs
                .Where(mugs => mugs.DeletedAt == null)
                .FirstOrDefaultAsync(mugs => mugs.Id == mugInfo.Id);

            if (mugExists == null)
            {
                return new APIResponse
                {
                    IsSuccess = false,
                    Error = "Mug not found"
                };
            }
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
            if(mugInfo.Name != mugExists.Name
                || mugInfo.Color != mugExists.Color
                || categoryExists.Name != mugExists.Category.Name)
            {
               var newSKU = _skuGenerator.GenerateSKU(mugInfo.Name, mugInfo.Color, categoryExists.Name);

                var existsSKU = await _appDbContext.Mugs
                    .Where(mugs => mugs.DeletedAt == null)
                    .AnyAsync(mugs => mugs.SKU == newSKU);

                if (existsSKU)
                {
                    return new APIResponse
                    {
                        IsSuccess = false,
                        Error = "SKU already exists"
                    };
                }
                mugExists.SKU = newSKU;
            }
            mugExists.Name = mugInfo.Name != null ? mugInfo.Name : mugExists.Name;
            mugExists.Description = mugInfo.Description != null ? mugInfo.Description : mugExists.Description;
            mugExists.Price = mugInfo.Price <= 0 ? mugExists.Price : mugInfo.Price;
            mugExists.Color = mugInfo.Color != null ? mugInfo.Color : mugExists.Color;
            mugExists.InStock = mugInfo.InStock;
            mugExists.CategoryId = mugInfo.CategoryId;
            mugExists.UpdatedAt = DateTime.UtcNow;

            await _appDbContext.SaveChangesAsync();
            return new APIResponse
            {
                IsSuccess = true
            };
        }
        public async Task<APIResponse> DeleteMug(int id)
        {
            var mugExists = await _appDbContext.Mugs
                .Where(mugs => mugs.DeletedAt == null)
                .FirstOrDefaultAsync(mugs => mugs.Id == id);

            if (mugExists == null)
            {
                return new APIResponse
                {
                    IsSuccess = false,
                    Error = "Mug not found"
                };
            }

            mugExists.DeletedAt = DateTime.UtcNow;
            await _appDbContext.SaveChangesAsync();
            return new APIResponse
            {
                IsSuccess = true
            };
        }
    }
}
