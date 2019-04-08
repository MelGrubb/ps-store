using NUnit.Framework;
using Shouldly;
using Store.Domain.Models;
using Store.Tests.Unit.Framework.Mothers;

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

            _model = CountryMother.Typical();
        }

        protected override void When()
        {
            base.When();

            _result = SUT.AddAsync(AdminUserId, _model).Result;
        }

        [Test]
        public void Then_the_new_Country_should_have_an_Id()
        {
            _result.Id.ShouldBeGreaterThan(0);
        }
    }
}
