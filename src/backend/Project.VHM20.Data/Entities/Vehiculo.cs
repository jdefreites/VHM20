using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.VHM20.Data.Entities
{
    public class Vehiculo : EntityBase
    {
        public string NumeroChasis { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Color { get; set; }
        public short Ano { get; set; }

        public int PlacaId { get; set; }
        public virtual Placa Placa { get; set; }
        public ICollection<SolicitudPlaca> Solicitudes { get; set; }
        // public string NumeroPlaca { get; set; }
        // public DateTime? FechaVenta { get; set; }
    }
}
