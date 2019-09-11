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
    public class DeliveryTypeService : IDeliveryTypeService
    {
        private ApplicationDbContext _context;

        public DeliveryTypeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(DeliveryType _deliveryType)
        {
            await _context.DeliveryTypes.AddAsync(_deliveryType);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(DeliveryType _deliveryType)
        {
            var _productToEdit = await GetById(_deliveryType.Id);
            if (_productToEdit != null)
            {
                _productToEdit.Title = _deliveryType.Title;

                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveAsync(int _id)
        {
            var _deliveryTypeToRemove = await GetById(_id);
            if (_deliveryTypeToRemove != null)
            {
                _context.DeliveryTypes.Remove(_deliveryTypeToRemove);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<DeliveryType>> GetAllAsync()
        {
            return await _context.DeliveryTypes
                .ToListAsync();
        }

        public async Task<DeliveryType> GetById(int _id)
        {
            return await _context.DeliveryTypes
                .FirstOrDefaultAsync(s => s.Id == _id);
        }
    }
}
