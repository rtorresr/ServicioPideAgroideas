using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Common.Models
{ 
    public class DatosReniec
    {
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nombres { get; set; }
        public string EstadoCivil { get; set; }
        public string Foto { get; set; }
        public string Ubigeo { get; set; }
        public string Direccion { get; set; }
        public string Restriccion { get; set; }
        public string CoResultado { get; set; }
        public string DeResultado { get; set; }
    }
}