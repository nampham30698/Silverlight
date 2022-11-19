using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silverlight.ApplicationCore.Entities
{
    public class EntityBase<TId>
    {
        public TId Id { get; set; }
        public DateTime? CreationTime { get; set; }
        public Guid? CreatorUserId { get; set; }
    }
}
