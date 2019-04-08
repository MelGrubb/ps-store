using System;
using System.Linq;
using System.Linq.Expressions;
using Store.Domain.Framework;
using Store.Domain.Models;

namespace Store.Domain.Repositories
{
    public interface IStateRepository : IRepository<State>
    {
    }

    public class StateRepository : Repository<State>, IStateRepository
    {
        public StateRepository(StoreContext storeContext) : base(storeContext)
        {
        }

        protected override IQueryable<State> GetQuery(int userId, Expression<Func<State, bool>> predicate = null)
        {
            var query = GetBaseQuery(userId, predicate);

            return query;
        }
    }
}
