using System.Linq;
using NUnit.Framework;
using Shouldly;
using Store.Domain.Models;

namespace Store.Tests.Unit.DomainTests.RepositoryTests.OrderRepositoryTests
{
    [TestFixture]
    public class When_adding_an_Order : Given_an_OrderRepository
    {
        private Order _model;
        private Order _result;

        [Test]
        public void Then_the_new_Order_should_have_an_Id()
        {
            _result.Id.ShouldBe(SUT.StoreContext.Orders.OrderByDescending(x => x.Id).First().Id);
        }

        protected override void Given()
        {
            base.Given();

            _model = new Order
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
            };
        }

        protected override void When()
        {
            base.When();

            _result = SUT.AddAsync(AdminUserId, _model).Result;
        }
    }
}
