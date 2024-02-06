﻿using Application.Common.Interfaces;
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

namespace Application.Servicios.Sunat.Queries.GetRepLegales
{
    public class GetRepLegalesHandler : IRequestHandler<GetRepLegalesQuery, Result<RepLegalesSunat>>
    {
        private readonly ISunatRepository _sunat;
        private readonly IConsultaRepository _consulta;
        private readonly IConfiguration _configuration;
        private readonly IDataProtector _protector;
        private readonly ITokenService _token;

        public GetRepLegalesHandler(
            ISunatRepository sunat,
            IConsultaRepository consulta,
            IConfiguration configuration,
            IDataProtectionProvider provider,
            ITokenService token
            )
        {
            _sunat = sunat;
            _consulta = consulta;
            _configuration = configuration;
            _protector = provider.CreateProtector(_configuration["Security:Encryption:Key"]);
            _token = token;
        }

        public async Task<Result<RepLegalesSunat>> Handle(GetRepLegalesQuery request, CancellationToken cancellationToken)
        {
            int idplicacion = 0;
            string token = string.Empty;

            if (request.conAutorizacion)
            {
                string codigoAplicacion = _token.ObtenerParametrosMainToken("Codigo");
                idplicacion = Convert.ToInt32(_protector.Unprotect(codigoAplicacion));

                token = _token.ObtenerMainToken();
            }
            var resultado = _sunat.GetRepLegales(_configuration["Servicios:Sunat:Ruta"].ToString(), request.nroRuc);

            var consulta = new ConsultaEntity();
            consulta.IdAplicacion = idplicacion;
            consulta.Token = token;
            consulta.Consulta = request.nroRuc;

            consulta.Respuesta = "Success";
            if (resultado == null)
            {
                consulta.Respuesta = "Error";
            }

            await _consulta.Add(consulta);

            return new Result<RepLegalesSunat>(true, resultado);
        }
    }
}
