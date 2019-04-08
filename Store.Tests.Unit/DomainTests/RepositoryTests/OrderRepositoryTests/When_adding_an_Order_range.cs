using System.Collections.Generic;
using NUnit.Framework;
using Shouldly;
using Store.Domain.Models;
using Store.Tests.Unit.Framework.Mothers;

namespace Store.Tests.Unit.DomainTests.RepositoryTests.OrderRepositoryTests
{
    [TestFixture]
    public class When_adding_an_Order_range : Given_an_OrderRepository
    {
        private List<Order> _models;
        private int _originalCount;

        protected override void Given()
        {
            base.Given();

            _models = new List<Order>
            {
                OrderMother.Typical(),
                OrderMother.Typical()
            };

            _originalCount = SUT.CountAsync().Result;
        }

        protected override void When()
        {
            base.When();

            SUT.AddRangeAsync(AdminUserId, _models).Wait();
        }

        [Test]
        public void Then_the_new_Orders_should_have_an_Id()
        {
            _models.ForEach(x => x.Id.ShouldBeGreaterThan(0));
        }

        [Test]
        public void Then_the_new_Orders_were_added_to_the_table()
        {
            SUT.CountAsync().Result.ShouldBe(_originalCount + _models.Count);
        }
    }
}
