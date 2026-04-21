using Microsoft.EntityFrameworkCore;
using SmartAppointments.Application.Interfaces.Repositories;
using SmartAppointments.Application.Interfaces.Services;
using SmartAppointments.Application.Services;
using SmartAppointments.Infrastructure.Data;
using SmartAppointments.Infrastructure.Repositories;

namespace SmartAppointments.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddProjectServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Sql")));

            services.AddDbContext<AppDbContextPro>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Sqlpro")));

            services.AddApplication();
            services.AddInfrastructure();
            services.AddControllers();
            services.AddOpenApi();

            return services;
        }

        private static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IArchivoService, ArchivoService>();

            return services;
        }

        private static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IArchivoRepository, ArchivoRepository>();

            return services;
        }
    }
}