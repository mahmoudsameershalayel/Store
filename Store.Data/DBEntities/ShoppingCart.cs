using Store.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.DBEntities
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public CartStatus Status { get; set; }
        public string UserId { get; set; } = string.Empty;
        public ApplicationUser User { get; set; }
        public List<ShoppingCartProducts> CartProducts { get; set; }
        public ShoppingCart()
        {
            Status = CartStatus.New;
            CreatedDate = DateTime.Now;
        }
        public ShoppingCart(string userId)
        {
            Status = CartStatus.New;
            CreatedDate = DateTime.Now;
            UserId = userId;
        }


    }
}
