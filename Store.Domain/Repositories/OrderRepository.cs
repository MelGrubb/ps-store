using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Store.Domain.Framework;
using Store.Domain.Models;

namespace Store.Domain.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
    }

    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(StoreContext storeContext) : base(storeContext)
        {
        }

        protected override IQueryable<Order> GetQuery(int userId, Expression<Func<Order, bool>> predicate = null)
        {
            var query = GetBaseQuery(userId, predicate)
                .Include(x => x.OrderItems)
                .ThenInclude(x => x.Product)
                .ThenInclude(x => x.Category)
                .Include(x => x.OrderStatus);

            return query;
        }
    }
}
