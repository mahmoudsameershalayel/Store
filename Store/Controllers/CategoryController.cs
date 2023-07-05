using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Store.API.Infrastructure.Service.Categories;
using Store.Core.APIDto.Categories;
using Store.Core.Constant;

using Store.Core.APIViewModel.General;
using Store.API.Resources;
using Store.Core.APIDto.Paging;

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
        public async Task<IActionResult> GetAll(int page = 1 , int pageSize = 10)
        {
            return Ok(await GetResponse(async () => new ApiResponseViewModel(await _categoryService.GetAll(new ApiPagingDto (page , pageSize)), true, MessagesKeys.success)));
        }
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await GetResponse(async () => new ApiResponseViewModel(await _categoryService.GetById(id),true ,MessagesKeys.success)));
        }
        [HttpGet]
        public async Task<IActionResult> GetProductByCategory(int categoryId)
        {
            return Ok(await GetResponse (async ()=> new ApiResponseViewModel(await _categoryService.GetProductByCategory(categoryId) , true , MessagesKeys.success)));
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([FromForm]CreateCategoryDto dto)
        {
            return Ok(await GetResponse(async () => new ApiResponseViewModel(await _categoryService.Create(dto), true, MessagesKeys.success)));
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateCategoryDto dto)
        {
            return Ok(await GetResponse(async () => new ApiResponseViewModel(await _categoryService.Update(dto), true, MessagesKeys.success)));
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await GetResponse(async () => new ApiResponseViewModel(await _categoryService.Delete(id), true, MessagesKeys.success)));
        }
    }
}
