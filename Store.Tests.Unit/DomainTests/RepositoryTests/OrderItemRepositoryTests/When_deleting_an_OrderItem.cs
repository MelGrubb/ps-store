using NUnit.Framework;
using Store.Domain.Models;

namespace Store.Tests.Unit.DomainTests.RepositoryTests.OrderItemRepositoryTests
{
    [TestFixture]
    public class When_deleting_an_OrderItem : Given_an_OrderItemRepository
    {
        private OrderItem _model;

        protected override void Given()
        {
            base.Given();

            var newOrder = new Order
            {
                BillingAddress = new Address
                {
                    Line1 = "Billing Dept.",
                    Line2 = "123 Billing St.",
                    City = "BillingTown",
                    StateId = 1,
                    ZipCode = "12345"
                },
                ShippingAddress = new Address
                {
                    Line1 = "Receiving Dept.",
                    Line2 = "123 Receiving St.",
                    City = "ReceivingTown",
                    StateId = 1,
                    ZipCode = "54321"
                },
                OrderStatusId = (int)OrderStatus.Ids.Received,
                UserId = (int)User.Ids.SampleCustomer
            };

            var model = new OrderItem
            {
                Order = newOrder,
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
