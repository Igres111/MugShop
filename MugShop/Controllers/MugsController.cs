using Microsoft.AspNetCore.Mvc;
using MugShop.DTOs.MugDTOs;
using MugShop.Service.Implementations.CategoryRepos;
using MugShop.Service.Interfaces.CategoriesInterfaces;
using MugShop.Service.Interfaces.MugInterfaces;
using MugShop.ViewModels;

namespace MugShop.Controllers
{
    public class MugsController : Controller
    {

        public readonly IMug _mugRepo;
        public readonly ICategory _categoryRepo;
        public MugsController(IMug mugRepo, ICategory categoryRepo)
        {
            _mugRepo = mugRepo;
            _categoryRepo = categoryRepo;
        }

        public async Task<IActionResult> Index(string? color, decimal? minPrice, decimal? maxPrice)
        {
            var mugsResponse = await _mugRepo.GetAllMugs(color,minPrice,maxPrice);
            var categoriesResponse = await _categoryRepo.GetAllCategories();
            if (!mugsResponse.IsSuccess)
            {
                return BadRequest(mugsResponse.Error);
            }
            var viewModel = new MugPageViewModel
            {
                Mugs = mugsResponse.Mugs,
                Categories = categoriesResponse.Categories,
                SelectedColor = color,
                MinPrice = minPrice,
                MaxPrice = maxPrice,
                AvailableColors = mugsResponse.AvailableColors
            };
            return View(viewModel);
        }
    }
}
