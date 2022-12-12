using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Silverlight.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silverlight.Infrastructure.Data.Config
{
    public class BlogConfig : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(ci => ci.Id)
           .UseHiLo("Blog_hilo")
           .IsRequired();

            builder.Property(cb => cb.Title)
           .HasMaxLength(255);

            builder.Property(cb => cb.TitleShort)
            .HasMaxLength(255);

            builder.Property(cb => cb.Description)
            .HasMaxLength(500);

            builder.Property(cb => cb.UrlImage)
           .HasMaxLength(500);
        }
    }
}
