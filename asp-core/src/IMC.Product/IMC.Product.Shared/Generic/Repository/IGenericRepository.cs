using IMC.Product.Shared.Generic;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IMC.Product.Shared.Generic
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindByAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetByIdAsync(int Id);
        Task<T> FindFirstAsync(Expression<Func<T, bool>> predicate);
        Task<int> CountAsync();
        Task<bool> AddAsync(T entity);
        Task<bool> AddAsync(IEnumerable<T> entity);
        bool Delete(T entity);
        Task<bool> DeleteAsync(int Id);
        void Update(T entity);
    }
}