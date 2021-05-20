using IMC.Product.Dto;
using IMC.Product.Repository;
using IMC.Product.Shared.Generic;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMC.Product.Service
{
    public interface IProductUow : IGenericUnitOfWork
    {
        IProductRepository ProductRepository { get; }
        Task<ProductDto> GetByIdAsync(int id);
        Task<int> AddAsync(ProductDto newProductDto);
        Task<bool> DeleteAsync(int id);
        Task UpdateAsync(ProductDto productDto);
        Task<List<ProductDto>> GetAll();
        Task<List<ProductDto>> GetBySearchAsync(string search);
    }
}
