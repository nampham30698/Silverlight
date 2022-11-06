using Ardalis.Specification.EntityFrameworkCore;
using Silverlight.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silverlight.Infrastructure.Data
{
    public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class
    {
        public EfRepository(SilverlightDbContext dbContext) : base(dbContext)
        {
        }
    }
}
