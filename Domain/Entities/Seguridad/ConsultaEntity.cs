using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Seguridad
{
    public class ConsultaEntity : AuditableEntity
    {
        public int IdConsulta { get; set; }
        public int IdAplicacion { get; set; }
        public AplicacionEntity Aplicacion { get; set; }
        public string Token { get; set; }
        public string Consulta { get; set; }
        public string Respuesta { get; set; }
    }
}
