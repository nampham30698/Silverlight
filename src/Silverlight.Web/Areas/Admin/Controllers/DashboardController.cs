﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Silverlight.Web.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize]
    public class DashboardController : ControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
