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
        #pragma warning disable CS8618 // Required by Entity Framework
        public SilverlightDbContext(DbContextOptions<SilverlightDbContext> options) : base(options)
        {

        }

        // add entity here

        public DbSet<Category> Categories { get; set; }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Blog_Category> Blogs_Categories { get; set; }
        public DbSet<Blog_Tag> Blogs_Tags { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
