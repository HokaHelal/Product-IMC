using IMC.Product.Shared.Generic;
using System;
using System.Collections;
using System.Collections.Generic;

namespace IMC.Product.Model
{
    public class Product : Entity<int>
    {
        public string VendorUID { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string ImageUrl { get; set; }
        public int NumberOfViews { get; set; }
        public ICollection<Flag> Flags { get; set; }
    }
}
