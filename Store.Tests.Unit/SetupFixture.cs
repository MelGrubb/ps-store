using AutoMapper;
using NUnit.Framework;
using Store.Services;

namespace Store.Tests.Unit
{
    [SetUpFixture]
    public class SetUpFixture
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            UseRealMappers();
        }

        private void UseRealMappers()
        {
            Mapper.Initialize(cfg => cfg.AddProfiles(typeof(Startup).Assembly));
        }
    }
}
