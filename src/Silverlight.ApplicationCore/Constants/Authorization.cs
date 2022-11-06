using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silverlight.ApplicationCore.Constants
{
    public static partial class Constants
    {
        public static class Authorization
        {
            public const string AUTH_KEY = "AuthKeyOfDoomThatMustBeAMinimumNumberOfBytes";

            // TODO: Don't use this in production
            public const string DEFAULT_PASSWORD = "Nothing123$";

            // TODO: Change this to an environment variable
            public const string JWT_SECRET_KEY = "SecretKeyOfDoomThatMustBeAMinimumNumberOfBytes";
        }

    }
}
