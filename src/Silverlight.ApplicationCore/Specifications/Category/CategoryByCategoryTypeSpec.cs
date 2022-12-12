using Ardalis.Specification;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silverlight.ApplicationCore.Specifications
{
    public class CategoryLv1Spec : Specification<Entities.Category>, ISingleResultSpecification
    {
        public CategoryLv1Spec(int? categoryType)
        {
            Query
                .Where(x => !x.ParentId.HasValue || x.ParentId == 0)
                .Where(x => !categoryType.HasValue || x.CategoryType == categoryType);
        }
    }

    public class CategoryByParentSpec : Specification<Entities.Category>, ISingleResultSpecification
    {
        public CategoryByParentSpec(int parentId)
        {
            Query
                .Where(x => x.ParentId == parentId);
        }
    }
}
