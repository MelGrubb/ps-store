using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Shouldly;
using SpecsFor.Core.ShouldExtensions;
using Store.Domain.Models;
using Store.Domain.Repositories;
using Store.Services.Contracts.Address;
using Store.Tests.Unit.Framework;

namespace Store.Tests.Unit.ServiceTests.AddressServiceTests
{
    [TestFixture]
    public class When_Adding : SpecsForAddressService
    {
        private AddressDto _dto;
        private AddressDto _result;
        private Address _newModel;

        protected override void Given()
        {
            base.Given();

            _dto = new AddressDto
            {
                Line1 = GetRandom.String(50),
                Line2 = GetRandom.String(50),
                City = GetRandom.String(50),
                StateId = GetRandom.Int32(),
                PostalCode = GetRandom.String(10)
            };

            _newModel = new Address
            {
                Id = GetRandom.Id(),
                Line1 = _dto.Line1,
                Line2 = _dto.Line2,
                City = _dto.City,
                StateId = _dto.StateId,
                State = new State
                {
                    Id = _dto.StateId,
                    Name = GetRandom.String(50),
                    Description = GetRandom.String(255)
                },
                PostalCode = _dto.PostalCode
            };

            GetMockFor<IAddressRepository>()
                .Setup(x => x.AddAsync(It.IsAny<int>(), It.IsAny<Address>()))
                .Returns((int userId, Address model) => Task.FromResult(_newModel));
        }

        protected override void When()
        {
            base.When();

            _result = SUT.AddAsync(AdminUserId, _dto).Result;
        }

        [Test]
        public void Then_the_new_Address_has_an_Id()
        {
            _result.Id.ShouldBeGreaterThan(0);
        }

        [Test]
        public void Then_the_new_Address_is_returned()
        {
            _result.ShouldLookLikePartial(new
            {
                _dto.Line1,
                _dto.Line2,
                _dto.City,
                _dto.StateId,
                _dto.PostalCode
            });
        }

        [Test]
        public void Then_the_new_Address_was_added_to_the_database()
        {
            GetMockFor<IAddressRepository>()
                .Verify(x => x.AddAsync(AdminUserId, It.Is<Address>(a => a.Id == _dto.Id)));
        }
    }
}
