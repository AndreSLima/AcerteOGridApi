using AcerteOGrid.Domain.Repositories;
using AcerteOGrid.Domain.Repositories.Pilot;
using AcerteOGrid.Domain.Repositories.User;
using AcerteOGrid.Domain.Security.Cryptography;
using AcerteOGrid.Domain.Security.Token;
using AcerteOGrid.Domain.Services.LoggedUser;
using AcerteOGrid.Infrastructure.DataAccess;
using AcerteOGrid.Infrastructure.DataAccess.Repositories;
using AcerteOGrid.Infrastructure.Security;
using AcerteOGrid.Infrastructure.Services.LoggedUser;
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
            AddToken(services, configuration);
            AddRepositories(services);

            services.AddScoped<IPasswordEncripter, Cryptography>();
            services.AddScoped<ILoggedUser, LoggedUser>();
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IPilotReadOnlyRespository, PilotRepository>();
            services.AddScoped<IPilotWriteOnlyRespository, PilotRepository>();
            services.AddScoped<IPilotUpdateOnlyRespository, PilotRepository>();

            services.AddScoped<IUserReadOnlyRepository, UserRepository>();
            services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
        }

        private static void AddToken(IServiceCollection services, IConfiguration configuration)
        {
            var expirationTimeMinutes = configuration.GetValue<uint>("AppSettings:Jwt:ExpiresMinutes");
            var signinKey = configuration.GetValue<string>("AppSettings:Jwt:SigninKey");

            services.AddScoped<IAccessTokenGenerator>(config => new JwtTokenGenerator(expirationTimeMinutes, signinKey!));
        }

        private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("SqlConnection");

            services.AddDbContext<AcerteOGridDbContex>(config => config.UseSqlServer(connectionString));
        }
    }
}
