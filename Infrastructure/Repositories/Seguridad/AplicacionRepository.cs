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
    public class AplicacionRepository : GenericRepository<AplicacionEntity>, IAplicacionRepository
    {
        public AplicacionRepository(
            IApplicationDbContext context
            ) : base(context)
        {
        }
    }
}
