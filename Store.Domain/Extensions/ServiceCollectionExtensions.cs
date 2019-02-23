using Microsoft.Extensions.DependencyInjection;
using Store.Domain.Framework;

namespace Store.Domain.Extensions
{
    /// <summary>Extensions to the <see cref="IServiceCollection" /> class.</summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>Adds the repositories to the ServiceCollection.</summary>
        /// <param name="services">The <see cref="IServiceCollection" /> to register components with.</param>
        public static void AddRepositories(this IServiceCollection services)
        {
            // Convention-based assembly scanning should find all repositories, as long as they follow the naming convention, and implement IRepository<T>
            services.Scan(scan => scan.FromAssemblyOf<IRepository>()
                .AddClasses(classes => classes.AssignableTo<IRepository>())
                .AsMatchingInterface()
                .WithTransientLifetime()
            );
        }
    }
}
