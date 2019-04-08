using NUnit.Framework;
using Shouldly;
using Store.Domain.Models;
using Store.Tests.Unit.Framework.Mothers;

namespace Store.Tests.Unit.DomainTests.RepositoryTests.UserRepositoryTests
{
    [TestFixture]
    public class When_adding_a_User : Given_a_UserRepository
    {
        private User _model;
        private User _result;

        protected override void Given()
        {
            base.Given();

            _model = UserMother.Typical();
        }

        protected override void When()
        {
            base.When();

            _result = SUT.AddAsync(AdminUserId, _model).Result;
        }

        [Test]
        public void Then_the_new_User_should_have_an_Id()
        {
            _result.Id.ShouldBeGreaterThan(0);
        }
    }
}
