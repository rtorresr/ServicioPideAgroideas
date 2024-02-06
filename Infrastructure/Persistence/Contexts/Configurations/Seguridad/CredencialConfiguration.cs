using Domain.Entities.Seguridad;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Contexts.Configurations.Seguridad
{
    public class CredencialConfiguration : IEntityTypeConfiguration<CredencialEntity>
    {
        public void Configure(EntityTypeBuilder<CredencialEntity> builder)
        {
            builder.ToTable("CREDENCIAL", EnumEsquema.Seguridad);
            builder.HasKey(i => i.IdCredencial);
        }
    }
}
