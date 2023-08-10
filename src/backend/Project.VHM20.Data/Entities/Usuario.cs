using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Project.VHM20.Data.Entities
{
    public sealed class Usuario : EntityBase
    {
        public string NombreUsuario { get; set; }

        [JsonIgnore]
        public string Contrasena { get; set; }

        [JsonIgnore]
        public string Sello { get; set; }
    }
}
