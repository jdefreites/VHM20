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
    internal class UsuarioConfigurationMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p=>p.NombreUsuario).HasMaxLength(15).IsRequired();
            builder.HasIndex(i => i.NombreUsuario).IsUnique();
            builder.Property(p => p.Contrasena).IsRequired();
            builder.Property(p => p.Sello).IsRequired();

            builder.HasData(InitDbData.UsuariosData);
        }
    }
}
