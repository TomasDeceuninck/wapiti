using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Wapiti.Application.Common.Interfaces;

namespace Wapiti.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddDbContext<WapitiDbContext>();
            // services.AddTransient<IWapitiDbContext, WapitiDbContext>();
            services.AddScoped<IWapitiDbContext>(provider => provider.GetService<WapitiDbContext>());

            return services;
        }

    }
}
