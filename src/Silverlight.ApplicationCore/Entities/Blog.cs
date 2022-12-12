using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Silverlight.ApplicationCore.Entities
{
    public class Blog : EntityBase<int>
    {
        public string Title { get; set; }
        public string TitleShort { get; set; }
        public string Description { get; set; }
        public string UrlImage { get; set; }
        public string Contents { get; set; }
        public bool? IsActive { get; set; }
        public int? CreationYear { get; set; }
        public int? CreationMonth { get; set; }
        public int? CreationDay { get; set; }
    }
}
