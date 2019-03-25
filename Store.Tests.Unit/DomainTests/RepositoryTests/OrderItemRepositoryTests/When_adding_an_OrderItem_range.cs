using System.Collections.Generic;
using NUnit.Framework;
using Shouldly;
using Store.Domain.Models;

namespace Store.Tests.Unit.DomainTests.RepositoryTests.OrderItemRepositoryTests
{
    [TestFixture]
    public class When_adding_an_OrderItem_range : Given_an_OrderItemRepository
    {
        private List<OrderItem> _models;

        protected override void Given()
        {
            base.Given();

            var billingAddress = new Address
            {
                Line1 = "Billing Dept.",
                Line2 = "123 Billing St.",
                City = "BillingTown",
                StateId = 1,
                ZipCode = "12345"
            };

            var shippingAddress = new Address
            {
                Line1 = "Receiving Dept.",
                Line2 = "123 Receiving St.",
                City = "ReceivingTown",
                StateId = 1,
                ZipCode = "54321"
            };

            var newOrder = new Order
            {
                BillingAddress = billingAddress,
                ShippingAddress = shippingAddress,
                OrderStatusId = (int)OrderStatus.Ids.Received,
                UserId = (int)User.Ids.SampleCustomer
            };

            _models = new List<OrderItem>
            {
                new OrderItem
                {
                    Order = newOrder,
                    Price = 1.00m,
                    ProductId = 1
                },
                new OrderItem
                {
                    Order = newOrder,
                    Price = 2.00m,
                    ProductId = 2
                }
            };
        }

        protected override void When()
        {
            base.When();

            SUT.AddRangeAsync(AdminUserId, _models).Wait();
        }

        [Test]
        public void Then_the_new_address_should_have_an_Id()
        {
            SUT.CountAsync().Result.ShouldBe(10);
        }
    }
}
