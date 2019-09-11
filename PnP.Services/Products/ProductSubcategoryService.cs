using PnP.Data;
using PnP.Data.Interfaces;
using PnP.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PnP.Services.Products
{
    public class ProductSubcategoryService : IProductSubcategoryService
    {
        private ApplicationDbContext _context;

        public ProductSubcategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(ProductSubCategory _subcategory)
        {
            await _context.ProductSubCategories.AddAsync(_subcategory);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(ProductSubCategory _subcategory)
        {
            var _subcategoryToEdit = await GetById(_subcategory.Id);
            if (_subcategoryToEdit != null)
            {
                _subcategoryToEdit.Title = _subcategory.Title;
                _subcategoryToEdit.Description = _subcategory.Description;
                _subcategoryToEdit.ImageData = _subcategory.ImageData;
                _subcategoryToEdit.ImageType = _subcategory.ImageType;
                _subcategoryToEdit.Slug = _subcategory.Slug;
                _subcategoryToEdit.CategoryId = _subcategory.CategoryId;

                await _context.SaveChangesAsync();
            }
        }

        public async Task Remove(int _id)
        {
            var _subcategoryToRemove = await GetById(_id);
            if (_subcategoryToRemove != null)
            {
                _context.ProductSubCategories.Remove(_subcategoryToRemove);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ProductSubCategory>> GetAll()
        {
            return await _context.ProductSubCategories
                .Include(s => s.Category)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductSubCategory>> GetByCategoryId(int _categoryId)
        {
            return await _context.ProductSubCategories
                .Where(s => s.CategoryId == _categoryId)
                .Include(s => s.Category)
                .ToListAsync();
        }

        public async Task<ProductSubCategory> GetById(int _id)
        {
            return await _context.ProductSubCategories
                .Include(s => s.Category)
                .FirstOrDefaultAsync(s => s.Id == _id);
        }

        public async Task<ProductSubCategory> GetBySlug(string _slug)
        {
            return await _context.ProductSubCategories
                .Include(s => s.Category)
                .FirstOrDefaultAsync(s => s.Slug == _slug);
        }
    }
}
