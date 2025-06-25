using Microsoft.AspNetCore.Mvc;
using MugShop.DTOs.MugDTOs;
using MugShop.Service.Interfaces.MugInterfaces;

namespace MugShop.Controllers
{
    public class MugsController : Controller
    {

        public readonly IMug _mugRepo;
        public MugsController(IMug mugRepo)
        {
            _mugRepo = mugRepo;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _mugRepo.GetAllMugs();
            if (!result.IsSuccess)
            {
                return BadRequest(new List<GetAllMugsDto>());
            }
            return View(result.Mugs);
        }
    }
}
