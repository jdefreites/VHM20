using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.VHM20.Data.Entities
{
    public class TipoVehiculo : EntityBase
    {
        public string Descripcion { get; set; }
        public string Letra { get; set; }
        public int TipoPlacaId { get; set; }
        public decimal Valor { get; set; }

        public virtual TipoPlaca TipoPlaca { get; set; }
        public virtual ICollection<Placa> Placas { get; set; }
        public ICollection<SolicitudPlaca> Solicitudes { get; set; }
    }
}
