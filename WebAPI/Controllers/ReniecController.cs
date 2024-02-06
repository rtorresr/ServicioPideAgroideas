using Application.Servicios.Reniec.Queries.GetDni;
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
    public class ReniecController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetDni(string documento)
        {
            var query = new GetDniQuery() { documento = documento, conAutorizacion = true };
            var data = await Mediator.Send(query);

            return Ok(new { Code = 200, Message = "Ok", Data = data.Data });
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ObtenerDatosDniReniec(string documento)
        {
            var query = new GetDniQuery() { documento = documento, conAutorizacion = false };
            var data = await Mediator.Send(query);

            return Ok(new { Code = 200, Message = "Ok", Data = data.Data });
        }
    }
}
