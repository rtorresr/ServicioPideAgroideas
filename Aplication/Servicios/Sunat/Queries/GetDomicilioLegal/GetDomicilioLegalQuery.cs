using Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Servicios.Sunat.Queries.GetDomicilioLegal
{
    public class GetDomicilioLegalQuery : IRequest<Result<DomicilioLegalSunat>>
    {
        public string nroRuc { get; set; }
        public bool conAutorizacion { get; set; }
    }
}
