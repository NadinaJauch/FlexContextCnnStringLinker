using System;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using DataAccessInterface.Abstractions.Context;
using DataAccessInterface.Abstractions.Repository;

namespace DataAccessInterface.Infrastructure.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly DbSet<T> _dbSet;
        public BaseRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _dbSet = _unitOfWork.Context.Set<T>();
        }
        public T Add(T entity)
        {
            _dbSet.Add(entity);
            return entity;
        }
        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        public T GetByCondition(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.SingleOrDefault(predicate);
        }
        public async Task<T> GetByConditionAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.SingleOrDefaultAsync(predicate);
        }
        public IEnumerable<T> GetMany(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }
        public async Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }
        public async Task<bool> AnyAsyncByCondition(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }
        public async Task<TField> GetFieldByConditionAsync<TField>(Expression<Func<T, bool>> predicate, Expression<Func<T, TField>> fieldSelector)
        {
            return await _dbSet.Where(predicate).Select(fieldSelector).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<TField>> GetFieldByConditionManyAsync<TField>(Expression<Func<T, bool>> predicate, Expression<Func<T, TField>> fieldSelector)
        {
            return await _dbSet.Where(predicate).Select(fieldSelector).ToListAsync();
        }
    }
}

