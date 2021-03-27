using DynamicProtfolioPrj.Services.IServices;
using DynamicProtfolioPrj.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DynamicProtfolioPrj 
{
    public static class DependencyResolver
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {

            services.AddScoped<ISectionService, SectionService>();
            services.AddScoped<IPageService, PageService>();

            return services;
        }
    }
}
