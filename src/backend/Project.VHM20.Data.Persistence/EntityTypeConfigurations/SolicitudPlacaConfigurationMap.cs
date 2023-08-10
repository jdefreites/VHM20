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
    internal class SolicitudPlacaConfigurationMap : IEntityTypeConfiguration<SolicitudPlaca>
    {
        public void Configure(EntityTypeBuilder<SolicitudPlaca> builder)
        {
            builder.ToTable("SolicitudesPlacas");
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.ClienteId).IsRequired();
            builder.Property(p => p.Fecha).HasDefaultValueSql("GETDATE()").IsRequired();
            builder.Property(p => p.TipoPersonaId).IsRequired();
            builder.Property(p => p.VehiculoId).IsRequired();
            builder.Property(p => p.TipoVehiculoId).IsRequired();
            builder.Property(p => p.Valor).HasPrecision(18, 2).HasColumnType("decimal(18,2)")
            .IsRequired();

            builder.HasOne(r => r.TipoPersona).WithMany(r => r.Solicitudes).HasForeignKey(p => p.TipoPersonaId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(r => r.TipoVehiculo).WithMany(r => r.Solicitudes).HasForeignKey(k => k.TipoVehiculoId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(r => r.Cliente).WithMany(r => r.Solicitudes).HasForeignKey(k => k.ClienteId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(r => r.Vehiculo).WithMany(r => r.Solicitudes).HasForeignKey(k => k.VehiculoId)
                .OnDelete(DeleteBehavior.NoAction);
            

        }
    }
}
