using NUnit.Framework;
using Shouldly;
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
            newCopy.Id.ShouldBe(1);
            newCopy.FirstName.ShouldBe("New FirstName");
            newCopy.MiddleName.ShouldBe("New MiddleName");
            newCopy.LastName.ShouldBe("New LastName");
            newCopy.UserName.ShouldBe("New UserName");
        }
    }
}
