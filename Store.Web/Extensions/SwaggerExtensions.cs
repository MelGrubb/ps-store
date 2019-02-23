using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Store.Web.Extensions
{
    /// <summary>Configuration extensions supporting Swagger integration.</summary>
    public static class SwaggerExtensions
    {
        private static string XmlCommentsFilePath
        {
            get
            {
                var fileName = typeof(Startup).GetTypeInfo().Assembly.GetName().Name + ".xml";
                var result = Path.Combine(AppContext.BaseDirectory, fileName);

                return result;
            }
        }

        /// <summary>Registers Swagger components with the IoC.</summary>
        /// <param name="services">The <see cref="IServiceCollection" /> to register components with.</param>
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(
                options =>
                {
                    // Add a swagger document for each discovered API version
                    var provider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
                    }

                    // TODO: See if we can live without this now
                    // add a custom operation filter which sets default values
                    options.OperationFilter<SwaggerDefaultValues>();

                    // Integrate xml comments, as well as code annotations
                    options.IncludeXmlComments(XmlCommentsFilePath);
                    options.EnableAnnotations();
                });
        }

        private static Info CreateInfoForApiVersion(ApiVersionDescription description)
        {
            var info = new Info
            {
                Title = $"Store API v{description.ApiVersion}",
                Version = description.ApiVersion.ToString(),
                Description = "This is a sample Store API",
                Contact = new Contact
                    { Name = "Support", Email = "support@store.com", Url = "http://support.store.com" }
            };

            return info;
        }

        /// <summary>Adds Swagger Middleware to the ASP.Net pipeline</summary>
        /// <param name="builder">The <see cref="IApplicationBuilder" /> being used to construct the pipeline.</param>
        /// <param name="configuration">The <see cref="IConfiguration" /> used to retrieve application configuration parameters.</param>
        /// <param name="apiVersionDescriptionProvider">The id of the apiVersionDescriptionProvider.</param>
        /// <returns>A reference to the original <see cref="IApplicationBuilder" /> that was passed in.</returns>
        public static IApplicationBuilder UseSwagger(this IApplicationBuilder builder, IConfiguration configuration, IApiVersionDescriptionProvider apiVersionDescriptionProvider)
        {
            builder.UseSwagger();
            builder.UseSwaggerUI(options =>
            {
                options.DocExpansion(DocExpansion.None);

                // Build separate swagger endpoints for each API version
                foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                }
            });

            return builder;
        }
    }
}
