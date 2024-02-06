using Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Servicios.Sunat.Queries.GetRepLegales
{
    public class GetRepLegalesQuery : IRequest<Result<RepLegalesSunat>>
    {
        public string nroRuc { get; set; }
        public bool conAutorizacion { get; set; }
    }
}
