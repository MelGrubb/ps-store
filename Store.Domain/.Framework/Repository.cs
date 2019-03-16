using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.Common.Contracts;
using Store.Domain.Models;

namespace Store.Domain.Framework
{
    public interface IRepository
    {
        StoreContext StoreContext { get; }
    }

    public interface IRepository<T> : IRepository where T : IModel
    {
        Task<T> AddAsync(int userId, T model);

        Task AddRangeAsync(int userId, IEnumerable<T> models);

        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate = null);

        Task<T> DeleteAsync(int userId, int id);

        Task DeleteAsync(int userId, T model);

        Task<T> GetAsync(int userId, int id);

        Task<List<T>> GetAsync(int userId, Expression<Func<T, bool>> predicate = null, PagingOptions options = null);

        Task SaveChangesAsync(int userId);

        Task<T> SingleOrDefaultAsync(int userId, Expression<Func<T, bool>> predicate = null);
    }

    public abstract class Repository
    {
        protected Repository(StoreContext storeContext)
        {
            StoreContext = storeContext;
        }

        public StoreContext StoreContext { get; }
    }

    public abstract class Repository<T> : Repository, IRepository<T> where T : Model
    {
        private readonly bool _isEntity;
        private readonly bool _isSoftDeleteable;

        protected Repository(StoreContext storeContext) : base(storeContext)
        {
            _isEntity = typeof(IEntity).IsAssignableFrom(typeof(T));
            _isSoftDeleteable = typeof(ISoftDeleteable).IsAssignableFrom(typeof(T));
        }

        public virtual async Task<T> AddAsync(int userId, T model)
        {
            StoreContext.Set<T>().Add(model);
            await SaveChangesAsync(userId);

            // Reload object to retrieve children, includes, etc.
            var newModel = await GetAsync(userId, model.Id);

            return newModel;
        }

        public virtual async Task AddRangeAsync(int userId, IEnumerable<T> models)
        {
            if (_isEntity)
            {
                var utcNow = DateTime.UtcNow;
                foreach (var model in models)
                {
                    ((IEntity)model).CreatedById = userId;
                    ((IEntity)model).CreatedUtc = utcNow;
                }
            }

            await StoreContext.Set<T>().AddRangeAsync(models);
            await StoreContext.SaveChangesAsync();
        }

        public virtual Task<bool> AnyAsync(Expression<Func<T, bool>> predicate = null)
        {
            IQueryable<T> query = StoreContext.Set<T>();

            if (_isSoftDeleteable)
            {
                query = query.Where(x => !((ISoftDeleteable)x).DeletedUtc.HasValue);
            }

            var result = query.AnyAsync(predicate);

            return result;
        }

        public virtual async Task DeleteAsync(int userId, T model)
        {
            if (_isSoftDeleteable)
            {
                ((ISoftDeleteable)model).DeletedById = userId;
                ((ISoftDeleteable)model).DeletedUtc = DateTime.UtcNow;
            }
            else
            {
                StoreContext.Set<T>().Remove(model);
            }

            await SaveChangesAsync(userId);
        }

        public async Task<T> DeleteAsync(int userId, int id)
        {
            var model = await GetAsync(userId, id);
            await DeleteAsync(userId, model);

            return model;
        }

        public virtual Task<T> GetAsync(int userId, int id)
        {
            var results = GetQuery(userId).SingleOrDefaultAsync(x => x.Id.Equals(id));

            return results;
        }

        public async Task<List<T>> GetAsync(int userId, Expression<Func<T, bool>> predicate = null, PagingOptions pagingOptions = null)
        {
            var query = GetQuery(userId, predicate);

            if (pagingOptions != null)
            {
                query = query.Skip(pagingOptions.Skip).Take(pagingOptions.Take);
            }

            var results = await query.ToListAsync();

            return results;
        }

        public virtual Task SaveChangesAsync(int userId)
        {
            var result = StoreContext.SaveChangesAsync(userId);

            return result;
        }

        public virtual async Task<T> SingleOrDefaultAsync(int userId, Expression<Func<T, bool>> predicate = null)
        {
            var result = await GetQuery(userId, predicate).SingleOrDefaultAsync();

            return result;
        }

        public virtual Task<int> CountAsync(Expression<Func<T, bool>> predicate = null)
        {
            IQueryable<T> query = StoreContext.Set<T>();

            if (typeof(T) is ISoftDeleteable)
            {
                query = query.Where(x => !((ISoftDeleteable)x).DeletedUtc.HasValue);
            }

            var result = predicate == null
                ? query.CountAsync()
                : query.CountAsync(predicate);

            return result;
        }

        protected virtual IQueryable<T> GetBaseQuery(int userId, Expression<Func<T, bool>> predicate = null)
        {
            IQueryable<T> query = StoreContext.Set<T>();

            if (_isSoftDeleteable)
            {
                query = query.Where(x => !((ISoftDeleteable)x).DeletedUtc.HasValue);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return query;
        }

        protected abstract IQueryable<T> GetQuery(int userId, Expression<Func<T, bool>> predicate = null);
    }
}
