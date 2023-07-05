using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.APIDto.Products
{
    public class AppendProductDto
    {
        public int _ProductId { get; set; }
        //if cart not exist create new cart with user id
        public string _UserId { get; set; }
        public int Qty { get; set; }
    }
}
