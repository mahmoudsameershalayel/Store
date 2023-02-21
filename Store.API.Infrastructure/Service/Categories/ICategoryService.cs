using Store.Core.APIDto.Categories;
using Store.Core.APIViewModel.Categories;
using Store.Core.APIViewModel.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.API.Infrastructure.Service.Categories
{
    public interface ICategoryService
    {
        public Task<IList<CategoryViewModel>> GetAll();
        public Task<CategoryViewModel> GetById(int id);
        public Task<List<ProductViewModel>> GetProductByCategory(int categoryId);
        public Task<CreateCategoryDto> Create(CreateCategoryDto dto);
        public Task<int> Delete(int id);
        public Task<UpdateCategoryDto> Update(UpdateCategoryDto dto);
    }
}
