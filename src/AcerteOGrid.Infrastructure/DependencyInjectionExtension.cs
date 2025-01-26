using AcerteOGrid.Domain.Repositories;
using AcerteOGrid.Domain.Repositories.Pilot;
using AcerteOGrid.Infrastructure.DataAccess;
using AcerteOGrid.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AcerteOGrid.Infrastructure
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            AddDbContext(services, configuration);
            AddRepositories(services);
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPilotReadOnlyRespository, PilotRepository>();
            services.AddScoped<IPilotWriteOnlyRespository, PilotRepository>();
            services.AddScoped<IPilotUpdateOnlyRespository, PilotRepository>();
        }

        private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("SqlConnection");

            services.AddDbContext<AcerteOGridDbContex>(config => config.UseSqlServer(connectionString));
        }
    }
}
