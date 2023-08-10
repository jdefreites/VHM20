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
    internal class SolicitudPlacaElementoConfigurationMap : IEntityTypeConfiguration<SolicitudPlacaElemento>
    {
        public void Configure(EntityTypeBuilder<SolicitudPlacaElemento> builder)
        {
            builder.ToTable("SolicitudesPlacasElementos");
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
        }
    }
}
