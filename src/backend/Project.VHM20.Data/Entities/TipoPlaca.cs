using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.VHM20.Data.Entities
{
    public sealed class TipoPlaca : EntityBase
    {
        public string Descripcion { get; set; }

        public ICollection<TipoVehiculo> TiposVehiculos { get; set; }
    }
}
