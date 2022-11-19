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
    public class CategoriesConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(ci => ci.Id)
           .UseHiLo("Categories_hilo")
           .IsRequired();

            builder.Property(cb => cb.Name)
           .HasMaxLength(255);

            builder.Property(cb => cb.Description)
            .HasMaxLength(500);
        }
    }
}
