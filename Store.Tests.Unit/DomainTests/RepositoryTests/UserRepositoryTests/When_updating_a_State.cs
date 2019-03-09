using NUnit.Framework;
using Should;
using Store.Domain.Models;

namespace Store.Tests.Unit.DomainTests.RepositoryTests.UserRepositoryTests
{
    [TestFixture]
    public class When_updating_a_User : Given_a_UserRepository
    {
        private User _model;

        protected override void Given()
        {
            base.Given();

            _model = SUT.GetAsync(AdminUserId, 1).Result;
        }

        protected override void When()
        {
            base.When();

            _model.FirstName = "New FirstName";
            _model.MiddleName = "New MiddleName";
            _model.LastName = "New LastName";
            _model.UserName = "New UserName";

            SUT.SaveChangesAsync(AdminUserId).Wait();
        }

        [Test]
        public void Then_the_address_properties_should_have_been_updated()
        {
            var newCopy = SUT.GetAsync(AdminUserId, 1).Result;
            newCopy.Id.ShouldEqual(1);
            newCopy.FirstName.ShouldEqual("New FirstName");
            newCopy.MiddleName.ShouldEqual("New MiddleName");
            newCopy.LastName.ShouldEqual("New LastName");
            newCopy.UserName.ShouldEqual("New UserName");
        }
    }
}
