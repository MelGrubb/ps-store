using System.Linq;
using NUnit.Framework;
using SpecsFor.Core.ShouldExtensions;
using Store.Domain.Models;
using Store.Domain.Repositories;
using Store.Services.Contracts.Address;
using Store.Tests.Unit.Framework;

namespace Store.Tests.Unit.ServiceTests.AddressServiceTests
{
    [TestFixture]
    public class When_Updating : SpecsForAddressService
    {
        private Address _model;
        private AddressDto _dto;
        private AddressDto _result;

        protected override void Given()
        {
            base.Given();

            _model = Addresses.First();

            _dto = new AddressDto
            {
                Id = _model.Id,
                Line1 = GetRandom.String(50),
                Line2 = GetRandom.String(50),
                City = GetRandom.String(50),
                StateId = GetRandom.Int32(),
                ZipCode = GetRandom.String(10)
            };
        }

        protected override async void When()
        {
            base.When();

            _result = await SUT.UpdateAsync(AdminUserId, _dto);
        }

        [Test]
        public void Then_the_updated_model_was_retrieved_from_the_repository()
        {
            GetMockFor<IAddressRepository>()
                .Verify(x=>x.GetAsync(AdminUserId, _model.Id));
        }

        [Test]
        public void Then_SaveChanges_was_called()
        {
            GetMockFor<IAddressRepository>()
                .Verify(x => x.SaveChangesAsync(AdminUserId));
        }

        [Test]
        public void Then_the_updated_model_was_returned()
        {
            _result.ShouldLookLikePartial(new
            {
                _dto.Id,
                _dto.Line1,
                _dto.Line2,
                _dto.City,
                _dto.StateId,
                _dto.ZipCode
            });
        }

        [Test]
        public void Then_the_database_was_updated()
        {
            _model.ShouldLookLikePartial(new
            {
                _dto.Id,
                _dto.Line1,
                _dto.Line2,
                _dto.City,
                _dto.StateId,
                _dto.ZipCode
            });
        }
    }
}
