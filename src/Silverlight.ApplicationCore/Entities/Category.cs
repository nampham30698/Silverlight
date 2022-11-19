using Silverlight.ApplicationCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silverlight.ApplicationCore.Entities
{
    public class Category : EntityBase<int>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Order { get; set; }  
        public int? CategoryType { get; set; }
        public int? ParentId { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? DeletionTime { get; set; }
    }
}
