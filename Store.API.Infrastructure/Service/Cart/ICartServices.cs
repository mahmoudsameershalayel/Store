using Store.Core.APIDto.Cart;
using Store.Core.APIDto.Products;
using Store.Core.APIViewModel.Cart;
using Store.Core.APIViewModel.Products;
using Store.Data.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.API.Infrastructure.Service.Cart
{
    public interface ICartServices
    {
        Task<ShoppingCart> GetCart(int id);
        Task<ShoppingCart> GetCartDetails(int id);
        public Task<int> RemoveProductFromCart(RemoveProductDto dto);
        public Task<int> UpdateQty(AppendProductDto dto);


    }
}
