using AutoMapper;
using Store.Core.APIDto.Cart;
using Store.Core.APIDto.Categories;
using Store.Core.APIDto.Products;
using Store.Core.APIDto.User;
using Store.Core.APIViewModel.Cart;
using Store.Core.APIViewModel.Categories;
using Store.Core.APIViewModel.Products;
using Store.Core.Constant;
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
            CreateMap<Product, ProductViewModel>().ForMember(x => x.Name, x => x.MapFrom(x => Thread.CurrentThread.CurrentUICulture.Name.Equals(Languages.English) ? x.NameEN : x.NameAR)).ForMember(x => x.Description, x => x.MapFrom(x => Thread.CurrentThread.CurrentUICulture.Name.Equals(Languages.English) ? x.DescriptionEN : x.DescriptionAR)).ReverseMap();
            //Categories
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, CategoryViewModel>().ForMember(x => x.Name, x => x.MapFrom(x => Thread.CurrentThread.CurrentUICulture.Name.Equals(Languages.English) ? x.NameEN : x.NameAR)).ReverseMap();

            //ShoppingCart
            CreateMap<ShoppingCart,CreateCartDto>().ReverseMap();
            CreateMap<ShoppingCart,CartViewModel>().ReverseMap();

            //Application User
            CreateMap<ApplicationUser, CreateUserDto>().ReverseMap();
        }
    }
}
