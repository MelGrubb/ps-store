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

namespace Store.Tests.Unit.ServiceTests.CountryServiceTests
{
    [TestFixture]
    public abstract class SpecsForCountryService : SpecsForService<CountryService>
    {
        protected List<Country> Countries;

        protected override void Given()
        {
            base.Given();

            Countries = new List<Country>
            {
                new Country { Id = 1, Name = "United States of America", Description = "The United States of America", Abbreviation = "USA" },
                new Country { Id = 2, Name = "Canada", Description = "Canada", Abbreviation = "CAN" },
            };

            GetMockFor<ICountryRepository>()
                .Setup(x => x.AddAsync(It.IsAny<int>(), It.IsAny<Country>()))
                .Returns((int userId, Country model) => Task.FromResult(model))
                .Callback((int userId, Country model) =>
                {
                    model.Id = GetRandom.Id();
                    Countries.Add(model);
                });

            GetMockFor<ICountryRepository>()
                .Setup(x => x.DeleteAsync(It.IsAny<int>(), It.IsAny<int>()))
                .Returns((int userId, int id) => Task.FromResult(Countries.SingleOrDefault(x => x.Id == id)))
                .Callback((int userId, int id) => { Countries.RemoveAll(x => x.Id == id); });

            GetMockFor<ICountryRepository>()
                .Setup(x => x.GetAsync(It.IsAny<int>(), It.IsAny<int>()))
                .Returns((int userId, int id) => Task.FromResult(Countries.SingleOrDefault(x => x.Id == id)));

            GetMockFor<ICountryRepository>()
                .Setup(x => x.GetAsync(It.IsAny<int>(), It.IsAny<Expression<Func<Country, bool>>>(), It.IsAny<PagingOptions>()))
                .Returns((int userId, Expression<Func<Country, bool>> predicate, PagingOptions queryOptions) => Task.FromResult(Countries.AsQueryable().Where(predicate).ToList()));

            GetMockFor<ICountryRepository>()
                .Setup(x => x.SingleOrDefaultAsync(It.IsAny<int>(), It.IsAny<Expression<Func<Country, bool>>>()))
                .Returns((int userId, Expression<Func<Country, bool>> predicate) => Task.FromResult(Countries.AsQueryable().SingleOrDefault(predicate)));
        }
    }
}
