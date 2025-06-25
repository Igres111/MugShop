using Microsoft.AspNetCore.Mvc;

namespace MugShop.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
