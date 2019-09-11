using PnP.Data;
using PnP.Data.Interfaces;
using PnP.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PnP.Services.Users
{
    public class DeliveryAddressService : IDeliveryAddressService
    {
        private ApplicationDbContext _context;

        public DeliveryAddressService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(DeliveryAddress _deliveryAddress)
        {
            await _context.DeliveryAddresses.AddAsync(_deliveryAddress);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(DeliveryAddress _deliveryAddress)
        {
            var _deliveryAddressToEdit = await GetById(_deliveryAddress.Id);
            if (_deliveryAddressToEdit != null)
            {
                _deliveryAddressToEdit.Nickname = _deliveryAddress.Nickname;
                _deliveryAddressToEdit.StreetAddress = _deliveryAddress.StreetAddress;
                _deliveryAddressToEdit.Suburb = _deliveryAddress.Suburb;
                _deliveryAddressToEdit.City = _deliveryAddress.City;
                _deliveryAddressToEdit.PostalCode = _deliveryAddress.PostalCode;
                _deliveryAddressToEdit.DateCreated = _deliveryAddress.DateCreated;
                _deliveryAddressToEdit.AddressTypeId = _deliveryAddress.AddressTypeId;
                _deliveryAddressToEdit.ProvinceId = _deliveryAddress.ProvinceId;
                _deliveryAddressToEdit.UserId = _deliveryAddress.UserId;

                await _context.SaveChangesAsync();
            }
        }

        public async Task Remove(int _id)
        {
            var _deliveryAddressToRemove = await GetById(_id);
            if (_deliveryAddressToRemove != null)
            {
                _context.DeliveryAddresses.Remove(_deliveryAddressToRemove);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<DeliveryAddress>> GetAll()
        {
            return await _context.DeliveryAddresses
                .ToListAsync();
        }

        public async Task<DeliveryAddress> GetById(int _id)
        {
            return await _context.DeliveryAddresses
                .FirstOrDefaultAsync(s => s.Id == _id);
        }

        public async Task<IEnumerable<DeliveryAddress>> GetByUserId(string _userId)
        {
            return await _context.DeliveryAddresses
                .Where(s => s.UserId == _userId)
                .ToListAsync();
        }
    }
}
