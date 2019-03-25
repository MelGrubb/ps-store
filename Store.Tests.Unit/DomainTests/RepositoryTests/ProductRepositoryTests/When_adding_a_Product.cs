using System.Linq;
using NUnit.Framework;
using Shouldly;
using Store.Domain.Models;

namespace Store.Tests.Unit.DomainTests.RepositoryTests.ProductRepositoryTests
{
    [TestFixture]
    public class When_adding_a_Product : Given_a_ProductRepository
    {
        private Product _model;
        private Product _result;

        protected override void Given()
        {
            base.Given();

            _model = new Product
            {
                CategoryId = (int)Category.Ids.Mens,
                Description = "Men's Blue Oxford",
                Name = "Men's Blue Oxford",
                Price = 10.00m,
                ProductStatusId = (int)ProductStatus.Ids.InStock
            };
        }

        protected override void When()
        {
            base.When();

            _result = SUT.AddAsync(AdminUserId, _model).Result;
        }

        [Test]
        public void Then_the_new_Product_should_have_an_Id()
        {
            _result.Id.ShouldBe(SUT.StoreContext.Products.OrderByDescending(x => x.Id).First().Id);
        }
    }
}
