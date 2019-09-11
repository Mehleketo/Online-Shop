using PnP.Data;
using PnP.Data.Interfaces;
using PnP.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PnP.Services.Shop
{
    public class TrolleyItemService : ITrolleyItemService
    {
        private ApplicationDbContext _context;

        public TrolleyItemService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(TrolleyItem _trolleyItem)
        {
            await _context.TrolleyItems.AddAsync(_trolleyItem);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(TrolleyItem _trolleyItem)
        {
            var _trolleyItemToEdit = await GetById(_trolleyItem.Id);
            if (_trolleyItemToEdit != null)
            {
                _trolleyItemToEdit.Quantity = _trolleyItem.Quantity;
                _trolleyItemToEdit.DateCreated = _trolleyItem.DateCreated;
                _trolleyItemToEdit.ProductId = _trolleyItem.ProductId;
                _trolleyItemToEdit.TrolleyId = _trolleyItem.TrolleyId;

                await _context.SaveChangesAsync();
            }
        }

        public async Task Remove(int _id)
        {
            var _productToRemove = await GetById(_id);
            if (_productToRemove != null)
            {
                _context.TrolleyItems.Remove(_productToRemove);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<TrolleyItem>> GetAll()
        {
            return await _context.TrolleyItems
                .Include(s => s.Trolley)
                .Include(s => s.Product)
                .ToListAsync();
        }

        public async Task<TrolleyItem> GetById(int _id)
        {
            return await _context.TrolleyItems
                .Include(s => s.Trolley)
                .Include(s => s.Product)
                .FirstOrDefaultAsync(s => s.Id == _id);
        }

        public async Task<IEnumerable<TrolleyItem>> GetByTrolleyIdAsync(int _trolleyId)
        {
            return await _context.TrolleyItems
                .Where(s => s.TrolleyId == _trolleyId)
                .Include(s => s.Trolley)
                .Include(s => s.Product)
                .ToListAsync();
        }
    }
}
