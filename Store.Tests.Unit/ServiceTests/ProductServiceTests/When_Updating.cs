using System.Linq;
using NUnit.Framework;
using SpecsFor.Core.ShouldExtensions;
using Store.Domain.Models;
using Store.Domain.Repositories;
using Store.Services.Contracts.Product;

namespace Store.Tests.Unit.ServiceTests.ProductServiceTests
{
    [TestFixture]
    public class When_Updating : SpecsForProductService
    {
        private Product _model;
        private ProductDto _dto;
        private ProductDto _result;

        protected override void Given()
        {
            base.Given();

            _model = Products.First();

            _dto = new ProductDto
            {
                Id = _model.Id,
                Name = _model.Name,
                Description = _model.Description,
                CategoryId = _model.CategoryId,
                ProductStatusId = _model.ProductStatusId,
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
            GetMockFor<IProductRepository>()
                .Verify(x => x.SaveChangesAsync(AdminUserId));
        }

        [Test]
        public void Then_the_database_was_updated()
        {
            _model.ShouldLookLikePartial(new
            {
                _dto.Id,
                _dto.Name,
                _dto.Description,
                _dto.CategoryId,
                _dto.ProductStatusId,
            });
        }

        [Test]
        public void Then_the_updated_model_was_retrieved_from_the_repository()
        {
            GetMockFor<IProductRepository>()
                .Verify(x => x.GetAsync(AdminUserId, _model.Id));
        }

        [Test]
        public void Then_the_updated_model_was_returned()
        {
            _result.ShouldLookLikePartial(new
            {
                _dto.Id,
                _dto.Name,
                _dto.Description,
                _dto.CategoryId,
                _dto.ProductStatusId,
            });
        }
    }
}
