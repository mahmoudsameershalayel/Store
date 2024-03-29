﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Store.Core.APIDto.Categories;
using Store.Core.APIDto.Paging;
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

namespace Store.API.Infrastructure.Service.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly StoreContext _context;
        private readonly IMapper _mapper;
        public CategoryService(StoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        private async Task<Category> Find(int id) => await _context.Categories.SingleOrDefaultAsync(x => x.Id == id);
        public async Task<IList<CategoryViewModel>> GetAll(ApiPagingDto dto)
        {
            var categories = await _context.Categories.ToListAsync();
            int categorySkip = (dto.CurrentPage - 1) * dto.PageSize;
            var data =  categories.Skip(categorySkip).Take(dto.PageSize).ToList();
            var dataViewModel = _mapper.Map<List<CategoryViewModel>>(data);
            return dataViewModel;
        }
     
        public async Task<CategoryViewModel> GetById(int id)
        {
            var category = await Find(id);
            //to be sure the category existing
            if (category == null)
                throw new Exception(MessagesKeys.NotFound);
            return _mapper.Map<CategoryViewModel>(category);
        }
        public async Task<List<ProductViewModel>> GetProductByCategory(int categoryId)
        {
            var products = await _context.ProductCategories.Where(x => x.CategoryId == categoryId).Select(x => x.Product).ToListAsync();
            var productsViewModel = _mapper.Map<List<ProductViewModel>>(products);
            return productsViewModel;
        }

        public async Task<CreateCategoryDto> Create(CreateCategoryDto dto)
        {
            var category = _mapper.Map<Category>(dto);
            await _context.AddAsync(category);
            await _context.SaveChangesAsync();
            return dto;
        }

        public async Task<int> Delete(int id)
        {
            var category = await Find(id);
            //to be sure the category existing
            if (category == null)
                throw new Exception(MessagesKeys.NotFound);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return category.Id;
        }

        

        public async Task<UpdateCategoryDto> Update(UpdateCategoryDto dto)
        {
            var category = await Find(dto.Id);
            //to be sure the category existing
            if (category == null)
                throw new Exception(MessagesKeys.NotFound);

            var UpdateCategory = _mapper.Map(dto, category);
            _context.Categories.Update(UpdateCategory);
            await _context.SaveChangesAsync();
            return dto;
        }

       
    }
}
