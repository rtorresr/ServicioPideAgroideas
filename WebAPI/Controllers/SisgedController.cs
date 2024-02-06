using Application.Servicios.Sisged.Commands.GuardarArchivo;
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
    [AllowAnonymous]
    public class SisgedController : ApiControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> GuardarArchivo([FromForm] GuardarArchivoCommand command)
        { 
            var data = await Mediator.Send(command);

            if (!data.Success)
            {
                return Ok(new { success = false, text = data.Message, type = "warning" });                
            }

            return Ok(new { success = true, text = data.Message, type = "success" });
        }
    }
}
