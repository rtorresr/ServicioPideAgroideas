using Application.Servicios.Reniec.Queries.GetDni;
using Application.Servicios.Sunat.Queries.GetDatosPrincipales;
using Application.Servicios.Sunat.Queries.GetDatosSecundarios;
using Application.Servicios.Sunat.Queries.GetDomicilioLegal;
using Application.Servicios.Sunat.Queries.GetRepLegales;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Authorize]
    //[EnableCors("PublicApi")]
    public class SunatController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetDatosBasicos(string nroRuc)
        {
            var query = new GetDatosPrincipalesQuery() { nroRuc = nroRuc, conAutorizacion = true };
            var data = await Mediator.Send(query);

            return Ok(new { Code = 200, Message = "Ok", Data = data.Data });
        }

        [HttpGet]
        public async Task<IActionResult> GetDatosPrincipales(string nroRuc)
        {
            var query = new GetDatosPrincipalesQuery() { nroRuc = nroRuc, conAutorizacion = true };
            var data = await Mediator.Send(query);

            return Ok(new { Code = 200, Message = "Ok", Data = data.Data });
        }

        [HttpGet]
        public async Task<IActionResult> GetDatosSecundarios(string nroRuc)
        {
            var query = new GetDatosSecundariosQuery() { nroRuc = nroRuc, conAutorizacion = true };
            var data = await Mediator.Send(query);

            return Ok(new { Code = 200, Message = "Ok", Data = data.Data });
        }

        [HttpGet]
        public async Task<IActionResult> GetDomicilioLegal(string nroRuc)
        {
            var query = new GetDomicilioLegalQuery() { nroRuc = nroRuc, conAutorizacion = true };
            var data = await Mediator.Send(query);

            return Ok(new { Code = 200, Message = "Ok", Data = data.Data });
        }

        [HttpGet]
        public async Task<IActionResult> GetRepLegales(string nroRuc)
        {
            var query = new GetRepLegalesQuery() { nroRuc = nroRuc, conAutorizacion = true };
            var data = await Mediator.Send(query);

            return Ok(new { Code = 200, Message = "Ok", Data = data.Data });
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ObtenerDatosBasicos(string nroRuc)
        {
            var query = new GetDatosPrincipalesQuery() { nroRuc = nroRuc, conAutorizacion = false };
            var data = await Mediator.Send(query);

            return Ok(new { Code = 200, Message = "Ok", Data = data.Data });
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ObtenerDatosPrincipales(string nroRuc)
        {
            var query = new GetDatosPrincipalesQuery() { nroRuc = nroRuc, conAutorizacion = false };
            var data = await Mediator.Send(query);

            return Ok(new { Code = 200, Message = "Ok", Data = data.Data });
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ObtenerDatosSecundarios(string nroRuc)
        {
            var query = new GetDatosSecundariosQuery() { nroRuc = nroRuc, conAutorizacion = false };
            var data = await Mediator.Send(query);

            return Ok(new { Code = 200, Message = "Ok", Data = data.Data });
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ObtenerDomicilioLegal(string nroRuc)
        {
            var query = new GetDomicilioLegalQuery() { nroRuc = nroRuc, conAutorizacion = false };
            var data = await Mediator.Send(query);

            return Ok(new { Code = 200, Message = "Ok", Data = data.Data });
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ObtenerRepLegales(string nroRuc)
        {
            var query = new GetRepLegalesQuery() { nroRuc = nroRuc, conAutorizacion = false };
            var data = await Mediator.Send(query);

            return Ok(new { Code = 200, Message = "Ok", Data = data.Data });
        }
    }
}
