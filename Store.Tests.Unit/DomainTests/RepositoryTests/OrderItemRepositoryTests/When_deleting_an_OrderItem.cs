using NUnit.Framework;
using Store.Domain.Models;
using Store.Tests.Unit.Framework.Mothers;

namespace Store.Tests.Unit.DomainTests.RepositoryTests.OrderItemRepositoryTests
{
    [TestFixture]
    public class When_deleting_an_OrderItem : Given_an_OrderItemRepository
    {
        private OrderItem _model;

        protected override void Given()
        {
            base.Given();

            var order = OrderMother.Simple();
            var model = new OrderItem
            {
                Order = order,
                Price = 1.00m,
                ProductId = 1
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
