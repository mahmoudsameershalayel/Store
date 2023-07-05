using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.API.Infrastructure.Service.Cart;
using Store.Core.APIDto.Cart;
using Store.Core.APIDto.Paging;
using Store.Core.APIDto.Products;
using Store.Core.APIViewModel.General;
using Store.Core.Constant;
using Store.Data;
using Store.Data.DBEntities;
using System.Drawing.Printing;

namespace Store.API.Controllers
{
    public class CartController : BaseController
    {
        private readonly ICartServices _cartServices;
        public CartController(ICartServices cartServices)
        {
            _cartServices = cartServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetCart(int id) {
            return Ok(await GetResponse(async () => new ApiResponseViewModel(await _cartServices.GetCart(id), true, MessagesKeys.success)));
        }
    
        [HttpGet]
        public async Task<IActionResult> GetCartDetails(int id) {
            return Ok(await GetResponse(async () => new ApiResponseViewModel(await _cartServices.GetCartDetails(id), true, MessagesKeys.success)));
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveProductFromCart([FromForm]RemoveProductDto dto) {
            return Ok(await GetResponse(async () => new ApiResponseViewModel(await _cartServices.RemoveProductFromCart(dto), true, MessagesKeys.success)));
        }
    }
}
