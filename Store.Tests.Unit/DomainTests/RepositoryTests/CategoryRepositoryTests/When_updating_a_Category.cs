using NUnit.Framework;
using Shouldly;
using Store.Domain.Models;
using Store.Tests.Unit.Framework;

namespace Store.Tests.Unit.DomainTests.RepositoryTests.CategoryRepositoryTests
{
    [TestFixture]
    public class When_updating_a_Category : Given_a_CategoryRepository
    {
        private Category _model;

        protected override void Given()
        {
            base.Given();

            _model = SUT.GetAsync(AdminUserId, 1).Result;
        }

        protected override void When()
        {
            base.When();

            _model.Description = GetRandom.String(1, 255);
            _model.Name = GetRandom.String(1, 50);
            SUT.SaveChangesAsync(AdminUserId).Wait();
        }

        [Test]
        public void Then_the_address_properties_should_have_been_updated()
        {
            var newCopy = SUT.GetAsync(AdminUserId, _model.Id).Result;
            newCopy.Id.ShouldBe(_model.Id);
            newCopy.Description.ShouldBe(_model.Description);
            newCopy.Name.ShouldBe(_model.Name);
        }
    }
}
