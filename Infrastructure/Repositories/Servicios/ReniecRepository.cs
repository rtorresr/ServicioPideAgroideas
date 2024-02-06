using Application.Common.Models;
using Application.Common.Repositories.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Infrastructure.Repositories.Servicios
{
    public class ReniecRepository : IReniecRepository
    {
        public DatosReniec GetDni(string ruta, string nroDniUsua, string nroRucEnt, string pwdUsua, string documento)
        {
            try
            {
                XDocument xdoc = XDocument.Load(ruta + "?nuDniConsulta=" + documento + "&nuDniUsuario=" + nroDniUsua + "&nuRucUsuario=" + nroRucEnt + "&password=" + pwdUsua);
                                

                var result

                var personas = from per in xdoc.Descendants("datosPersona") select per;

                DatosReniec datoreniec_E = new DatosReniec();
                foreach (XElement elem in personas)
                {
                    datoreniec_E.ApellidoPaterno = elem.Element("apPrimer")?.Value == null ? string.Empty : Convert.ToString(elem.Element("apPrimer").Value);
                    datoreniec_E.ApellidoMaterno = elem.Element("apSegundo")?.Value == null ? string.Empty : Convert.ToString(elem.Element("apSegundo").Value);
                    datoreniec_E.Nombres = elem.Element("prenombres")?.Value == null ? string.Empty : Convert.ToString(elem.Element("prenombres").Value);
                    datoreniec_E.EstadoCivil = elem.Element("estadoCivil")?.Value == null ? string.Empty : Convert.ToString(elem.Element("estadoCivil").Value);
                    datoreniec_E.Foto = elem.Element("foto")?.Value == null ? string.Empty : Convert.ToString(elem.Element("foto").Value);
                    datoreniec_E.Ubigeo = elem.Element("ubigeo")?.Value == null ? string.Empty : Convert.ToString(elem.Element("ubigeo").Value);
                    datoreniec_E.Direccion = elem.Element("direccion")?.Value == null ? string.Empty : Convert.ToString(elem.Element("direccion").Value);
                    datoreniec_E.Restriccion = elem.Element("restriccion")?.Value == null ? string.Empty : Convert.ToString(elem.Element("restriccion").Value);
                }

                return datoreniec_E;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
