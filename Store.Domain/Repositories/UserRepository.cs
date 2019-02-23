using System;
using System.Linq;
using System.Linq.Expressions;
using Store.Domain.Framework;
using Store.Domain.Models;

namespace Store.Domain.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
    }

    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(StoreContext storeContext) : base(storeContext)
        {
        }

        protected override IQueryable<User> GetQuery(int currentUserId, Expression<Func<User, bool>> predicate = null)
        {
            var query = GetBaseQuery(currentUserId, predicate);

            return query;
        }
    }
}
