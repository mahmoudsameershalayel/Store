using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Store.Core.APIDto.Cart;
using Store.Core.APIDto.Products;
using Store.Core.APIViewModel.Cart;
using Store.Core.APIViewModel.Products;
using Store.Data;
using Store.Data.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.API.Infrastructure.Service.Cart
{
    public class CartServices : ICartServices
    {
        private readonly IMapper _mapper;
        private readonly StoreContext _context;
        public CartServices(IMapper mapper, StoreContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<ShoppingCart> GetCart(int id)
        {
            var _cart = await _context.Carts.FirstAsync(x => x.Id == id);
            return _cart;

        }

        public async Task<ShoppingCart> GetCartDetails(int id)
        {
            var _cart = await _context.Carts.Where(x => x.Id == id)
                .Include(x => x.CartProducts)
                .ThenInclude(x => x._Product)
                .FirstOrDefaultAsync();
            return _cart;
        }
        public async Task<int> RemoveProductFromCart(RemoveProductDto dto)
        {
            var product = await _context.CartProducts.FirstAsync(x => x.ProductId == dto._ProductId && x.ShoppingCartId == dto._CartId);
            if (product != null) {
                _context.CartProducts.Remove(product);
                return _context.SaveChanges();
            }
            return 0;
        }
        public async Task<int> UpdateQty(AppendProductDto dto)
        {
            /*var product = await _context.CartProducts.FirstAsync(x => x.ProductId == dto._ProductId && x.ShoppingCartId == dto._CartId);
            if (product != null)
            {
                product.Qty = dto.Qty;
                return _context.SaveChanges();
            }*/
            return 0;
        }
    }
}
