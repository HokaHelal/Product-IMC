using System;
using System.Collections;
using System.Collections.Generic;

namespace IMC.Product.Model
{
    public class ProductDto
    {
        public string vendorUID { get; set; }
        public string description { get; set; }
        public float price { get; set; }
        public string imageUrl { get; set; }
        public int numberOfViews { get; set; }
        public ICollection<string> flags { get; set; }
    }
}
