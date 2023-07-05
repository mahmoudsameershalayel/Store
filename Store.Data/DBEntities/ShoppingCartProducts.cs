using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.DBEntities
{
    public class ShoppingCartProducts
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product _Product { get; set; }
        public int ShoppingCartId { get; set; }
        public ShoppingCart _ShoppingCart { get; set; }
        public int Qty { get; set; }
    }
}
