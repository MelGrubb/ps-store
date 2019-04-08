using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
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

        protected override IQueryable<User> GetQuery(int userId, Expression<Func<User, bool>> predicate = null)
        {
            var query = GetBaseQuery(userId, predicate)
                .Include(x => x.Address);

            return query;
        }
    }
}
