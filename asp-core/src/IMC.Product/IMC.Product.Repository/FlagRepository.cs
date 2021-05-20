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
    public class FlagRepository : GenericRepository<Flag>, IFlagRepository
    {
        private readonly DataContext _context;
        public FlagRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
