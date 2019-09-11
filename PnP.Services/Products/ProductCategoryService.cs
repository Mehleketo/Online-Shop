using PnP.Data;
using PnP.Data.Interfaces;
using PnP.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PnP.Services.Products
{
    public class ProductCategoryService : IProductCategoryService
    {
        private ApplicationDbContext _context;

        public ProductCategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(ProductCategory _category)
        {
            await _context.ProductCategories.AddAsync(_category);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(ProductCategory _category)
        {
            var _productToEdit = await GetById(_category.Id);
            if (_productToEdit != null)
            {
                _productToEdit.Title = _category.Title;
                _productToEdit.Description = _category.Description;
                _productToEdit.ImageData = _category.ImageData;
                _productToEdit.ImageType = _category.ImageType;
                _productToEdit.Slug = _category.Slug;

                await _context.SaveChangesAsync();
            }
        }

        public async Task Remove(int _id)
        {
            var _categoryToRemove = await GetById(_id);
            if (_categoryToRemove != null)
            {
                _context.ProductCategories.Remove(_categoryToRemove);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ProductCategory>> GetAll()
        {
            return await _context.ProductCategories
                .Include(c => c.ProductSubCategories)
                .ToListAsync();
        }

        public async Task<ProductCategory> GetById(int _id)
        {
            return await _context.ProductCategories
                 .Include(c => c.ProductSubCategories)
                 .FirstOrDefaultAsync(s => s.Id == _id);
        }

        public async Task<ProductCategory> GetBySlug(string _slug)
        {
            return await _context.ProductCategories
                .Include(c => c.ProductSubCategories)
                .FirstOrDefaultAsync(s => s.Slug == _slug);
        }
    }
}
