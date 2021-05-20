using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMC.Product.Shared.Generic;
using Microsoft.EntityFrameworkCore;

namespace IMC.Product.Shared.Generic
{
    public abstract class GenericRepository<T> : IGenericRepository<T>
          where T : BaseEntity
    {
        protected DbContext _entities;
        protected readonly DbSet<T> _dbset;

        public GenericRepository(DbContext context)
        {
            _entities = context;
            _dbset = context.Set<T>();
        }

        public async virtual Task<T> GetByIdAsync(int Id)
        {
            return await _entities.Set<T>().FindAsync(Id);
        }
        public async virtual Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbset.AsNoTracking().ToListAsync<T>();
        }
        public async virtual Task<int> CountAsync()
        {
            return await _dbset.AsNoTracking().CountAsync();
        }
        public async Task<IEnumerable<T>> FindByAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> query =  await _dbset.AsNoTracking().Where(predicate).ToListAsync();

            return query;
        }
        public async Task<T> FindFirstAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            T query =  await _dbset.AsNoTracking().FirstOrDefaultAsync(predicate);
            return query;
        }
        public async Task<bool> AddAsync(T entity)
        {
            try 
            {                                
                await _dbset.AddAsync(entity);
                return true;
            }
            catch (Exception)  
            {  
                return false;
            }
        }
        public async Task<bool> AddAsync(IEnumerable<T> entity)
        {
            try
            {
                foreach (var item in entity)
                {
                    await AddAsync(item);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async virtual Task<bool> DeleteAsync(int Id)
        {
            T deletedEntry = await GetByIdAsync(Id);
            var isDeleted = Delete(deletedEntry);

            if(isDeleted)
                return true;
            else
                return false;
        }
        public virtual bool Delete(T entity)
        {
            try 
            {                                
                 _dbset.Remove(entity);
                return true;
            }
            catch (Exception)  
            {  
                return false;
            }  
        }
        public virtual void Update(T entity)
        {
            _entities.Entry(entity).State = EntityState.Modified;
        }     
    }
}