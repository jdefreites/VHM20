using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.VHM20.Data.Entities
{
    public  class SolicitudPlaca : EntityBase
    {
        public int ClienteId { get; set; }
        public DateTime Fecha { get; set; }
        public int TipoPersonaId { get; set; }
        public int VehiculoId { get; set; }
        public int TipoVehiculoId { get; set; }
        public decimal Valor { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual TipoPersona TipoPersona { get; set; }
        public virtual Vehiculo Vehiculo { get; set; }
        public virtual TipoVehiculo TipoVehiculo { get; set; }

    }
}
