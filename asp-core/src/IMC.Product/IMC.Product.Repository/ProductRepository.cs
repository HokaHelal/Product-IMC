using IMC.Product.Model;
using IMC.Product.Shared.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMC.Product.Repository
{
    public class ProductRepository : GenericRepository<Model.Product>, IProductRepository
    {
        private readonly DataContext _context;
        public ProductRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Model.Product>> GetAllAsync()
        {
            return await _context.Products.Include(f => f.Flags).AsNoTracking().ToListAsync();
        }
        public override async Task<Model.Product> GetByIdAsync(int id)
        {
            return await _context.Products.Include(f => f.Flags)
                .AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<IEnumerable<Model.Product>> GetBySearchAsync(string search)
        {
            return await _context.Products.Include(f => f.Flags)
                .AsNoTracking().Where(x => x.Name.ToLower().Contains(search.ToLower()) 
                || x.Name.ToLower().Contains(search.ToLower())).ToListAsync();
        }

    }
}
