using WallBid.Infrastructure.Commons.Abstracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace WallBid.Infrastructure.Commons.Concrates
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext _dbContext;
        private readonly DbSet<T> _table;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _table = dbContext.Set<T>();
        }

        public T Add(T model)
        {
            _table.Add(model);
            return model;
        }

        public T Edit(T model)
        {
            _dbContext.Entry(model).State = EntityState.Modified;
            return model;
        }

        public T Get(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _table.AsQueryable();

            if (predicate != null)
                query = query.Where(predicate);

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return query.FirstOrDefault();
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null, bool tracking = true,
            params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _table.AsQueryable();

            if (!tracking)
                query = query.AsNoTracking();

            if (predicate is not null)
                query = query.Where(predicate);

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return query;
        }

        public void Remove(T model)
        {
            _table.Remove(model);
        }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }
    }
}
