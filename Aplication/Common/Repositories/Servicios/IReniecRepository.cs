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
    public interface IReniecRepository
    {
        public DatosReniec GetDni(string ruta, string nroDniUsua, string nroRucEnt, string pwdUsua, string documento);
    }
}
