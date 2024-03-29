﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.APIViewModel.Products
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double PriceAfterDiscount { get; set; }
        public double Weight { get; set; }
        public int Quantity { get; set; }
    }
}
