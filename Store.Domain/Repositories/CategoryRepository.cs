using System;
using System.Linq;
using System.Linq.Expressions;
using Store.Domain.Framework;
using Store.Domain.Models;

namespace Store.Domain.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
    }

    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(StoreContext storeContext) : base(storeContext)
        {
        }

        protected override IQueryable<Category> GetQuery(int userId,
            Expression<Func<Category, bool>> predicate = null)
        {
            var query = GetBaseQuery(userId, predicate);

            return query;
        }
    }
}
