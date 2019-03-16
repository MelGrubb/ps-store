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

namespace Store.Tests.Unit.ServiceTests.ProductServiceTests
{
    [TestFixture]
    public abstract class SpecsForProductService : SpecsForService<ProductService>
    {
        protected List<Product> Products;

        protected override void Given()
        {
            base.Given();

            Products = new List<Product>
            {
                new Product { Id = 1,
                    Name = GetRandom.String(50),
                    Description = GetRandom.String(255),
                    ProductStatusId = GetRandom.Id(),
                    CategoryId = GetRandom.Id(),
                    Price = GetRandom.Decimal(),                    
                },
            };

            GetMockFor<IProductRepository>()
                .Setup(x => x.AddAsync(It.IsAny<int>(), It.IsAny<Product>()))
                .Returns((int userId, Product model) => Task.FromResult(model))
                .Callback((int userId, Product model) =>
                {
                    model.Id = GetRandom.Id();
                    Products.Add(model);
                });

            GetMockFor<IProductRepository>()
                .Setup(x => x.DeleteAsync(It.IsAny<int>(), It.IsAny<int>()))
                .Returns((int userId, int id) => Task.FromResult(Products.SingleOrDefault(x => x.Id == id)))
                .Callback((int userId, int id) => { Products.RemoveAll(x => x.Id == id); });

            GetMockFor<IProductRepository>()
                .Setup(x => x.GetAsync(It.IsAny<int>(), It.IsAny<int>()))
                .Returns((int userId, int id) => Task.FromResult(Products.SingleOrDefault(x => x.Id == id)));

            GetMockFor<IProductRepository>()
                .Setup(x => x.GetAsync(It.IsAny<int>(), It.IsAny<Expression<Func<Product, bool>>>(), It.IsAny<PagingOptions>()))
                .Returns((int userId, Expression<Func<Product, bool>> predicate, PagingOptions queryOptions) => Task.FromResult(Products.AsQueryable().Where(predicate).ToList()));

            GetMockFor<IProductRepository>()
                .Setup(x => x.SingleOrDefaultAsync(It.IsAny<int>(), It.IsAny<Expression<Func<Product, bool>>>()))
                .Returns((int userId, Expression<Func<Product, bool>> predicate) => Task.FromResult(Products.AsQueryable().SingleOrDefault(predicate)));
        }
    }
}
