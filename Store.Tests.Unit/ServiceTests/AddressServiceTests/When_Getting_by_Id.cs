using System.Linq;
using NUnit.Framework;
using SpecsFor.Core.ShouldExtensions;
using Store.Domain.Models;
using Store.Services.Contracts.Address;

namespace Store.Tests.Unit.ServiceTests.AddressServiceTests
{
    [TestFixture]
    public class When_Getting_by_Id : SpecsForAddressService
    {
        private AddressDto _result;
        private Address _expected;

        protected override void Given()
        {
            base.Given();
            _expected = Addresses.First();
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
                _expected.Line1,
                _expected.Line2,
                _expected.City,
                _expected.StateId,
                ZipCode = _expected.ZipCode
            });
        }
    }
}
