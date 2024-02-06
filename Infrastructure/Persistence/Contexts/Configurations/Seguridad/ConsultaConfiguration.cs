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
    public class ConsultaConfiguration : IEntityTypeConfiguration<ConsultaEntity>
    {
        public void Configure(EntityTypeBuilder<ConsultaEntity> builder)
        {
            builder.ToTable("CONSULTA", EnumEsquema.Seguridad);
            builder.HasKey(i => i.IdConsulta);

            //ForeignKeys
            builder.HasOne(s => s.Aplicacion)
                .WithMany(x => x.Consultas)
                .HasForeignKey(y => y.IdAplicacion);

        }
    }
}
