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
    public class PlacaConfigurationMap : IEntityTypeConfiguration<Placa>
    {
        public void Configure(EntityTypeBuilder<Placa> builder)
        {
            builder.ToTable("Placas");
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p=>p.Numero).HasMaxLength(10).IsRequired();
            builder.Property(p => p.ClienteId).IsRequired();
            builder.Property(p => p.FechaVenta).IsRequired();
            builder.Property(p => p.TipoVehiculoId).IsRequired();
            builder.Property(p => p.VehiculoId).IsRequired();

            builder.HasOne(r=>r.Cliente).WithMany(r=>r.Placas).HasForeignKey(p => p.ClienteId);
            builder.HasOne(r=>r.TipoVehiculo).WithMany(r=>r.Placas).HasForeignKey(k=>k.TipoVehiculoId);
            builder.HasOne(r => r.Vehiculo).WithOne(r => r.Placa).HasForeignKey<Vehiculo>(r => r.PlacaId);
        }  
    }
}
