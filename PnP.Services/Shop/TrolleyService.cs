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
    public class TrolleyService : ITrolleyService
    {
        private ApplicationDbContext _context;

        public TrolleyService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(Trolley _trolley)
        {
            await _context.Trolleys.AddAsync(_trolley);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(Trolley _trolley)
        {
            var _productToEdit = await GetById(_trolley.Id);
            if (_productToEdit != null)
            {
                _productToEdit.DateCreated = _trolley.DateCreated;
                _productToEdit.StatusId = _trolley.StatusId;
                _productToEdit.UserId = _trolley.UserId;

                await _context.SaveChangesAsync();
            }
        }

        public async Task Remove(int _id)
        {
            var _trolleyToRemove = await GetById(_id);
            if (_trolleyToRemove != null)
            {
                _context.Trolleys.Remove(_trolleyToRemove);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Trolley>> GetAll()
        {
            return await _context.Trolleys
                .Include(s => s.User)
                .Include(s => s.TrolleyItems)
                .ToListAsync();
        }

        public async Task<Trolley> GetById(int _id)
        {
            return await _context.Trolleys
                .Include(s => s.User)
                .Include(s => s.TrolleyItems)
                .FirstOrDefaultAsync(s => s.Id == _id);
        }

        public async Task<IEnumerable<Trolley>> GetByUserIdAsync(string _userId)
        {
            return await _context.Trolleys
                .Where(s => s.UserId == _userId)
                .Include(s => s.User)
                .Include(s => s.TrolleyItems)
                .ToListAsync();
        }

        public async Task<Trolley> GetCurrent(string _userId)
        {
            return await _context.Trolleys
                .Include(s => s.User)
                .Include(s => s.TrolleyItems)
                .OrderBy(s => s.DateCreated)
                .FirstOrDefaultAsync();
        }
    }
}
