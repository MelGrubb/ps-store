using System.Linq;
using NUnit.Framework;
using Should;
using Store.Domain.Models;

namespace Store.Tests.Unit.DomainTests.RepositoryTests.CountryRepositoryTests
{
    [TestFixture]
    public class When_adding_a_Country : Given_a_CountryRepository
    {
        private Country _model;
        private Country _result;

        protected override void Given()
        {
            base.Given();

            _model = new Country
            {
                Abbreviation = "YY",
                Name = "New Country",
                Description = "Unexpected, but welcome"
            };
        }

        protected override void When()
        {
            base.When();

            _result = SUT.AddAsync(AdminUserId, _model).Result;
        }

        [Test]
        public void Then_the_new_Country_should_have_an_Id()
        {
            _result.Id.ShouldEqual(SUT.StoreContext.Countries.OrderByDescending(x => x.Id).First().Id);
        }
    }
}
