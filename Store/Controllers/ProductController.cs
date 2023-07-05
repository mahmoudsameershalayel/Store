using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.API.Infrastructure.Service.Products;
using Store.Core.APIDto.Paging;
using Store.Core.APIDto.Products;
using Store.Core.APIViewModel.General;
using Store.Core.Constant;

namespace Store.API.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(int page = 0, int pageSize = 10)
        {
            return Ok(await GetResponse(async () => new ApiResponseViewModel(await _productService.GetAll(new ApiPagingDto(page, pageSize)), true, MessagesKeys.success)));
        }
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await GetResponse(async () => new ApiResponseViewModel(await _productService.GetById(id), true, MessagesKeys.success)));
        }
        [HttpGet]
        public async Task<IActionResult> getCategoryByProduct(int productId)
        {

            return Ok(await GetResponse(async () => new ApiResponseViewModel(await _productService.GetCategoryByProduct(productId), true, MessagesKeys.success)));
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDto dto)
        {

            return Ok(await GetResponse(async () => new ApiResponseViewModel(await _productService.Create(dto), true, MessagesKeys.success)));
        }

        [HttpPost]
        public async Task<IActionResult> AppendProductToCart([FromForm]AppendProductDto dto) {
            return Ok(await GetResponse(async () => new ApiResponseViewModel(await _productService.AppendProductToCart(dto), true, MessagesKeys.success)));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductDto dto)
        {
            return Ok(await GetResponse(async () => new ApiResponseViewModel(await _productService.Update(dto), true, MessagesKeys.success)));
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await GetResponse(async () => new ApiResponseViewModel(await _productService.Delete(id), true, MessagesKeys.success)));
        }
    }
}
