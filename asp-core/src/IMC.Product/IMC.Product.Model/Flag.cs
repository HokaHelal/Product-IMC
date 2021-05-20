using IMC.Product.Shared.Generic;
using System.Collections.Generic;

namespace IMC.Product.Model
{
    public class Flag : Entity<int>
    {
        public ICollection<Product> Products { get; set; }
    }
}