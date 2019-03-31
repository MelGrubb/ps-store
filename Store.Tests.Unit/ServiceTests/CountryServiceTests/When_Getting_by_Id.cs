using System.Linq;
using NUnit.Framework;
using SpecsFor.Core.ShouldExtensions;
using Store.Domain.Models;
using Store.Services.Contracts.Country;

namespace Store.Tests.Unit.ServiceTests.CountryServiceTests
{
    [TestFixture]
    public class When_Getting_by_Id : SpecsForCountryService
    {
        private CountryDto _result;
        private Country _expected;

        protected override void Given()
        {
            base.Given();
            _expected = Countries.First();
        }

        protected override async void When()
        {
            base.When();
            _result = await SUT.GetAsync(AdminUserId, _expected.Id);
        }

        [Test]
        public void Then_only_the_matching_model_was_returned()
        {
            _result.ShouldLookLikePartial(new
            {
                _expected.Id,
                _expected.Abbreviation,
                _expected.Description,
                _expected.Name,
            });
        }
    }
}
