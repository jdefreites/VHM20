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
    internal class ClienteConfigurationMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");
            builder.HasKey(x => x.Id);
            builder.Property(p=>p.Id).ValueGeneratedOnAdd();


            builder.Property(p=>p.Nombre).HasMaxLength(25).IsRequired();
            builder.Property(p=>p.Apellido).HasMaxLength(25).IsRequired();
            builder.Property(p=>p.DocumentoIdentidad).HasMaxLength(15).IsRequired();
            builder.Property(p=>p.FechaNacimiento).IsRequired();

            builder.HasData(InitDbData.ClientesData);

        }
    }
}
