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
    public class Blog_TagConfig : IEntityTypeConfiguration<Blog_Tag>
    {
        public void Configure(EntityTypeBuilder<Blog_Tag> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(ci => ci.Id)
           .UseHiLo("Blog_hilo")
           .IsRequired();

            builder.Property(cb => cb.TagName)
           .HasMaxLength(255);

            builder.Property(cb => cb.TagNameShort)
            .HasMaxLength(255);
        }
    }
}
