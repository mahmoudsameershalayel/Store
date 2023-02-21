using AutoMapper;
using Store.Core.APIDto.Categories;
using Store.Core.APIDto.Products;
using Store.Core.APIViewModel.Categories;
using Store.Core.APIViewModel.Products;
using Store.Data.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.API.Infrastructure.AutoMapper
{
    public class StoreProfile : Profile
    {
        public StoreProfile()
        {
            //Products
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, ProductViewModel>().ReverseMap();
            //Categories
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, CategoryViewModel>().ReverseMap();
        }
    }
}
