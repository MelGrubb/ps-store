using NUnit.Framework;
using Store.Domain.Models;

namespace Store.Tests.Unit.DomainTests.RepositoryTests.CountryRepositoryTests
{
    [TestFixture]
    public class When_deleting_a_Country : Given_a_CountryRepository
    {
        private Country _model;

        protected override void Given()
        {
            base.Given();

            var model = new Country
            {
                Name = "New Country",
                Description = "New Country"
            };

            _model = SUT.AddAsync(AdminUserId, model).Result;
            Assert.IsNotNull(SUT.GetAsync(AdminUserId, _model.Id).Result);
        }

        protected override void When()
        {
            base.When();

            SUT.DeleteAsync(AdminUserId, _model.Id).Wait();
        }

        [Test]
        public void Then_the_address_should_no_longer_exist()
        {
            var newCopy = SUT.GetAsync(AdminUserId, _model.Id).Result;

            Assert.IsNull(newCopy);
        }
    }
}
