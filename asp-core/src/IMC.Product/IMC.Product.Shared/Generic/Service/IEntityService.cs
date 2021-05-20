using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMC.Product.Shared.Generic
{
    public interface IEntityService<T> : IService
    where T : BaseEntity
   {
       Task Create(T entity);
       Task Delete(T entity);
       Task Delete(int entityId);
       Task<IEnumerable<T>> GetAllAsync();      
       Task<T> GetByIdAsync(int Id);      
       Task<IEnumerable<T>> GetBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate);
       Task Update(T entity);
       Task<int> Count(T entity);
   }
}