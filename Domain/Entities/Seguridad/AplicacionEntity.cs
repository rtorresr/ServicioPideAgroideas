using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Seguridad
{
    public class AplicacionEntity : AuditableEntity
    {
        public int IdAplicacion { get; set; }
        public string Nombre { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }

        #region Foreign keys
        
        public IEnumerable<ConsultaEntity> Consultas { get; set; }

        #endregion
    }
}
