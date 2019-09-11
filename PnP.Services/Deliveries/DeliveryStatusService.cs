using PnP.Data;
using PnP.Data.Interfaces;
using PnP.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PnP.Services.Deliveries
{
    public class DeliveryStatusService : IDeliveryStatusService
    {
        private ApplicationDbContext _context;

        public DeliveryStatusService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(DeliveryStatus _deliveryStatus)
        {
            await _context.DeliveryStatuses.AddAsync(_deliveryStatus);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(DeliveryStatus _deliveryStatus)
        {
            var _deliveryStatusToEdit = await GetById(_deliveryStatus.Id);
            if (_deliveryStatusToEdit != null)
            {
                _deliveryStatusToEdit.Title = _deliveryStatus.Title;

                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveAsync(int _id)
        {
            var _deliveryStatusToRemove = await GetById(_id);
            if (_deliveryStatusToRemove != null)
            {
                _context.DeliveryStatuses.Remove(_deliveryStatusToRemove);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<DeliveryStatus>> GetAllAsync()
        {
            return await _context.DeliveryStatuses
                .ToListAsync();
        }

        public async Task<DeliveryStatus> GetById(int _id)
        {
            return await _context.DeliveryStatuses
                .FirstOrDefaultAsync(s => s.Id == _id);
        }
    }
}
