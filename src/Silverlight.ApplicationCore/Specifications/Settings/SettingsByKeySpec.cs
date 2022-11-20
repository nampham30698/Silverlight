using Ardalis.Specification;
using Silverlight.ApplicationCore.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silverlight.ApplicationCore.Specifications.Settings
{
    public class SettingsByKeySpec : Specification<Entities.Settings>, ISingleResultSpecification
    {
        public SettingsByKeySpec(string key)
        {
            Query
                .Where(x => x.Key == key);
        }
    }
}
