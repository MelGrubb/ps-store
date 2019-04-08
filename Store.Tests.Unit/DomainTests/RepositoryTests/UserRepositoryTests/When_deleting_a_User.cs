using NUnit.Framework;
using Store.Domain.Models;
using Store.Tests.Unit.Framework.Mothers;

namespace Store.Tests.Unit.DomainTests.RepositoryTests.UserRepositoryTests
{
    [TestFixture]
    public class When_deleting_a_User : Given_a_UserRepository
    {
        private User _model;

        protected override void Given()
        {
            base.Given();

            var model = UserMother.Simple();

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
