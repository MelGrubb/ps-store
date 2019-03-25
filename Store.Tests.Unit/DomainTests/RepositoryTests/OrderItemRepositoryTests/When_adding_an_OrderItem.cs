using System.Linq;
using NUnit.Framework;
using Shouldly;
using Store.Domain.Models;

namespace Store.Tests.Unit.DomainTests.RepositoryTests.OrderItemRepositoryTests
{
    [TestFixture]
    public class When_adding_an_OrderItem : Given_an_OrderItemRepository
    {
        private OrderItem _model;
        private OrderItem _result;

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

            _model = new OrderItem
            {
                Order = newOrder,
                Price = 1.00m,
                ProductId = 1
            };

            newOrder.OrderItems.Add(_model);
        }

        protected override void When()
        {
            base.When();

            _result = SUT.AddAsync(AdminUserId, _model).Result;
        }

        [Test]
        public void Then_the_new_OrderItem_should_have_an_Id()
        {
            _result.Id.ShouldBe(SUT.StoreContext.OrderItems.OrderByDescending(x => x.Id).First().Id);
        }
    }
}
