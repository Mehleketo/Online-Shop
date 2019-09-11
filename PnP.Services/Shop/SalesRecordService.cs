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
    public class SalesRecordService : ISalesRecordService
    {
        private ApplicationDbContext _context;

        public SalesRecordService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(SalesRecord _salesRecord)
        {
            await _context.SalesRecords.AddAsync(_salesRecord);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(SalesRecord _salesRecord)
        {
            var _salesRecordToEdit = await GetById(_salesRecord.Id);
            if (_salesRecordToEdit != null)
            {
                _salesRecordToEdit.Cost = _salesRecord.Cost;
                _salesRecordToEdit.DateCreated = _salesRecord.DateCreated;
                _salesRecordToEdit.DeliveryId = _salesRecord.DeliveryId;
                _salesRecordToEdit.UserId = _salesRecord.UserId;

                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveAsync(int _id)
        {
            var _salesRecordToRemove = await GetById(_id);
            if (_salesRecordToRemove != null)
            {
                _context.SalesRecords.Remove(_salesRecordToRemove);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<SalesRecord>> GetAllAsync()
        {
            return await _context.SalesRecords
                .Include(s => s.Delivery)
                .Include(s => s.User)
                .ToListAsync();
        }

        public async Task<SalesRecord> GetById(int _id)
        {
            return await _context.SalesRecords
                .Include(s => s.Delivery)
                .Include(s => s.User)
                .FirstOrDefaultAsync(s => s.Id == _id);
        }

        public async Task<IEnumerable<SalesRecord>> GetByUserIdAsync(string _userId)
        {
            return await _context.SalesRecords
                .Where(s => s.UserId == _userId)
                .Include(s => s.Delivery)
                .Include(s => s.User)
                .ToListAsync();
        }
    }
}
