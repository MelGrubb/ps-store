using System.Linq;
using NUnit.Framework;
using Shouldly;
using Store.Domain.Models;

namespace Store.Tests.Unit.DomainTests.RepositoryTests.UserRepositoryTests
{
    [TestFixture]
    public class When_adding_a_User : Given_a_UserRepository
    {
        private User _model;
        private User _result;

        protected override void Given()
        {
            base.Given();

            _model = new User
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
        }

        protected override void When()
        {
            base.When();

            _result = SUT.AddAsync(AdminUserId, _model).Result;
        }

        [Test]
        public void Then_the_new_User_should_have_an_Id()
        {
            _result.Id.ShouldBe(SUT.StoreContext.Users.OrderByDescending(x => x.Id).First().Id);
        }
    }
}
