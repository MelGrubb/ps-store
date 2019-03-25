using System.Collections.Generic;
using NUnit.Framework;
using Shouldly;
using Store.Domain.Models;

namespace Store.Tests.Unit.DomainTests.RepositoryTests.ProductRepositoryTests
{
    [TestFixture]
    public class When_adding_an_Product_range : Given_a_ProductRepository
    {
        private List<Product> _models;

        protected override void Given()
        {
            base.Given();

            _models = new List<Product>
            {
                new Product
                {
                    CategoryId = (int)Category.Ids.Mens,
                    Description = "Men's Blue Oxford",
                    Name = "Men's Blue Oxford",
                    Price = 10.00m,
                    ProductStatusId = (int)ProductStatus.Ids.InStock
                },
                new Product
                {
                    CategoryId = (int)Category.Ids.Womens,
                    Description = "Women's Black Blazer",
                    Name = "Women's Black Blazer",
                    Price = 20.00m,
                    ProductStatusId = (int)ProductStatus.Ids.InStock
                }
            };
        }

        protected override void When()
        {
            base.When();

            SUT.AddRangeAsync(AdminUserId, _models).Wait();
        }

        [Test]
        public void Then_the_new_address_should_have_an_Id()
        {
            SUT.CountAsync().Result.ShouldBe(4);
        }
    }
}
