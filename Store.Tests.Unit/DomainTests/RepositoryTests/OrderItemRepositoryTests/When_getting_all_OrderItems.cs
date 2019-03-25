using System.Collections.Generic;
using NUnit.Framework;
using Shouldly;
using Store.Domain.Models;

namespace Store.Tests.Unit.DomainTests.RepositoryTests.OrderItemRepositoryTests
{
    [TestFixture]
    public class When_getting_all_OrderItems : Given_an_OrderItemRepository
    {
        private List<OrderItem> _models;

        protected override void When()
        {
            base.When();

            _models = SUT.GetAsync(AdminUserId).Result;
        }

        [Test]
        public void Then_multiple_OrderItems_are_returned()
        {
            _models.Count.ShouldBeGreaterThan(1);
        }
    }
}
