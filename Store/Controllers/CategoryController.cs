using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.API.Infrastructure.Service.Categories;
using Store.Core.APIDto.Categories;

namespace Store.API.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _categoryService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return Ok(await _categoryService.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("~/getProductByCategory")]
        public async Task<IActionResult> GetProductByCategory(int categoryId)
        {
            return Ok(await _categoryService.GetProductByCategory(categoryId));
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto dto)
        {
            return Ok(await _categoryService.Create(dto));
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateCategoryDto dto)
        {
            try
            {
                return Ok(await _categoryService.Update(dto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return Ok("The Category with id : " + await _categoryService.Delete(id) + " has deleted succefully");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
