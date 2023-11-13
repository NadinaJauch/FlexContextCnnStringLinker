using System;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace DataAccessInterface.Abstractions.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        T Add(T entity);
        void Update(T entity);
        Task<T> GetByIdAsync(int id);
        T GetByCondition(Expression<Func<T, bool>> predicate);
        Task<T> GetByConditionAsync(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetMany(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> predicate);
        Task<bool> AnyAsyncByCondition(Expression<Func<T, bool>> predicate);
        Task<TField> GetFieldByConditionAsync<TField>(Expression<Func<T, bool>> predicate, Expression<Func<T, TField>> fieldSelector);
        Task<IEnumerable<TField>> GetFieldByConditionManyAsync<TField>(Expression<Func<T, bool>> predicate, Expression<Func<T, TField>> fieldSelector);
    }
}
