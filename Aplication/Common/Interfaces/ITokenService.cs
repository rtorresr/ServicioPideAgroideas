using Application.Common.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface ITokenService
    {
        public string GenerarMainToken(IDictionary<string, string> datos);
        public IDictionary<string, string> ObtenerParametrosMainToken(IList<string> parametros, string token = null);
        public string ObtenerParametrosMainToken(string parametro, string token = null);
        public string ObtenerMainToken();
    }
}
