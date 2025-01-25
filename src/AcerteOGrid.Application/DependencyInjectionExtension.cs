using AcerteOGrid.Application.Services.Pilot;
using Microsoft.Extensions.DependencyInjection;

namespace AcerteOGrid.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IPilotRegisterService, PilotRegisterService>();
        }
    }
}
