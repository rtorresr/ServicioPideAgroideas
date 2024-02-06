using Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Servicios.Reniec.Queries.GetDni
{
    public class GetDniQuery : IRequest<Result<DatosReniec>>
    {
        public string documento { get; set; }
        public bool conAutorizacion { get; set; }
    }
}
