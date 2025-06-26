using Microsoft.AspNetCore.Mvc;
using MugShop.Service.Interfaces.CategoriesInterfaces;

namespace MugShop.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategory _categoryRepo;
        public CategoriesController(ICategory categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

    }
}
