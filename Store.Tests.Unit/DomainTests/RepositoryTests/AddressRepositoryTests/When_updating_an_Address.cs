using NUnit.Framework;
using Shouldly;
using Store.Domain.Models;
using Store.Tests.Unit.Framework;

namespace Store.Tests.Unit.DomainTests.RepositoryTests.AddressRepositoryTests
{
    [TestFixture]
    public class When_updating_an_Address : Given_an_AddressRepository
    {
        private Address _model;

        protected override void Given()
        {
            base.Given();

            _model = SUT.GetAsync(AdminUserId, 1).Result;
        }

        protected override void When()
        {
            base.When();

            _model.Line1 = GetRandom.String(1, 50);
            _model.Line2 = GetRandom.String(1, 50);
            _model.City = GetRandom.String(1, 50);
            _model.StateId = 2;
            _model.PostalCode = GetRandom.String(5, 5);
            SUT.SaveChangesAsync(AdminUserId).Wait();
        }

        [Test]
        public void Then_the_address_properties_should_have_been_updated()
        {
            var newCopy = SUT.GetAsync(AdminUserId, _model.Id).Result;
            newCopy.Id.ShouldBe(_model.Id);
            newCopy.Line1.ShouldBe(_model.Line1);
            newCopy.Line2.ShouldBe(_model.Line2);
            newCopy.City.ShouldBe(_model.City);
            newCopy.StateId.ShouldBe(_model.StateId);
            newCopy.PostalCode.ShouldBe(_model.PostalCode);
        }
    }
}
