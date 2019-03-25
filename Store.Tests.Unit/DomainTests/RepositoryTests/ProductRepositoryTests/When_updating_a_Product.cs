using NUnit.Framework;
using Shouldly;
using Store.Domain.Models;

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

            _model.Description = "New Description";
            _model.Name = "New Name";
            _model.Price = 12.34m;
            _model.ProductStatusId = (int)ProductStatus.Ids.BackOrdered;
            SUT.SaveChangesAsync(AdminUserId).Wait();
        }

        [Test]
        public void Then_the_address_properties_should_have_been_updated()
        {
            var newCopy = SUT.GetAsync(AdminUserId, 1).Result;
            newCopy.Id.ShouldBe(1);
            newCopy.Description.ShouldBe("New Description");
            newCopy.Name.ShouldBe("New Name");
            newCopy.Price.ShouldBe(12.34m);
            newCopy.ProductStatusId.ShouldBe((int)ProductStatus.Ids.BackOrdered);
        }
    }
}
