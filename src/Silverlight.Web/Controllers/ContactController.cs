using Microsoft.AspNetCore.Mvc;
using Silverlight.ApplicationCore.Interfaces;

namespace Silverlight.Web.Controllers
{
    public class ContactController : Controller
    {
        private readonly IAppLogger<ContactController> _appLogger;
        public ContactController(IAppLogger<ContactController> appLogger)
        {
            _appLogger = appLogger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
