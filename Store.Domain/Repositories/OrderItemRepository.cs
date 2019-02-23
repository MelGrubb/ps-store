using System;
using System.Linq;
using System.Linq.Expressions;
using Store.Domain.Framework;
using Store.Domain.Models;

namespace Store.Domain.Repositories
{
    public interface IOrderItemRepository : IRepository<OrderItem>
    {
    }

    public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(StoreContext storeContext) : base(storeContext)
        {
        }

        protected override IQueryable<OrderItem> GetQuery(int currentUserId,
            Expression<Func<OrderItem, bool>> predicate = null)
        {
            var query = GetBaseQuery(currentUserId, predicate);

            return query;
        }
    }
}
