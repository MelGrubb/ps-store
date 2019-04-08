using NUnit.Framework;
using Shouldly;
using Store.Domain.Models;
using Store.Tests.Unit.Framework;

namespace Store.Tests.Unit.DomainTests.RepositoryTests.OrderItemRepositoryTests
{
    [TestFixture]
    public class When_updating_an_OrderItem : Given_an_OrderItemRepository
    {
        private OrderItem _model;

        protected override void Given()
        {
            base.Given();

            _model = SUT.GetAsync(AdminUserId, 1).Result;
        }

        protected override void When()
        {
            base.When();

            _model.Price = GetRandom.Decimal();
            _model.Quantity = GetRandom.Int32();
            SUT.SaveChangesAsync(AdminUserId).Wait();
        }

        [Test]
        public void Then_the_address_properties_should_have_been_updated()
        {
            var newCopy = SUT.GetAsync(AdminUserId, _model.Id).Result;
            newCopy.Id.ShouldBe(_model.Id);
            newCopy.Price.ShouldBe(_model.Price);
            newCopy.Quantity.ShouldBe(_model.Quantity);
        }
    }
}
