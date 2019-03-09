using NUnit.Framework;
using Store.Domain.Models;

namespace Store.Tests.Unit.DomainTests.RepositoryTests.ProductRepositoryTests
{
    [TestFixture]
    public class When_deleting_a_Product : Given_a_ProductRepository
    {
        private Product _model;

        protected override void Given()
        {
            base.Given();

            var model = new Product
            {
                CategoryId = (int)Category.Ids.Mens,
                Description = "Men's Blue Oxford",
                Name = "Men's Blue Oxford",
                Price = 10.00m,
                ProductStatusId = (int)ProductStatus.Ids.InStock
            };

            _model = SUT.AddAsync(AdminUserId, model).Result;
            Assert.IsNotNull(SUT.GetAsync(AdminUserId, _model.Id).Result);
        }

        protected override void When()
        {
            base.When();

            SUT.DeleteAsync(AdminUserId, _model.Id).Wait();
        }

        [Test]
        public void Then_the_product_should_no_longer_exist()
        {
            var newCopy = SUT.GetAsync(AdminUserId, _model.Id).Result;

            Assert.IsNull(newCopy);
        }
    }
}
