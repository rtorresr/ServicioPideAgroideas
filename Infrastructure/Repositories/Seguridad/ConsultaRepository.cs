using Application.Common.Interfaces;
using Application.Common.Repositories.Seguridad;
using Domain.Entities.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Seguridad
{
    public class ConsultaRepository : GenericRepository<ConsultaEntity>, IConsultaRepository
    {
        public ConsultaRepository(
            IApplicationDbContext context
            ) : base(context)
        {
        }
    }
}
