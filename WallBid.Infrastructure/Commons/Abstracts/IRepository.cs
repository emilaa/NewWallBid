using System.Linq.Expressions;

namespace WallBid.Infrastructure.Commons.Abstracts
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll(Expression<Func<T, bool>>? predicate = null, bool tracking = true, params Expression<Func<T, object>>[] includes);
        T Get(Expression<Func<T, bool>>? predicate = null, params Expression<Func<T, object>>[] includes);
        T Add(T model);
        T Edit(T model);
        void Remove(T model);
        int Save();
    }
}
