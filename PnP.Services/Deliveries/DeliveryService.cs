using PnP.Data;
using PnP.Data.Interfaces;
using PnP.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PnP.Services.Deliveries
{
    public class DeliveryService : IDeliveryService
    {
        private ApplicationDbContext _context;

        public DeliveryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Delivery _delivery)
        {
            await _context.Deliveries.AddAsync(_delivery);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(Delivery _delivery)
        {
            var _deliveryToEdit = await GetById(_delivery.Id);
            if (_deliveryToEdit != null)
            {
                _deliveryToEdit.Instructions = _delivery.Instructions;
                _deliveryToEdit.Cost = _delivery.Cost;
                _deliveryToEdit.DateCreated = _delivery.DateCreated;
                _deliveryToEdit.DeliveryAddressId = _delivery.DeliveryAddressId;
                _deliveryToEdit.DeliveryOptionId = _delivery.DeliveryOptionId;
                _deliveryToEdit.DeliveryTypeId = _delivery.DeliveryTypeId;
                _deliveryToEdit.StatusId = _delivery.StatusId;
                _deliveryToEdit.UserId = _delivery.UserId;

                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveAsync(int _id)
        {
            var _deliveryToRemove = await GetById(_id);
            if (_deliveryToRemove != null)
            {
                _context.Deliveries.Remove(_deliveryToRemove);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Delivery>> GetAllAsync()
        {
            return await _context.Deliveries
                .ToListAsync();
        }

        public async Task<IEnumerable<Delivery>> GetByUserIdAsync(string _userId)
        {
            return await _context.Deliveries
                .Where(s => s.UserId == _userId)
                .ToListAsync();
        }

        public async Task<Delivery> GetById(int _id)
        {
            return await _context.Deliveries
                .FirstOrDefaultAsync(s => s.Id == _id);
        }
    }
}
