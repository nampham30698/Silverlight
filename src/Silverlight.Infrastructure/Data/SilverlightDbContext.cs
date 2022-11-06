using Microsoft.EntityFrameworkCore;
using Silverlight.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Silverlight.Infrastructure.Data
{
    public class SilverlightDbContext : DbContext
    {
        public SilverlightDbContext(DbContextOptions<SilverlightDbContext> options) : base(options)
        {

        }

        // add entity here

        //public DbSet<Users> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
