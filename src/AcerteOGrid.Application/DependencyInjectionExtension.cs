using AcerteOGrid.Application.AutoMapper;
using AcerteOGrid.Application.Services.Pilot;
using Microsoft.Extensions.DependencyInjection;

namespace AcerteOGrid.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            AddServices(services);
            AddAutoMpper(services);
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IPilotGetAllService, PilotGetAllService>();
            services.AddScoped<IPilotGetByIdService, PilotGetByIdService>();
            services.AddScoped<IPilotInsertService, PilotInsertService>();
            services.AddScoped<IPilotUpdateService, PilotUpdateService>();
            services.AddScoped<IPilotDeleteService, PilotDeleteService>();
        }

        private static void AddAutoMpper(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapping));
        }
    }
}
