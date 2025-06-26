using Microsoft.AspNetCore.Mvc;
using MugShop.DTOs.MugDTOs;
using MugShop.Service.Implementations.CategoryRepos;
using MugShop.Service.Interfaces.CategoriesInterfaces;
using MugShop.Service.Interfaces.MugInterfaces;
using MugShop.ViewModels;
using System.IO;

namespace MugShop.Controllers
{
    public class MugsController : Controller
    {

        public readonly IMug _mugRepo;
        public MugsController(IMug mugRepo)
        {
            _mugRepo = mugRepo;
        }

        public async Task<IActionResult> Index([FromQuery]FilterInfoDto filterInfo)
        {
            var mugsResponse = await _mugRepo.GetAllMugs(filterInfo);
            if (!mugsResponse.IsSuccess)
            {
                return BadRequest(mugsResponse.Error);
            }
            return View(mugsResponse.ViewModel);
        }
    }
}
