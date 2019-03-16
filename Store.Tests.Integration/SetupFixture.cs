using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.PlatformAbstractions;
using NUnit.Framework;
using Store.Web;

namespace Store.Tests.Integration
{
    [SetUpFixture]
    public class SetupFixture
    {
        private const string baseUrl = "http://localhost:12345/api/v1/";

        private static readonly IConfiguration _configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false, true)
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development"}.json", true, true)
            .AddEnvironmentVariables()
            .Build();

        static SetupFixture()
        {
        }

        internal static HttpClient Client { get; private set; }
        internal static TestServer Server { get; private set; }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Debug.WriteLine("Beginning integration test run.");
            var integrationTestPath = PlatformServices.Default.Application.ApplicationBasePath;
            var apiPath = Path.GetFullPath(Path.Combine(integrationTestPath, "../../../../Store.Web"));
            var hostBuilder = new WebHostBuilder()
                .UseUrls(baseUrl)
                .UseContentRoot(apiPath)
                .UseConfiguration(_configuration)
                .UseStartup<Startup>();

            Server = new TestServer(hostBuilder);
            Client = Server.CreateClient();
            Client.BaseAddress = new Uri(baseUrl);
        }
    }
}
