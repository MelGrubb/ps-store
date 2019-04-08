using NUnit.Framework;
using Shouldly;
using Store.Domain.Models;
using Store.Tests.Unit.Framework;

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

            _model.FirstName = GetRandom.FirstName();
            _model.MiddleName = GetRandom.FirstName();
            _model.LastName = GetRandom.LastName();
            _model.UserName = GetRandom.String(1, 50);

            SUT.SaveChangesAsync(AdminUserId).Wait();
        }

        [Test]
        public void Then_the_address_properties_should_have_been_updated()
        {
            var newCopy = SUT.GetAsync(AdminUserId, _model.Id).Result;
            newCopy.Id.ShouldBe(_model.Id);
            newCopy.FirstName.ShouldBe(_model.FirstName);
            newCopy.MiddleName.ShouldBe(_model.MiddleName);
            newCopy.LastName.ShouldBe(_model.LastName);
            newCopy.UserName.ShouldBe(_model.UserName);
        }
    }
}
