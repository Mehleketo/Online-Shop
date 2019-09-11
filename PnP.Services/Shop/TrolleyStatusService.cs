using PnP.Data;
using PnP.Data.Interfaces;
using PnP.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PnP.Services.Shop
{
    public class TrolleyStatusService : ITrolleyStatusService
    {
        private ApplicationDbContext _context;

        public TrolleyStatusService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(TrolleyStatus _trolleyStatus)
        {
            await _context.TrolleyStatuses.AddAsync(_trolleyStatus);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(TrolleyStatus _trolleyStatus)
        {
            var _trolleyStatusToEdit = await GetById(_trolleyStatus.Id);
            if (_trolleyStatusToEdit != null)
            {
                _trolleyStatusToEdit.Title = _trolleyStatus.Title;

                await _context.SaveChangesAsync();
            }
        }

        public async Task Remove(int _id)
        {
            var _productToRemove = await GetById(_id);
            if (_productToRemove != null)
            {
                _context.TrolleyStatuses.Remove(_productToRemove);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<TrolleyStatus>> GetAll()
        {
            return await _context.TrolleyStatuses
                .ToListAsync();
        }

        public async Task<TrolleyStatus> GetById(int _id)
        {
            return await _context.TrolleyStatuses
                .FirstOrDefaultAsync(s => s.Id == _id);
        }
    }
}
