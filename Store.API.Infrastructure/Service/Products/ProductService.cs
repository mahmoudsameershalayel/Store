using Abp;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Store.Core.APIDto.Cart;
using Store.Core.APIDto.Paging;
using Store.Core.APIDto.Products;
using Store.Core.APIViewModel.Categories;
using Store.Core.APIViewModel.Products;
using Store.Core.Constant;
using Store.Data;
using Store.Data.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.API.Infrastructure.Service.Products
{
    public class ProductService : IProductService
    {
        private readonly StoreContext _context;
        private readonly IMapper _mapper;
        public ProductService(StoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        private async Task<Product> Find(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IList<ProductViewModel>> GetAll(ApiPagingDto dto)
        {
            var products = await _context.Products.ToListAsync();
            int productSkip = (dto.CurrentPage - 1) * dto.PageSize;
            var data = products.Skip(productSkip).Take(dto.PageSize).ToList();
            var dataViewModel = _mapper.Map<List<ProductViewModel>>(data);
            return dataViewModel;
        }
       

        public async Task<ProductViewModel> GetById(int id)
        {
            var product = await Find(id);
            //to be sure the product existing
            if (product == null)
            {
                throw new Exception(MessagesKeys.NotFound);
            }
            var productViewModel = _mapper.Map<ProductViewModel>(product);
            return productViewModel;

        }
        public async Task<List<CategoryViewModel>> GetCategoryByProduct(int productId)
        {
            var categories = await _context.ProductCategories.Where(x => x.ProductId == productId).Select(x => x.Category).ToListAsync();
            var categoriesViewModel = _mapper.Map<List<CategoryViewModel>>(categories);
            return categoriesViewModel;
        }
        public async Task<CreateProductDto> Create(CreateProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            List<int> categoryIds = dto.CategoryIds;
            List<Category> categories = new List<Category>();
            foreach (int id in categoryIds)
            {
                categories.Add(await _context.Categories.FindAsync(id));
            };
            foreach (var category in categories)
            {
                await _context.ProductCategories.AddAsync(new ProductCategory()
                {
                    Product = product,
                    Category = category
                });
            }
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return dto;
        }

        public async Task<int> Delete(int id)
        {
            var product = await Find(id);
            //to be sure the product existing
            if (product == null)
            {
                throw new Exception(MessagesKeys.NotFound);
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<UpdateProductDto> Update(UpdateProductDto dto)
        {
            var product = await Find(dto.Id);
            //to be sure the product existing
            if (product == null)
            {
                throw new Exception(MessagesKeys.NotFound);
            }
            var updateProduct = _mapper.Map(dto, product);
            _context.Products.Update(updateProduct);
            await _context.SaveChangesAsync();
            return dto;

        }
        public async Task<ShoppingCart> Create(string userId) {
            var cart = new ShoppingCart(userId);
            await _context.Carts.AddAsync(cart);
            _context.SaveChanges();
            return cart;
        }
        public async Task<int> AppendProductToCart(AppendProductDto dto)
        {
            var _cart = await _context.Carts.Where(x => x.UserId == dto._UserId).FirstOrDefaultAsync();
            if (_cart == null) {
                _cart = await Create(dto._UserId);
            }
            await _context.CartProducts.AddAsync(new ShoppingCartProducts
            {
                ProductId = dto._ProductId,
                ShoppingCartId = _cart.Id,
                Qty = dto.Qty
            });
            _context.SaveChanges();
            return _cart.Id;
            /*var _productInCart = await _context.CartProducts.Where(x=> x.ProductId == dto._ProductId && x.ShoppingCartId == _cart.Id).FirstOrDefaultAsync();
            if(_productInCart == null)
            {
                await _context.CartProducts.AddAsync(new ShoppingCartProducts
                {
                    ProductId = dto._ProductId,
                    ShoppingCartId = _cart.Id,
                    Qty = dto.Qty
                });
                _context.SaveChanges();
                return _cart.Id;
            }
            _productInCart.Qty += dto.Qty;
            _context.SaveChanges();
            return _cart.Id;*/

        }
    }
}
