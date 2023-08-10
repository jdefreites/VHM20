using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.VHM20.Data.Entities
{
    public class Cliente : EntityBase
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DocumentoIdentidad { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public ICollection<SolicitudPlaca> Solicitudes { get; set; }
        public virtual ICollection<Placa> Placas { get; set; }
    }
}
