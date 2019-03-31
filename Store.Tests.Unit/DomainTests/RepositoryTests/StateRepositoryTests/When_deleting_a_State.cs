using NUnit.Framework;
using Store.Domain.Models;

namespace Store.Tests.Unit.DomainTests.RepositoryTests.StateRepositoryTests
{
    [TestFixture]
    public class When_deleting_a_State : Given_a_StateRepository
    {
        private State _model;

        protected override void Given()
        {
            base.Given();

            var model = new State
            {
                CountryId = 1,
                Name = "New State",
                Description = "New State"
            };

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
