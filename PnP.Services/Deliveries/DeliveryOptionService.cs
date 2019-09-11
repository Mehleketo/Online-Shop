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
    public class DeliveryOptionService : IDeliveryOptionService
    {
        private ApplicationDbContext _context;

        public DeliveryOptionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(DeliveryOption _deliveryOption)
        {
            await _context.DeliveryOptions.AddAsync(_deliveryOption);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(DeliveryOption _deliveryOption)
        {
            var _deliveryOptionToEdit = await GetById(_deliveryOption.Id);
            if (_deliveryOptionToEdit != null)
            {
                _deliveryOptionToEdit.Title = _deliveryOption.Title;
                _deliveryOptionToEdit.Description = _deliveryOption.Description;

                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveAsync(int _id)
        {
            var _deliveryOptionToRemove = await GetById(_id);
            if (_deliveryOptionToRemove != null)
            {
                _context.DeliveryOptions.Remove(_deliveryOptionToRemove);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<DeliveryOption>> GetAllAsync()
        {
            return await _context.DeliveryOptions
                .ToListAsync();
        }

        public async Task<DeliveryOption> GetById(int _id)
        {
            return await _context.DeliveryOptions
                .FirstOrDefaultAsync(s => s.Id == _id);
        }
    }
}
