using System.Linq;
using NUnit.Framework;
using SpecsFor.Core.ShouldExtensions;
using Store.Domain.Models;
using Store.Domain.Repositories;
using Store.Services.Contracts.Order;

namespace Store.Tests.Unit.ServiceTests.OrderServiceTests
{
    [TestFixture]
    public class When_Updating : SpecsForOrderService
    {
        private Order _model;
        private OrderDto _dto;
        private OrderDto _result;

        protected override void Given()
        {
            base.Given();

            _model = Orders.First();

            _dto = new OrderDto
            {
                Id = _model.Id,
                OrderStatusId = _model.OrderStatusId,
                UserId = _model.UserId
            };
        }

        protected override async void When()
        {
            base.When();

            _result = await SUT.UpdateAsync(AdminUserId, _dto);
        }

        [Test]
        public void Then_SaveChanges_was_called()
        {
            GetMockFor<IOrderRepository>()
                .Verify(x => x.SaveChangesAsync(AdminUserId));
        }

        [Test]
        public void Then_the_database_was_updated()
        {
            _model.ShouldLookLikePartial(new
            {
                _dto.Id,
                _dto.OrderStatusId,
                _dto.UserId
            });
        }

        [Test]
        public void Then_the_updated_model_was_retrieved_from_the_repository()
        {
            GetMockFor<IOrderRepository>()
                .Verify(x => x.GetAsync(AdminUserId, _model.Id));
        }

        [Test]
        public void Then_the_updated_model_was_returned()
        {
            _result.ShouldLookLikePartial(new
            {
                _dto.Id,
                _dto.OrderStatusId,
                _dto.UserId
            });
        }
    }
}
