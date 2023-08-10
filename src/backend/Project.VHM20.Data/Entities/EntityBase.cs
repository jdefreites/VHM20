using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.VHM20.Data.Entities
{
    public class EntityBase
    {
        public int Id { get; set; }
    }

    public class EntityBase<TKey>
    {
        public TKey Id { get; set; }
    }
}
