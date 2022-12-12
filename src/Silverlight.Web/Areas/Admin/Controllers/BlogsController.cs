using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Silverlight.ApplicationCore.Interfaces;

namespace Silverlight.Web.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize]
    public class BlogsController : ControllerBase
    {
        private readonly IAppLogger<BlogsController> _appLogger;
        public BlogsController(IAppLogger<BlogsController> appLogger)
        {
            _appLogger = appLogger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateOrEdit(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateOrEdit(string id)
        {
            return View();
        }
    }
}
