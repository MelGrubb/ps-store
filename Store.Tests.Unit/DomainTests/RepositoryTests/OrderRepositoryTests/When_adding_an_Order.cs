using NUnit.Framework;
using Shouldly;
using Store.Domain.Models;
using Store.Tests.Unit.Framework.Mothers;

namespace Store.Tests.Unit.DomainTests.RepositoryTests.OrderRepositoryTests
{
    [TestFixture]
    public class When_adding_an_Order : Given_an_OrderRepository
    {
        private Order _model;
        private Order _result;

        protected override void Given()
        {
            base.Given();

            _model = OrderMother.Typical();
        }

        protected override void When()
        {
            base.When();

            _result = SUT.AddAsync(AdminUserId, _model).Result;
        }

        [Test]
        public void Then_the_new_Order_should_have_an_Id()
        {
            _result.Id.ShouldBeGreaterThan(0);
        }
    }
}
