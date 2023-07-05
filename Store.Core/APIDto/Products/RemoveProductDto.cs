using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.APIDto.Products
{
    public class RemoveProductDto
    {
        public int _ProductId { get; set; }
        public int _CartId { get; set; }
    }
}
