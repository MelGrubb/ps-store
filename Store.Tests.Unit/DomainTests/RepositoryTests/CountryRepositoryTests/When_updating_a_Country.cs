using NUnit.Framework;
using Should;
using Store.Domain.Models;

namespace Store.Tests.Unit.DomainTests.RepositoryTests.CountryRepositoryTests
{
    [TestFixture]
    public class When_updating_a_Country : Given_a_CountryRepository
    {
        private Country _model;

        protected override void Given()
        {
            base.Given();

            _model = SUT.GetAsync(AdminUserId, 1).Result;
        }

        protected override void When()
        {
            base.When();

            _model.Description = "New Description";
            _model.Name = "New Name";
            SUT.SaveChangesAsync(AdminUserId).Wait();
        }

        [Test]
        public void Then_the_address_properties_should_have_been_updated()
        {
            var newCopy = SUT.GetAsync(AdminUserId, 1).Result;
            newCopy.Id.ShouldEqual(1);
            newCopy.Description.ShouldEqual("New Description");
            newCopy.Name.ShouldEqual("New Name");
        }
    }
}
