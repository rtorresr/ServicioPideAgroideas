using Application.Common.Interfaces;
using Application.Common.Models;
using Application.Common.Repositories.Seguridad;
using Domain.Entities.Seguridad;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Seguridad.Sesion.Commands.Autenticar
{
    public class AutenticarHandler : IRequestHandler<AutenticarCommand, Result<AutenticarResult>>
    {
        private readonly IAplicacionRepository _aplicacion;
        private readonly IConfiguration _configuration;
        private readonly IDataProtector _protector;
        private readonly ITokenService _token;        

        public AutenticarHandler(
            IAplicacionRepository aplicacion,
            IConfiguration configuration,
            IDataProtectionProvider provider,
            ITokenService token
            )
        {
            _aplicacion = aplicacion;
            _configuration = configuration;
            _protector = provider.CreateProtector(_configuration["Security:Encryption:Key"]);
            _token = token;
        }

        public async Task<Result<AutenticarResult>> Handle(AutenticarCommand request, CancellationToken cancellationToken)
        {
            var busqueda = await _aplicacion.GetAll(filter: x => x.Usuario == request.Usuario && x.Clave == request.Clave);

            if (busqueda.Count() == 0)
                return new Result<AutenticarResult>(false, null, "Contraseña incorrecta");

            var aplicacion = busqueda.First();
            
            string codigoAplicacion = _protector.Protect(aplicacion.IdAplicacion.ToString());

            IDictionary<string, string> parametros = new Dictionary<string, string>();
            parametros.Add("Codigo", codigoAplicacion);

            string mainToken = _token.GenerarMainToken(parametros);

            AutenticarResult resultado = new AutenticarResult()
            {
                Token = mainToken,
            };

            return new Result<AutenticarResult>(true, resultado, "Autenticado correctamente");
        }
    }
}
