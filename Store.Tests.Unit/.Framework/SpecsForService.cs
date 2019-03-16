using SpecsFor.StructureMap;
using Store.Services.Framework;
using StructureMap;

namespace Store.Tests.Unit.Framework
{
    public abstract class SpecsForService<TService> : SpecsFor<TService> where TService : Service
    {
        protected readonly int AdminUserId = 1;

        public override void ConfigureContainer(Container container)
        {
            base.ConfigureContainer(container);

            // Fake configuration values
            var mockConfiguration = GetMockFor<Microsoft.Extensions.Configuration.IConfiguration>();
        }
    }
}
