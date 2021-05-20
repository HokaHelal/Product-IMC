using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace IMC.Product.Shared.Generic
{
    /// <summary>
    /// The Entity Framework implementation of IUnitOfWork
    /// </summary>
    public class GenericUnitOfWork : IGenericUnitOfWork
    {
        /// <summary>
        /// The DbContext
        /// </summary>
        private DbContext _dbContext;
        /// <summary>
        /// Initializes a new instance of the UnitOfWork class.
        /// </summary>
        /// <param name="context">The object context</param>
        public GenericUnitOfWork(DbContext context)
        {
            _dbContext = context;
        }
        public bool HasChanges()
        {
            return _dbContext.ChangeTracker.HasChanges();
        }

        /// <summary>
        /// Saves all pending changes
        /// </summary>
        /// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
        public async Task<bool> CommitAsync()
        {
            // Save changes with the default options
            return await _dbContext.SaveChangesAsync() > 0 ? true : false;
        }

        /// <summary>
        /// Disposes the current object
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes all external resources.
        /// </summary>
        /// <param name="disposing">The dispose indicator.</param>
        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_dbContext != null)
                {
                    _dbContext.Dispose();
                    _dbContext = null;
                }
            }
        }
    }
}