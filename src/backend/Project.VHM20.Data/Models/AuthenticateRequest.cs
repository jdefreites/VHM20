using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.VHM20.Data.Models
{
    public class AuthenticateRequest
    {
        [Required]
        public string NombreUsuario { get; set; }

        [Required]
        public string Contrasena { get; set; }
    }
}
