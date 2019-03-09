using Microsoft.Extensions.DependencyInjection;
using Store.Services.Framework;

namespace Store.Services.Extensions
{
    /// <summary>Extensions to the <see cref="IServiceCollection" /> class.</summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>Adds the mappers to the ServiceCollection.</summary>
        /// <param name="services">The <see cref="IServiceCollection" /> to register components with.</param>
        public static void AddMappers(this IServiceCollection services)
        {
            AutoMapper.Mapper.Initialize(cfg => cfg.AddProfiles(typeof(Startup).Assembly));
        }

        /// <summary>Adds the services to the ServiceCollection.</summary>
        /// <param name="services">The <see cref="IServiceCollection" /> to register components with.</param>
        public static void AddServices(this IServiceCollection services)
        {
            // Convention-based assembly scanning should find all repositories, as long as they follow the naming convention, and implement IRepository<T>
            services.Scan(scan => scan.FromAssemblyOf<Service>()
                .AddClasses(classes => classes.AssignableTo<IService>())
                .AsMatchingInterface()
                .WithTransientLifetime()
            );
        }
    }
}
