using Microsoft.Extensions.DependencyInjection;

using Services.Interfaces;
using Services.Services;

namespace Services.Configuration
{
    public static class DependenciesConfiguration
    {
        public static IServiceCollection RegisterServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IIfcFileService, IfcFileService>();

            return serviceCollection;
        }
    }
}
