using System.Collections.Generic;
using NUnit.Framework;
using Shouldly;
using Store.Domain.Models;

namespace Store.Tests.Unit.DomainTests.RepositoryTests.AddressRepositoryTests
{
    [TestFixture]
    public class When_adding_an_Address_range : Given_an_AddressRepository
    {
        private List<Address> _models;

        protected override void Given()
        {
            base.Given();

            _models = new List<Address>
            {
                new Address
                {
                    Line1 = "123 Any St.",
                    Line2 = "Suite 456",
                    City = "AnyTown",
                    StateId = 1,
                    ZipCode = "12345"
                },
                new Address
                {
                    Line1 = "456 Other St.",
                    Line2 = "Suite 123",
                    City = "OtherTown",
                    StateId = 2,
                    ZipCode = "54321"
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
