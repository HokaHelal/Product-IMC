using AutoMapper;
using IMC.Product.Dto;
using IMC.Product.Model;
using IMC.Product.Repository;
using IMC.Product.Shared.Errors;
using IMC.Product.Shared.Generic;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMC.Product.Service
{
    public class ProductUow : GenericUnitOfWork, IProductUow
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public IProductRepository ProductRepository => new ProductRepository(_context);

        public ProductUow(DataContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<ProductDto>> GetAll()
        {
            var products = await ProductRepository.GetAllAsync();
            var ProductDtos = _mapper.Map<List<ProductDto>>(products);

            return ProductDtos;
        }
        public async Task<List<ProductDto>> GetBySearchAsync(string search)
        {
            var products = await ProductRepository.GetBySearchAsync(search);
            var ProductDtos = _mapper.Map<List<ProductDto>>(products);

            return ProductDtos;
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var product = await ProductRepository.GetByIdAsync(id);
            var ProductDto = _mapper.Map<ProductDto>(product);

            return ProductDto;
        }
        public async Task<int> AddAsync(ProductDto newProductDto)
        {
            var newProduct = _mapper.Map<Model.Product>(newProductDto);
            var isAdded = await ProductRepository.AddAsync(newProduct);
            if (isAdded && await CommitAsync())
                return newProduct.Id;
            else
                throw new BadRequestException("unable to add new product");
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var isDeleted = await ProductRepository.DeleteAsync(id);
            if (isDeleted && await CommitAsync())
                return isDeleted;
            else
                throw new BadRequestException("unable to delete product");
        }
        public async Task UpdateAsync(ProductDto productDto)
        {
            try
            {
                var product = _mapper.Map<Model.Product>(productDto);
                ProductRepository.Update(product);
                await CommitAsync();
            }
            catch (System.Exception ex)
            {
                throw new BadRequestException("unable to update product ex: " + ex.Message);
            }

        }


    }
}
