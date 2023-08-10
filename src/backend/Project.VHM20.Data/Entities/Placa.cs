using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.VHM20.Data.Entities
{
    public class Placa : EntityBase
    {
        // public int TipoPlacaId { get; set; }
        public int TipoVehiculoId { get; set; }
        public string Numero { get; set; }
        public DateTime FechaVenta { get; set; }
        public int ClienteId { get; set; }
        public int VehiculoId { get; set; }

        public virtual Vehiculo Vehiculo { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual TipoVehiculo TipoVehiculo { get; set; }
    }
}
