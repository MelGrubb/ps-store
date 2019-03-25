using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Shouldly;
using SpecsFor.Core.ShouldExtensions;
using Store.Domain.Models;
using Store.Domain.Repositories;
using Store.Services.Contracts.Product;
using Store.Tests.Unit.Framework;

namespace Store.Tests.Unit.ServiceTests.ProductServiceTests
{
    [TestFixture]
    public class When_Adding : SpecsForProductService
    {
        private ProductDto _dto;
        private ProductDto _result;
        private Product _newModel;

        protected override void Given()
        {
            base.Given();

            _dto = new ProductDto
            {
                Description = GetRandom.String(255),
                Name = GetRandom.String(50),
                Price = GetRandom.Decimal(),
                CategoryId = GetRandom.Id(),
                ProductStatusId = GetRandom.Id(),
            };

            _newModel = new Product
            {
                Id = GetRandom.Id(),
                CategoryId = _dto.CategoryId,
                ProductStatusId = _dto.ProductStatusId,
                Name = _dto.Name,
                Description = _dto.Description,
                Price = _dto.Price,
            };

            GetMockFor<IProductRepository>()
                .Setup(x => x.AddAsync(It.IsAny<int>(), It.IsAny<Product>()))
                .Returns((int userId, Product model) => Task.FromResult(_newModel));
        }

        protected override void When()
        {
            base.When();

            _result = SUT.AddAsync(AdminUserId, _dto).Result;
        }

        [Test]
        public void Then_the_new_Product_has_an_Id()
        {
            _result.Id.ShouldBeGreaterThan(0);
        }

        [Test]
        public void Then_the_new_Product_is_returned()
        {
            _result.ShouldLookLikePartial(new
            {
                _dto.Name,
                _dto.Description,
                _dto.Price,
                _dto.CategoryId,
                _dto.ProductStatusId,
            });
        }

        [Test]
        public void Then_the_new_Product_was_added_to_the_database()
        {
            GetMockFor<IProductRepository>()
                .Verify(x => x.AddAsync(AdminUserId, It.Is<Product>(a => a.Id == _dto.Id)));
        }
    }
}
