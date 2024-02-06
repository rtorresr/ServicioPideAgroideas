using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public abstract class AuditableEntity
    {
        public DateTime FecRegistro { get; set; }
        public DateTime? FecModifica { get; set; }
        public bool Eliminado { get; set; }
    }
}
