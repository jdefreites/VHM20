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
    internal class TipoVehiculoConfigurationMap : IEntityTypeConfiguration<TipoVehiculo>
    {
        public void Configure(EntityTypeBuilder<TipoVehiculo> builder)
        {
            builder.ToTable("TiposVehiculos");
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p=>p.Descripcion).HasMaxLength(50).IsRequired();
            builder.Property(p=>p.Letra).HasMaxLength(3).IsRequired();
            builder.Property(p=>p.TipoPlacaId).IsRequired();
            builder.Property(p => p.Valor).HasPrecision(18, 2).HasColumnType("decimal(18,2)")
            .IsRequired();

            builder.HasOne(r => r.TipoPlaca).WithMany(r => r.TiposVehiculos).HasForeignKey(k => k.TipoPlacaId);

            builder.HasData(InitDbData.TipoVehiculosData);
        }
    }
}
