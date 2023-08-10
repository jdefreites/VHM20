using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.VHM20.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.VHM20.Data.Persistence.EntityTypeConfigurations
{
    internal class TipoPlacaConfigurationMap : IEntityTypeConfiguration<TipoPlaca>
    {
        public void Configure(EntityTypeBuilder<TipoPlaca> builder)
        {
            builder.ToTable("TiposPlacas");
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.Descripcion).HasMaxLength(50).IsRequired();

            builder.HasData(InitDbData.TipoPlacasData);
        }
    }
}
