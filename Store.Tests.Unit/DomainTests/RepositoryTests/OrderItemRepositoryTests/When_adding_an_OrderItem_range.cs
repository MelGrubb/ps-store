using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Shouldly;
using Store.Domain.Models;
using Store.Tests.Unit.Framework.Mothers;

namespace Store.Tests.Unit.DomainTests.RepositoryTests.OrderItemRepositoryTests
{
    [TestFixture]
    public class When_adding_an_OrderItem_range : Given_an_OrderItemRepository
    {
        private List<OrderItem> _models;
        private int _originalCount;

        protected override void Given()
        {
            base.Given();

            var order = OrderMother.Simple();

            _models = new List<OrderItem>
            {
                new OrderItem
                {
                    Order = order,
                    Price = 1.00m,
                    ProductId = 1
                },
                new OrderItem
                {
                    Order = order,
                    Price = 2.00m,
                    ProductId = 2
                }
            };

            _originalCount = SUT.CountAsync().Result;
        }

        protected override void When()
        {
            base.When();

            SUT.AddRangeAsync(AdminUserId, _models).Wait();
        }

        [Test]
        public void Then_the_new_OrderItems_should_have_an_Id()
        {
            _models.ForEach(x => x.Id.ShouldBeGreaterThan(0));
        }

        [Test]
        public void Then_the_new_OrderItems_were_added_to_the_table()
        {
            SUT.CountAsync().Result.ShouldBe(_originalCount + _models.Count);
        }
    }
}
