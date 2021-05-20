using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMC.Product.Shared.Generic
{
    public abstract class EntityService<T> : IEntityService<T> where T : BaseEntity
    {
        IGenericUnitOfWork _unitOfWork;
        IGenericRepository<T> _repository;

        public EntityService(IGenericUnitOfWork unitOfWork, IGenericRepository<T> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }


        public async virtual Task Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
        }


        public async virtual Task Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
        }

        public async virtual Task Delete(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _repository.Delete(entity);
            await _unitOfWork.CommitAsync();
        }
        public async virtual Task Delete(int entityId)
        {
            if (entityId == -1) throw new ArgumentNullException("entity");
            var entity = await _repository.GetByIdAsync(entityId);
            _repository.Delete(entity);
            await _unitOfWork.CommitAsync();
        }

        public async virtual Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
        
        public async virtual Task<T> GetByIdAsync(int Id)
        {
            return await _repository.GetByIdAsync(Id);
        }

        public async virtual Task<IEnumerable<T>> GetBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return await _repository.FindByAsync(predicate);
        }

        public async Task<int> Count(T entity)
        {
            return await _repository.CountAsync();
        }
    }
}