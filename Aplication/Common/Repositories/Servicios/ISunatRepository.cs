using Aplication.Common.Repositories;
using Application.Common.Models;
using Domain.Entities.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Repositories.Seguridad
{
    public interface ISunatRepository
    {
        public DatosPrincipalesSunat GetDatosBasicos(string ruta, string nroRuc);

        public DatosPrincipalesSunat GetDatosPrincipales(string ruta, string nroRuc);

        public DatosSecundariosSunat GetDatosSecundarios(string ruta, string nroRuc);

        public DomicilioLegalSunat GetDomicilioLegal(string ruta, string nroRuc);

        public RepLegalesSunat GetRepLegales(string ruta, string nroRuc);
    }
}
