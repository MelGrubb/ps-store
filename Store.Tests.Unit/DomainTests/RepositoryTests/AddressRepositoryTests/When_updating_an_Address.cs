using NUnit.Framework;
using Should;
using Store.Domain.Models;

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

            _model.Line1 = "123 New St.";
            _model.Line2 = "Suite 456";
            _model.City = "New City";
            _model.StateId = 2;
            _model.ZipCode = "98765";
            SUT.SaveChangesAsync(AdminUserId).Wait();
        }

        [Test]
        public void Then_the_address_properties_should_have_been_updated()
        {
            var newCopy = SUT.GetAsync(AdminUserId, 1).Result;
            newCopy.Id.ShouldEqual(1);
            newCopy.Line1.ShouldEqual("123 New St.");
            newCopy.Line2.ShouldEqual("Suite 456");
            newCopy.City.ShouldEqual("New City");
            newCopy.StateId.ShouldEqual(2);
            newCopy.ZipCode.ShouldEqual("98765");
        }
    }
}
