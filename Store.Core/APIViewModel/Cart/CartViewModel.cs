using Store.Core.APIViewModel.Products;
using Store.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.APIViewModel.Cart
{
    public class CartViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public CartStatus Status { get; set; }
        public string? UserId { get; set; }
        public List<ProductViewModel> Products { get; set; } = new List<ProductViewModel>();

    }
}
