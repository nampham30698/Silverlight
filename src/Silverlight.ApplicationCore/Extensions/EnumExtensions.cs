using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Silverlight.ApplicationCore.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(Enum value)
        {
            try
            {
                var fi = value.GetType().GetField(value.ToString());
                if (fi == null)
                {
                    return "";
                }

                var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

                return attributes.Length > 0 ? attributes[0].Description : value.ToString();
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
