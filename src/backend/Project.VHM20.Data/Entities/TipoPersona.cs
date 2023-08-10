using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.VHM20.Data.Entities
{
    public sealed class TipoPersona : EntityBase
    {
        public string Descripcion { get; set; }

        public ICollection<SolicitudPlaca> Solicitudes { get; set; }
    }
}
