using PnP.Data;
using PnP.Data.Interfaces;
using PnP.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PnP.Services.Users
{
    public class AddressTypeService : IAddressTypeService
    {
        private ApplicationDbContext _context;

        public AddressTypeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(AddressType _addressType)
        {
            await _context.AddressTypes.AddAsync(_addressType);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(AddressType _addressType)
        {
            var _addressTypeToEdit = await GetById(_addressType.Id);
            if (_addressTypeToEdit != null)
            {
                _addressTypeToEdit.Title = _addressType.Title;

                await _context.SaveChangesAsync();
            }
        }

        public async Task Remove(int _id)
        {
            var _addressTypeToRemove = await GetById(_id);
            if (_addressTypeToRemove != null)
            {
                _context.AddressTypes.Remove(_addressTypeToRemove);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<AddressType>> GetAll()
        {
            return await _context.AddressTypes
                .ToListAsync();
        }

        public async Task<AddressType> GetById(int _id)
        {
            return await _context.AddressTypes
                .FirstOrDefaultAsync(s => s.Id == _id);
        }
    }
}
