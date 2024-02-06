using Aplication.Common.Interfaces;
using Aplication.Common.Repositories;
using Application.Common.Interfaces;
using Application.Common.Repositories.Seguridad;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Seguridad;
using Infrastructure.Repositories.Servicios;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Connections;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                .EnableSensitiveDataLogging(true)
                );

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
            services.AddScoped<IApplicationWriteDbConnection, ApplicationWriteDbConnection>();
            services.AddScoped<IApplicationReadDbConnection, ApplicationReadDbConnection>();
            
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IDateTime, DateTimeService>();
            services.AddTransient<IFileService, FileService>();
            services.AddTransient<ITokenService, TokenService>();

            #region Repositories

            #region Seguridad

            services.AddTransient<IConsultaRepository, ConsultaRepository>();
            services.AddTransient<IAplicacionRepository, AplicacionRepository>();

            services.AddTransient<IReniecRepository, ReniecRepository>();
            services.AddTransient<ISunatRepository, SunatRepository>();
            services.AddTransient<ISisgedRepository, SisgedRepository>();

            #endregion

            #endregion

            return services;
        }
    }
}
