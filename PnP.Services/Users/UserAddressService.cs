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
    public class UserAddressService : IUserAddressService
    {
        private ApplicationDbContext _context;

        public UserAddressService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(UserAddress _userAddress)
        {
            await _context.UserAddresses.AddAsync(_userAddress);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(UserAddress _userAddress)
        {
            var _userAddressToEdit = await GetById(_userAddress.Id);
            if (_userAddressToEdit != null)
            {
                _userAddressToEdit.Nickname = _userAddress.Nickname;
                _userAddressToEdit.StreetAddress = _userAddress.StreetAddress;
                _userAddressToEdit.Suburb = _userAddress.Suburb;
                _userAddressToEdit.City = _userAddress.City;
                _userAddressToEdit.PostalCode = _userAddress.PostalCode;
                _userAddressToEdit.DateCreated = _userAddress.DateCreated;
                _userAddressToEdit.AddressTypeId = _userAddress.AddressTypeId;
                _userAddressToEdit.ProvinceId = _userAddress.ProvinceId;
                _userAddressToEdit.UserId = _userAddress.UserId;

                await _context.SaveChangesAsync();
            }
        }

        public async Task Remove(int _id)
        {
            var _userAddressToRemove = await GetById(_id);
            if (_userAddressToRemove != null)
            {
                _context.UserAddresses.Remove(_userAddressToRemove);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<UserAddress>> GetAll()
        {
            return await _context.UserAddresses
                .ToListAsync();
        }

        public async Task<UserAddress> GetById(int _id)
        {
            return await _context.UserAddresses
                .FirstOrDefaultAsync(s => s.Id == _id);
        }

        public async Task<IEnumerable<UserAddress>> GetByUserId(string _userId)
        {
            return await _context.UserAddresses
                .Where(s => s.UserId == _userId)
                .ToListAsync();
        }
    }
}
