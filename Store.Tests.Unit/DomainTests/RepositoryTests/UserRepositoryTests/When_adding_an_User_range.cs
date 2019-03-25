using System.Collections.Generic;
using NUnit.Framework;
using Shouldly;
using Store.Domain.Models;

namespace Store.Tests.Unit.DomainTests.RepositoryTests.UserRepositoryTests
{
    [TestFixture]
    public class When_adding_an_User_range : Given_a_UserRepository
    {
        private List<User> _models;

        protected override void Given()
        {
            base.Given();

            _models = new List<User>
            {
                new User
                {
                    Address = new Address
                    {
                        Line1 = "123 Any St.",
                        Line2 = "Suite 456",
                        City = "Anytown",
                        StateId = 1,
                        ZipCode = "12345"
                    },
                    FirstName = "Bob",
                    LastName = "Buyer",
                    UserName = "buyer@mailinator.com",
                    PhoneNumber = "2345678901"
                },
                new User
                {
                    Address = new Address
                    {
                        Line1 = "456 Any St.",
                        Line2 = "Suite 123",
                        City = "Othertown",
                        StateId = 1,
                        ZipCode = "54321"
                    },
                    FirstName = "Sydney",
                    LastName = "Seller",
                    UserName = "seller@mailinator.com",
                    PhoneNumber = "2345678901"
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
