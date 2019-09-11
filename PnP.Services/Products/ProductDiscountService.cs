using PnP.Data;
using PnP.Data.Interfaces;
using PnP.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PnP.Services.Products
{
    public class ProductDiscountService : IProductDiscountService
    {
        private ApplicationDbContext _context;

        public ProductDiscountService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(ProductDiscount _discount)
        {
            await _context.ProductDiscounts.AddAsync(_discount);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(ProductDiscount _discount)
        {
            var _productToEdit = await GetById(_discount.Id);
            if (_productToEdit != null)
            {
                _productToEdit.Title = _discount.Title;
                _productToEdit.Percentage = _discount.Percentage;
                _productToEdit.StartDate = _discount.StartDate;
                _productToEdit.EndDate = _discount.EndDate;
                _productToEdit.DateCreated = _discount.DateCreated;
                _productToEdit.ProductId = _discount.ProductId;

                await _context.SaveChangesAsync();
            }
        }

        public async Task Remove(int _id)
        {
            var _discountToRemove = await GetById(_id);
            if (_discountToRemove != null)
            {
                _context.ProductDiscounts.Remove(_discountToRemove);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ProductDiscount>> GetAll()
        {
            return await _context.ProductDiscounts
                .Include(d => d.Product)
                .OrderBy(d => d.Title)
                .ThenBy(d => d.EndDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductDiscount>> GetByDate(DateTime _date)
        {
            return await _context.ProductDiscounts
                .Where(d => d.EndDate >= _date)
                .Include(d => d.Product)
                .OrderBy(d => d.Title)
                .ThenBy(d => d.EndDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductDiscount>> GetByProductId(int _productId)
        {
            return await _context.ProductDiscounts
                .Where(d => d.ProductId == _productId)
                .Include(s => s.Product)
                .OrderBy(d => d.Title)
                .ThenBy(d => d.EndDate)
                .ToListAsync();
        }

        public async Task<ProductDiscount> GetById(int _id)
        {
            return await _context.ProductDiscounts
                .Include(d => d.Product)
                .OrderBy(d => d.Title)
                .ThenBy(d => d.EndDate)
                .FirstOrDefaultAsync(d => d.Id == _id);
        }
    }
}
