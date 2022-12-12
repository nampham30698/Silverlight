using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silverlight.ApplicationCore.Entities
{
    public class Blog_Tag : EntityBase<int>
    {
        public int? BlogId { get; set; }
        public string TagName { get; set; }
        public string TagNameShort { get; set; }
    }
}
