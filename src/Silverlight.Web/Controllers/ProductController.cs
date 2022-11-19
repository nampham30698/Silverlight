using Microsoft.AspNetCore.Mvc;
using Silverlight.ApplicationCore.Interfaces;

namespace Silverlight.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IAppLogger<ProductController> _appLogger;
        public ProductController(IAppLogger<ProductController> appLogger)
        {
            _appLogger = appLogger;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail(string proCode)
        {
            return View();
        }
    }
}
