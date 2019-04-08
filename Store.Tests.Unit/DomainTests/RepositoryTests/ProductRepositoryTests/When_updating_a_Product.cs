using NUnit.Framework;
using Shouldly;
using Store.Domain.Models;
using Store.Tests.Unit.Framework;

namespace Store.Tests.Unit.DomainTests.RepositoryTests.ProductRepositoryTests
{
    [TestFixture]
    public class When_updating_a_Product : Given_a_ProductRepository
    {
        private Product _model;

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
            _model.Price = GetRandom.Decimal();
            _model.ProductStatusId = (int)ProductStatus.Ids.BackOrdered;
            SUT.SaveChangesAsync(AdminUserId).Wait();
        }

        [Test]
        public void Then_the_address_properties_should_have_been_updated()
        {
            var newCopy = SUT.GetAsync(AdminUserId, _model.Id).Result;
            newCopy.Id.ShouldBe(_model.Id);
            newCopy.Description.ShouldBe(_model.Description);
            newCopy.Name.ShouldBe(_model.Name);
            newCopy.Price.ShouldBe(_model.Price);
            newCopy.ProductStatusId.ShouldBe((int)ProductStatus.Ids.BackOrdered);
        }
    }
}
