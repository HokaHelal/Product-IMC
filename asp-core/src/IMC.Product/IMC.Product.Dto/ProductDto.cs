using System;
using System.Collections;
using System.Collections.Generic;

namespace IMC.Product.Dto
{
    public class ProductDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string vendorUID { get; set; }
        public string description { get; set; }
        public float price { get; set; }
        public string imageUrl { get; set; }
        public int numberOfViews { get; set; }
        public ICollection<FlagDto> flags { get; set; }
    }
}
