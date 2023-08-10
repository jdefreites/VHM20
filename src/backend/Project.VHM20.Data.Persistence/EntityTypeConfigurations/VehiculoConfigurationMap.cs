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
    internal class VehiculoConfigurationMap : IEntityTypeConfiguration<Vehiculo>
    {
        public void Configure(EntityTypeBuilder<Vehiculo> builder)
        {
            builder.ToTable("Vehiculos");
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.NumeroChasis).HasMaxLength(25).IsRequired();
            builder.HasIndex(x => x.NumeroChasis).IsUnique();

            builder.Property(p => p.Modelo).HasMaxLength(25).IsRequired();
            builder.Property(p => p.Ano).IsRequired();
            builder.Property(p => p.Color).HasMaxLength(25).IsRequired();
            builder.Property(p => p.Marca).HasMaxLength(25).IsRequired();
        }
    }
}
