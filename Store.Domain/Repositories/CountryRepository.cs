using System;
using System.Linq;
using System.Linq.Expressions;
using Store.Domain.Framework;
using Store.Domain.Models;

namespace Store.Domain.Repositories
{
    public interface ICountryRepository : IRepository<Country>
    {
    }

    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        public CountryRepository(StoreContext storeContext) : base(storeContext)
        {
        }

        protected override IQueryable<Country> GetQuery(int userId, Expression<Func<Country, bool>> predicate = null)
        {
            var query = GetBaseQuery(userId, predicate);

            return query;
        }
    }
}
