using Application.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Servicios.Sisged.Commands.GuardarArchivo
{
    public class GuardarArchivoCommand : IRequest<Result>
    {
        public IFormFile archivo { get; set; }
        public string ruta { get; set; }
    }
}
