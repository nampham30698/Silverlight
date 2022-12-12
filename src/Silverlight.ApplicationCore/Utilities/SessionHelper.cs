using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Silverlight.ApplicationCore.Utilities
{
    public static class SessionHelper
    {
       public static string UserId
       {
            get
            {
                var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;

                var userId = identity.Claims.Where(c => c.Type == "UserId").Select(c => c.Value).SingleOrDefault();

                return userId;
            }
            set => UserId = value;
       }
    }
}
