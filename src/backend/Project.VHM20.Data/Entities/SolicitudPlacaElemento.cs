using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.VHM20.Data.Entities
{
    public sealed class SolicitudPlacaElemento : EntityBase
    {
        public int VehiculoId { get; set; }
        public int TipoVehiculoId { get; set; }
        public decimal Valor { get; set; }
    }
}
