using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.API.Infrastructure.Service.Products;
using Store.Core.APIDto.Products;

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
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _productService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return Ok(await _productService.GetById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("~/getCategoryByProduct")]
        public async Task<IActionResult> getCategoryByProduct(int productId)
        {
            return Ok(await _productService.GetCategoryByProduct(productId));
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDto dto)
        {
            return Ok(await _productService.Create(dto));
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductDto dto)
        {
            try
            {
                return Ok(await _productService.Update(dto));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return Ok("The product with id : " + await _productService.Delete(id) + " has deleted successfully");

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
