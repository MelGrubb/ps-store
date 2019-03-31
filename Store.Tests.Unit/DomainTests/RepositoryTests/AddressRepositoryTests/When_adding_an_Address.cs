using NUnit.Framework;
using Shouldly;
using Store.Domain.Models;

namespace Store.Tests.Unit.DomainTests.RepositoryTests.AddressRepositoryTests
{
    [TestFixture]
    public class When_adding_an_Address : Given_an_AddressRepository
    {
        private Address _model;
        private Address _result;

        protected override void Given()
        {
            base.Given();

            _model = new Address
            {
                Line1 = "123 Any St.",
                Line2 = "Suite 456",
                City = "AnyTown",
                StateId = 1,
                ZipCode = "12345"
            };
        }

        protected override void When()
        {
            base.When();

            _result = SUT.AddAsync(AdminUserId, _model).Result;
        }

        [Test]
        public void Then_the_new_address_should_have_an_Id()
        {
            _result.Id.ShouldBe(3);
        }
    }
}
