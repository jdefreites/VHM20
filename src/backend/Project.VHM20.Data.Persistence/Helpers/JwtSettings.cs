using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.VHM20.Data.Persistence.Helpers
{
    public class JwtSettings
    {
        public string Secret { get; set; }
        public double DurationInMinutes { get; set; }
    }
}
