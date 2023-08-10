using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.VHM20.Data.Models
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Token { get; set; }
    }
}
