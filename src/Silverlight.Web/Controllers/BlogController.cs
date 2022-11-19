using Microsoft.AspNetCore.Mvc;
using Silverlight.ApplicationCore.Interfaces;

namespace Silverlight.Web.Controllers
{
	public class BlogController : Controller
    {
        private readonly IAppLogger<BlogController> _appLogger;
        public BlogController(IAppLogger<BlogController> appLogger)
        {
            _appLogger = appLogger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail(string titleUrl)
        {
            return View();
        }
    }
}
