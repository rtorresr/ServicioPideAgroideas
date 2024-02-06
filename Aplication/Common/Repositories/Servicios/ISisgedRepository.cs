using Aplication.Common.Repositories;
using Application.Common.Models;
using Domain.Entities.Seguridad;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Application.Common.Repositories.Seguridad
{
    public interface ISisgedRepository
    {
        public Result GuardarArchivo(IFormFile archivo , string ruta);
    }
}
