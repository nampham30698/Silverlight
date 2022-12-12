using Silverlight.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silverlight.ApplicationCore.Dtos
{
    public class CategoryDto : Category
    {
        public List<CategoryDto> Children { get; set; }
    }
}
