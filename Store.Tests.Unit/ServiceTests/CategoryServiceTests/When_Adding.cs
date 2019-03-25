using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Shouldly;
using SpecsFor.Core.ShouldExtensions;
using Store.Domain.Models;
using Store.Domain.Repositories;
using Store.Services.Contracts.Category;
using Store.Tests.Unit.Framework;

namespace Store.Tests.Unit.ServiceTests.CategoryServiceTests
{
    [TestFixture]
    public class When_Adding : SpecsForCategoryService
    {
        private CategoryDto _dto;
        private CategoryDto _result;
        private Category _newModel;

        protected override void Given()
        {
            base.Given();

            _dto = new CategoryDto
            {
                Name = GetRandom.String(255),
                Description = GetRandom.String(255)
            };

            _newModel = new Category
            {
                Id = GetRandom.Id(),
                Name = _dto.Name,
                Description = _dto.Description
            };

            GetMockFor<ICategoryRepository>()
                .Setup(x => x.AddAsync(It.IsAny<int>(), It.IsAny<Category>()))
                .Returns((int userId, Category model) => Task.FromResult(_newModel));
        }

        protected override void When()
        {
            base.When();

            _result = SUT.AddAsync(AdminUserId, _dto).Result;
        }

        [Test]
        public void Then_the_new_Category_has_an_Id()
        {
            _result.Id.ShouldBeGreaterThan(0);
        }

        [Test]
        public void Then_the_new_Category_is_returned()
        {
            _result.ShouldLookLikePartial(new
            {
                _dto.Name,
                _dto.Description
            });
        }

        [Test]
        public void Then_the_new_Category_was_added_to_the_database()
        {
            GetMockFor<ICategoryRepository>()
                .Verify(x => x.AddAsync(AdminUserId, It.Is<Category>(a => a.Id == _dto.Id)));
        }
    }
}
