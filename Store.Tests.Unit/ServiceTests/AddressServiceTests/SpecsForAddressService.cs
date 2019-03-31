using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Store.Common.Contracts;
using Store.Domain.Models;
using Store.Domain.Repositories;
using Store.Services;
using Store.Tests.Unit.Framework;

namespace Store.Tests.Unit.ServiceTests.AddressServiceTests
{
    [TestFixture]
    public abstract class SpecsForAddressService : SpecsForService<AddressService>
    {
        protected List<Address> Addresses;

        protected override void Given()
        {
            base.Given();

            Addresses = new List<Address>
            {
                new Address { Id = 1, Line1 = "123 Any St.", Line2 = "Suite 456", City = "AnyTown", StateId = 1, PostalCode = "12345" },
                new Address { Id = 2, Line1 = "456 Other St.", Line2 = "Suite 123", City = "OtherTown", StateId = 2, PostalCode = "54321" }
            };

            GetMockFor<IAddressRepository>()
                .Setup(x => x.AddAsync(It.IsAny<int>(), It.IsAny<Address>()))
                .Returns((int userId, Address model) => Task.FromResult(model))
                .Callback((int userId, Address model) =>
                {
                    model.Id = GetRandom.Id();
                    Addresses.Add(model);
                });

            GetMockFor<IAddressRepository>()
                .Setup(x => x.DeleteAsync(It.IsAny<int>(), It.IsAny<int>()))
                .Returns((int userId, int id) => Task.FromResult(Addresses.SingleOrDefault(x => x.Id == id)))
                .Callback((int userId, int id) => { Addresses.RemoveAll(x => x.Id == id); });

            GetMockFor<IAddressRepository>()
                .Setup(x => x.GetAsync(It.IsAny<int>(), It.IsAny<int>()))
                .Returns((int userId, int id) => Task.FromResult(Addresses.SingleOrDefault(x => x.Id == id)));

            GetMockFor<IAddressRepository>()
                .Setup(x => x.GetAsync(It.IsAny<int>(), It.IsAny<Expression<Func<Address, bool>>>(), It.IsAny<PagingOptions>()))
                .Returns((int userId, Expression<Func<Address, bool>> predicate, PagingOptions queryOptions) => Task.FromResult(Addresses.AsQueryable().Where(predicate).ToList()));

            GetMockFor<IAddressRepository>()
                .Setup(x => x.SingleOrDefaultAsync(It.IsAny<int>(), It.IsAny<Expression<Func<Address, bool>>>()))
                .Returns((int userId, Expression<Func<Address, bool>> predicate) => Task.FromResult(Addresses.AsQueryable().SingleOrDefault(predicate)));
        }
    }
}
