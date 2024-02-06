using Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Seguridad.Sesion.Commands.Autenticar
{
    public class AutenticarCommand : IRequest<Result<AutenticarResult>>
    {
        public string Usuario { get; set; }
        public string Clave { get; set; }
    }
}
