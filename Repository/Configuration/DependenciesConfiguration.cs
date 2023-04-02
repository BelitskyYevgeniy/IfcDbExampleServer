using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using Repository.Interfaces;
using Repository.Repositories;

using IfcDb;
using IfcDb.Interfaces;
using IfcDb.Mappers;
using IfcDb.Parsers;
using IfcDb.Helpers;

namespace Repository.Configuration
{
    public static class DependenciesConfiguration
    {
        public static IServiceCollection AddRepository(this IServiceCollection services, string connectionString)
        {
            AddRepositoryContext(services, connectionString);
            services.AddScoped<IValueRepository, ValueRepository>();
            services.AddScoped<IFileRepository, FileRepository>();
            services.AddScoped<IObjRepository, ObjRepository>();
            services.AddScoped<IObjTypeRepository, ObjTypeRepository>();
            services.AddScoped<IObjDestinationRepository, ObjDestinationRepository>();
            services.AddScoped<IAttributeRepository, AttributeRepository>();
            services.AddScoped<IValueRepository, ValueRepository>();
            return services;
        }
        public static IServiceCollection AddRepositoryContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<IfcDbContext>(options => options.UseSqlServer(connectionString));
            return services;
        }

        public static IServiceCollection AddIfcMapper(this IServiceCollection services)
        {
            services.AddTransient<IIfcMapper, IfcMapper>();
            return services;
        }

        public static IServiceCollection AddIfcParser(this IServiceCollection services)
        {
            services.AddTransient<IIfcParser, IfcParser>();
            return services;
        }

        public static IServiceCollection AddDataHelpers(this IServiceCollection services)
        {
            services.AddScoped<IFileDataHelper, FileDataHelper>();
            return services;
        }
    }
}
