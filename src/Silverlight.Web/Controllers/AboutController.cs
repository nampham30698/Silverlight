using Microsoft.AspNetCore.Mvc;
using Silverlight.ApplicationCore.Interfaces;

namespace Silverlight.Web.Controllers
{
	public class AboutController : Controller
    {
        private readonly IAppLogger<AboutController> _appLogger;
        public AboutController(IAppLogger<AboutController> appLogger)
        {
            _appLogger = appLogger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
