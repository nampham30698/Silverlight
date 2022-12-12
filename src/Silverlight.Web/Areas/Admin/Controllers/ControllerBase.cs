using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Silverlight.Web.Areas.Admin.Controllers
{
    public class ControllerBase : Controller
    {
        public string UserId
        {
            get
            {
                var identity = HttpContext.User.Identities.First();

                var userId = identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;

                return userId;
            }
        }
    }
}
