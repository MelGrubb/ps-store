using System.Collections.Generic;
using NUnit.Framework;
using Shouldly;
using Store.Domain.Models;

namespace Store.Tests.Unit.DomainTests.RepositoryTests.OrderRepositoryTests
{
    [TestFixture]
    public class When_adding_an_Order_range : Given_an_OrderRepository
    {
        private List<Order> _models;

        protected override void Given()
        {
            base.Given();

            _models = new List<Order>
            {
                new Order
                {
                    BillingAddress = new Address
                    {
                        Line1 = "Billing Dept.",
                        Line2 = "123 Billing St.",
                        City = "BillingTown",
                        StateId = 1,
                        PostalCode = "12345"
                    },
                    ShippingAddress = new Address
                    {
                        Line1 = "Receiving Dept.",
                        Line2 = "123 Receiving St.",
                        City = "ReceivingTown",
                        StateId = 1,
                        PostalCode = "54321"
                    },
                    OrderStatusId = (int)OrderStatus.Ids.Received,
                    UserId = (int)User.Ids.SampleCustomer
                },
                new Order
                {
                    BillingAddress = new Address
                    {
                        Line1 = "Billing Dept.",
                        Line2 = "123 Billing St.",
                        City = "BillingTown",
                        StateId = 1,
                        PostalCode = "12345"
                    },
                    ShippingAddress = new Address
                    {
                        Line1 = "Receiving Dept.",
                        Line2 = "123 Receiving St.",
                        City = "ReceivingTown",
                        StateId = 1,
                        PostalCode = "54321"
                    },
                    OrderStatusId = (int)OrderStatus.Ids.Processing,
                    UserId = (int)User.Ids.SampleCustomer
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
            SUT.CountAsync().Result.ShouldBe(6);
        }
    }
}
