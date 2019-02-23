using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.Domain.Extensions;
using Store.Domain.Models;

namespace Store.Domain
{
    /// <summary>Performs self-configuration for the Store.Domain project.</summary>
    public static class Startup
    {
        /// <summary>Called by the Web project on startup.</summary>
        /// <param name="serviceProvider">The service provider.</param>
        public static void Configure(IServiceProvider serviceProvider)
        {
            // Apply database migrations
            serviceProvider.GetService<StoreContext>().Database.Migrate();
        }

        /// <summary>Configures the services with the IoC container.</summary>
        /// <param name="services">The IoC container in the form of an IServiceCollection.</param>
        /// <param name="configuration">The application's configuration.</param>
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            // Retrieve the connection string first so that the retrieval from configuration doesn't become part of the lambda
            var sqlConnectionString = configuration.GetConnectionString("Store");
            services.AddDbContext<StoreContext>(o => o.UseSqlServer(sqlConnectionString));
            services.AddRepositories();
        }
    }
}
