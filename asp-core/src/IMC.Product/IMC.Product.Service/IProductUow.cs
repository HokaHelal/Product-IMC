using IMC.Product.Repository;
using IMC.Product.Shared.Generic;

namespace IMC.Product.Service
{
    public interface IProductUow : IGenericUnitOfWork
    {
        IProductRepository ProductRepository { get; }
    }
}
