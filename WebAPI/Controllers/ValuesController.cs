using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class ValuesController : ApiControllerBase
    {
        [HttpGet]
        public ActionResult Index()
        {
            return Ok(new { data = "publicado correctamente"});
        }

    }
}
