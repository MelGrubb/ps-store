using System;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Store.Web.Extensions;

namespace Store.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        /// <summary>Called on application start-up.</summary>
        /// <param name="app">The <see cref="IApplicationBuilder" />.</param>
        /// <param name="serviceProvider">The <see cref="IServiceProvider" />.</param>
        /// <param name="env">The hosting environment.</param>
        /// <param name="apiVersionDescriptionProvider">The API version description provider.</param>
        public void Configure(IApplicationBuilder app, IServiceProvider serviceProvider, IHostingEnvironment env, IApiVersionDescriptionProvider apiVersionDescriptionProvider)
        {
            // Pass parameters down to the Service layer to self-configure
            Services.Startup.Configure(serviceProvider);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseSwagger(Configuration, apiVersionDescriptionProvider);
            app.UseMvc(routes => { routes.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}"); });
        }

        /// <summary>Configures the services with the IoC container.</summary>
        /// <param name="services">The IoC container in the form of an IServiceCollection.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            // Pass parameters down to the Service layer to self-configure
            Services.Startup.ConfigureServices(services, Configuration);

            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
            });
            services.AddAutoMapper();
            services.AddSwagger();
            services.AddMvc(options =>
                {
                    // Just in case someone wants XML instead of JSON
                    options.RespectBrowserAcceptHeader = true;
                    options.InputFormatters.Add(new XmlSerializerInputFormatter(options));
                    options.OutputFormatters.Add(new XmlSerializerOutputFormatter());

                    // Reject content-types other than those explicitly marked on an endpoint using a Provides attribute.
                    options.ReturnHttpNotAcceptable = true;
                })
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                    options.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
        }
    }
}
