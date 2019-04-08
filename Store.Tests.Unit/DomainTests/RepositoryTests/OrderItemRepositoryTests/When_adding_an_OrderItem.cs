using System.Linq;
using NUnit.Framework;
using Shouldly;
using Store.Domain.Models;
using Store.Tests.Unit.Framework.Mothers;

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

            var order = OrderMother.Simple();

            _model = new OrderItem
            {
                Order = order,
                Price = 1.00m,
                ProductId = 1
            };

            order.OrderItems.Add(_model);
        }

        protected override void When()
        {
            base.When();

            _result = SUT.AddAsync(AdminUserId, _model).Result;
        }

        [Test]
        public void Then_the_new_OrderItem_should_have_an_Id()
        {
            _result.Id.ShouldBeGreaterThan(0);
        }
    }
}
