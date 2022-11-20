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
    public class SettingsConfig : IEntityTypeConfiguration<Settings>
    {
        public void Configure(EntityTypeBuilder<Settings> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(ci => ci.Id)
           .UseHiLo("Settings_hilo")
           .IsRequired();

            builder.Property(cb => cb.Key)
           .HasMaxLength(255);

            builder.Property(cb => cb.Value)
            .HasMaxLength(500);
        }
    }
}
