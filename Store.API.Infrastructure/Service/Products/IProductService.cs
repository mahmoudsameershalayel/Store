using Store.Core.APIDto.Products;
using Store.Core.APIViewModel.Categories;
using Store.Core.APIViewModel.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.API.Infrastructure.Service.Products
{
    public interface IProductService
    {
        public Task<IList<ProductViewModel>> GetAll();
        public Task<ProductViewModel> GetById(int id);
        public Task<List<CategoryViewModel>> GetCategoryByProduct(int productId);
        public Task<CreateProductDto> Create(CreateProductDto dto);
        public Task<int> Delete(int id);
        public Task<UpdateProductDto> Update(UpdateProductDto dto);
    }
}
