using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Silverlight.ApplicationCore.Interfaces;
using Silverlight.Web.Controllers;

namespace Silverlight.Web.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly IAppLogger<CategoryController> _appLogger;
        private readonly ICategoryService _categoryService;
        public CategoryController(IAppLogger<CategoryController> appLogger,
                                  ICategoryService categoryService)
        {
            _appLogger = appLogger;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
