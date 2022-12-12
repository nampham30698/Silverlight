using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Silverlight.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silverlight.Infrastructure.Data.Config
{
    public class Blog_CategoryConfig : IEntityTypeConfiguration<Blog_Category>
    {
        public void Configure(EntityTypeBuilder<Blog_Category> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(ci => ci.Id)
           .UseHiLo("Blog_Category_hilo")
           .IsRequired();
        }
    }
}
