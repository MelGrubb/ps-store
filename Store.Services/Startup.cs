using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.Services.Extensions;

namespace Store.Services
{
    /// <summary>Performs self-configuration for the Store.Services project.</summary>
    public class Startup
    {
        /// <summary>Called by the Web project on startup.</summary>
        /// <param name="serviceProvider">The service provider.</param>
        public static void Configure(IServiceProvider serviceProvider)
        {
            Domain.Startup.Configure(serviceProvider);
        }

        /// <summary>Configures the services with the IoC container.</summary>
        /// <param name="services">The IoC container in the form of an IServiceCollection.</param>
        /// <param name="configuration">The application's configuration.</param>
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            // Pass parameters down to the Domain layer to self-configure
            Domain.Startup.ConfigureServices(services, configuration);

            // Object-to-Object Mapping
            services.AddMappers();
            services.AddServices();
        }
    }
}
