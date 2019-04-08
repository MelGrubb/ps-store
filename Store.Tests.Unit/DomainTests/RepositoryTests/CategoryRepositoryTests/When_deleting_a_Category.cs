using NUnit.Framework;
using Store.Domain.Models;
using Store.Tests.Unit.Framework.Mothers;

namespace Store.Tests.Unit.DomainTests.RepositoryTests.CategoryRepositoryTests
{
    [TestFixture]
    public class When_deleting_a_Category : Given_a_CategoryRepository
    {
        private Category _model;

        protected override void Given()
        {
            base.Given();

            var model = CategoryMother.Typical();

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
