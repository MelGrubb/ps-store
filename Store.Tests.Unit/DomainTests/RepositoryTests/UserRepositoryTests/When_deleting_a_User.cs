using NUnit.Framework;
using Store.Domain.Models;

namespace Store.Tests.Unit.DomainTests.RepositoryTests.UserRepositoryTests
{
    [TestFixture]
    public class When_deleting_a_User : Given_a_UserRepository
    {
        private User _model;

        protected override void Given()
        {
            base.Given();

            var model = new User
            {
                Address = new Address
                {
                    Line1 = "123 Any St.",
                    Line2 = "Suite 456",
                    City = "Anytown",
                    StateId = 1,
                    PostalCode = "12345"
                },
                FirstName = "Bob",
                LastName = "Buyer",
                UserName = "buyer@mailinator.com",
                PhoneNumber = "2345678901"
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
        public void Then_the_address_should_no_longer_exist()
        {
            var newCopy = SUT.GetAsync(AdminUserId, _model.Id).Result;

            Assert.IsNull(newCopy);
        }
    }
}
