using Application.Common.Models;
using Application.Common.Repositories.Seguridad;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Servicios.Sisged.Commands.GuardarArchivo
{
    public class GuardarArchivoHandler : IRequestHandler<GuardarArchivoCommand, Result>
    {
        private readonly ISisgedRepository _sisged;

        public GuardarArchivoHandler(
            ISisgedRepository sisged
            )
        {
            _sisged = sisged;
        }

        public async Task<Result> Handle(GuardarArchivoCommand request, CancellationToken cancellationToken)
        {
            var resultado = _sisged.GuardarArchivo(request.archivo, request.ruta);

            return new Result(resultado.Success, resultado.Message);
        }
    }
}
