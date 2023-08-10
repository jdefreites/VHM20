using Microsoft.EntityFrameworkCore;
using Project.VHM20.Data.Entities;
using Project.VHM20.Data.Persistence.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.VHM20.Data.Persistence.Repository.Impl
{
    internal class TipoPlacaRepository : BaseRepository<TipoPlaca>, ITipoPlacaRepository
    {
        private readonly VhmDbContext _context;

        public TipoPlacaRepository(VhmDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
