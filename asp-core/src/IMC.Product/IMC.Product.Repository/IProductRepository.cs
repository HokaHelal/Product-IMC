using IMC.Product.Shared.Generic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IMC.Product.Repository
{
    public interface IProductRepository : IGenericRepository<Model.Product>
    {
        Task<IEnumerable<Model.Product>> GetBySearchAsync(string search);
    }
}
