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

namespace Application.Servicios.Reniec.Queries.GetDni
{
    public class GetDniHandler : IRequestHandler<GetDniQuery, Result<DatosReniec>>
    {
        private readonly IReniecRepository _reniec;
        private readonly IConsultaRepository _consulta;
        private readonly IConfiguration _configuration;
        private readonly IDataProtector _protector;
        private readonly ITokenService _token;

        public GetDniHandler(
            IReniecRepository reniec,
            IConsultaRepository consulta,
            IConfiguration configuration,
            IDataProtectionProvider provider,
            ITokenService token
            )
        {
            _reniec = reniec;
            _consulta = consulta;
            _configuration = configuration;
            _protector = provider.CreateProtector(_configuration["Security:Encryption:Key"]);
            _token = token;
        }

        public async Task<Result<DatosReniec>> Handle(GetDniQuery request, CancellationToken cancellationToken)
        {
            int idplicacion = 0;
            string token = string.Empty;
            if (request.conAutorizacion)
            {
                string codigoAplicacion = _token.ObtenerParametrosMainToken("Codigo");
                idplicacion = Convert.ToInt32(_protector.Unprotect(codigoAplicacion));

                token = _token.ObtenerMainToken();
            }
            var resultado = _reniec.GetDni(_configuration["Servicios:Reniec:Ruta"].ToString(), _configuration["Servicios:Reniec:Usuario"].ToString(), _configuration["Servicios:Reniec:Ruc"].ToString(), _configuration["Servicios:Reniec:Clave"].ToString(), request.documento);

            var consulta = new ConsultaEntity();
            consulta.IdAplicacion = idplicacion;
            consulta.Token = token;
            consulta.Consulta = request.documento;

            consulta.Respuesta = "Success";
            if (resultado == null)
            {
                consulta.Respuesta = "Error";
            }

            await _consulta.Add(consulta);

            return new Result<DatosReniec>(true, resultado);
        }
    }
}
