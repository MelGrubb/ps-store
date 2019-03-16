using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Store.Common.Contracts;
using Store.Domain.Models;
using Store.Domain.Repositories;
using Store.Services;
using Store.Tests.Unit.Framework;

namespace Store.Tests.Unit.ServiceTests.CategoryServiceTests
{
    [TestFixture]
    public abstract class SpecsForCategoryService : SpecsForService<CategoryService>
    {
        protected List<Category> Categories;

        protected override void Given()
        {
            base.Given();

            Categories = new List<Category>
            {
                new Category { Id = (int)Category.Ids.Clothing, Name = "Clothing", Description = "Clothing Description" },
                new Category { Id = (int)Category.Ids.Mens, Name = "Men's Clothing", Description = "Men's Clothing Description", ParentCategoryId = (int)Category.Ids.Clothing },
                new Category { Id = (int)Category.Ids.Womens, Name = "Women's Clothing", Description = "Women's Clothing Description", ParentCategoryId = (int)Category.Ids.Clothing }
            };

            GetMockFor<ICategoryRepository>()
                .Setup(x => x.AddAsync(It.IsAny<int>(), It.IsAny<Category>()))
                .Returns((int userId, Category model) => Task.FromResult(model))
                .Callback((int userId, Category model) =>
                {
                    model.Id = GetRandom.Id();
                    Categories.Add(model);
                });

            GetMockFor<ICategoryRepository>()
                .Setup(x => x.DeleteAsync(It.IsAny<int>(), It.IsAny<int>()))
                .Returns((int userId, int id) => Task.FromResult(Categories.SingleOrDefault(x => x.Id == id)))
                .Callback((int userId, int id) => { Categories.RemoveAll(x => x.Id == id); });

            GetMockFor<ICategoryRepository>()
                .Setup(x => x.GetAsync(It.IsAny<int>(), It.IsAny<int>()))
                .Returns((int userId, int id) => Task.FromResult(Categories.SingleOrDefault(x => x.Id == id)));

            GetMockFor<ICategoryRepository>()
                .Setup(x => x.GetAsync(It.IsAny<int>(), It.IsAny<Expression<Func<Category, bool>>>(), It.IsAny<PagingOptions>()))
                .Returns((int userId, Expression<Func<Category, bool>> predicate, PagingOptions queryOptions) => Task.FromResult(Categories.AsQueryable().Where(predicate).ToList()));

            GetMockFor<ICategoryRepository>()
                .Setup(x => x.SingleOrDefaultAsync(It.IsAny<int>(), It.IsAny<Expression<Func<Category, bool>>>()))
                .Returns((int userId, Expression<Func<Category, bool>> predicate) => Task.FromResult(Categories.AsQueryable().SingleOrDefault(predicate)));
        }
    }
}
