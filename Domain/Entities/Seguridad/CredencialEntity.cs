using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Seguridad
{    
    public class CredencialEntity : AuditableEntity
    {
        public int IdCredencial { get; set; }
        public int IdApi { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public bool Activo { get; set; }
    }
}
