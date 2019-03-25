using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Shouldly;
using SpecsFor.Core.ShouldExtensions;
using Store.Domain.Models;
using Store.Domain.Repositories;
using Store.Services.Contracts.Order;
using Store.Tests.Unit.Framework;

namespace Store.Tests.Unit.ServiceTests.OrderServiceTests
{
    [TestFixture]
    public class When_Adding : SpecsForOrderService
    {
        private OrderDto _dto;
        private OrderDto _result;
        private Order _newModel;

        protected override void Given()
        {
            base.Given();

            _dto = new OrderDto
            {
                OrderStatusId = GetRandom.Id(),
                UserId = GetRandom.Id(),                
            };

            _newModel = new Order
            {
                Id = GetRandom.Id(),
                OrderStatusId = _dto.OrderStatusId,
                UserId = _dto.UserId
            };

            GetMockFor<IOrderRepository>()
                .Setup(x => x.AddAsync(It.IsAny<int>(), It.IsAny<Order>()))
                .Returns((int userId, Order model) => Task.FromResult(_newModel));
        }

        protected override void When()
        {
            base.When();

            _result = SUT.AddAsync(AdminUserId, _dto).Result;
        }

        [Test]
        public void Then_the_new_Order_has_an_Id()
        {
            _result.Id.ShouldBeGreaterThan(0);
        }

        [Test]
        public void Then_the_new_Order_is_returned()
        {
            _result.ShouldLookLikePartial(new
            {
                _dto.OrderStatusId,
                _dto.UserId,
            });
        }

        [Test]
        public void Then_the_new_Order_was_added_to_the_database()
        {
            GetMockFor<IOrderRepository>()
                .Verify(x => x.AddAsync(AdminUserId, It.Is<Order>(a => a.Id == _dto.Id)));
        }
    }
}
