using PnP.Data;
using PnP.Data.Interfaces;
using PnP.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PnP.Services.Products
{
    public class ProductService : IProductService
    {
        private ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(Product _product)
        {
            await _context.Products.AddAsync(_product);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(Product _product)
        {
            var _productToEdit = await GetById(_product.Id);
            if (_productToEdit != null)
            {
                _productToEdit.Title = _product.Title;
                _productToEdit.Description = _product.Description;
                _productToEdit.Barcode = _product.Barcode;
                _productToEdit.Price = _product.Price;
                _productToEdit.ImageData = _product.ImageData;
                _productToEdit.ImageType = _product.ImageType;
                _productToEdit.Features = _product.Features;
                _productToEdit.Usage = _product.Usage;
                _productToEdit.Slug = _product.Slug;
                _productToEdit.DateCreated = _product.DateCreated;
                _productToEdit.SubCategoryId = _product.SubCategoryId;

                await _context.SaveChangesAsync();
            }
        }

        public async Task Remove(int _id)
        {
            var _productToRemove = await GetById(_id);
            if (_productToRemove != null)
            {
                _context.Products.Remove(_productToRemove);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products
                .Include(s => s.SubCategory)
                .Include(s => s.Reviews)
                .Include(s => s.Discounts)
                .ToListAsync();
        }

        public async Task<Product> GetById(int _id)
        {
            return await _context.Products
                .Include(s => s.SubCategory)
                .Include(s => s.Reviews)
                .Include(s => s.Discounts)
                .FirstOrDefaultAsync(s => s.Id == _id);
        }

        public async Task<Product> GetBySlug(string _slug)
        {
            return await _context.Products
                .Include(s => s.SubCategory)
                .Include(s => s.Reviews)
                .Include(s => s.Discounts)
                .FirstOrDefaultAsync(s => s.Slug == _slug);
        }

        public async Task<IEnumerable<Product>> GetBySubcategoryId(int _categoryId)
        {
            return await _context.Products
                .Where(s => s.SubCategoryId == _categoryId)
                .Include(s => s.SubCategory)
                .Include(s => s.Reviews)
                .Include(s => s.Discounts)
                .ToListAsync();
        }
    }
}
