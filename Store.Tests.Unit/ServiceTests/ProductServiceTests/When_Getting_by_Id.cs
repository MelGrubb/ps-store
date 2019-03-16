using System.Linq;
using NUnit.Framework;
using SpecsFor.Core.ShouldExtensions;
using Store.Domain.Models;
using Store.Services.Contracts.Product;

namespace Store.Tests.Unit.ServiceTests.ProductServiceTests
{
    [TestFixture]
    public class When_Getting_by_Id : SpecsForProductService
    {
        private ProductDto _result;
        private Product _expected;

        protected override void Given()
        {
            base.Given();
            _expected = Products.First();
        }

        protected override async void When()
        {
            base.When();
            _result = await SUT.GetAsync(AdminUserId, _expected.Id);
        }

        [Test]
        public void Then_only_the_matching_model_was_returned()
        {
            _result.ShouldLookLikePartial(new
            {
                _expected.Id,
                _expected.Name,
                _expected.Description,
                _expected.CategoryId,
                _expected.ProductStatusId,
            });
        }
    }
}
