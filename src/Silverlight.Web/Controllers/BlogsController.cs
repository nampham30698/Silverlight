using Microsoft.AspNetCore.Mvc;
using Silverlight.ApplicationCore.Interfaces;

namespace Silverlight.Web.Controllers
{
	public class BlogsController : Controller
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

        [Route("/Blogs/{titleShort}")]
        public IActionResult Details(string titleShort)
        {
            return View();
        }

        [Route("/Blogs/Tags/{tagName}")]
        public IActionResult Tags(string tagName)
        {
            return View();
        }

        [Route("/Blogs/Categories/{categoryName}")]
        public IActionResult Categories(string categoryName)
        {
            return View();
        }

        [Route("/Blogs/{year}/{month}")]
        public IActionResult Date(int year, int month)
        {
            return View();
        }
    }
}
