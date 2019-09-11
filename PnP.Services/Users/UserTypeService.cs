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
    public class UserTypeService : IUserTypeService
    {
        private ApplicationDbContext _context;

        public UserTypeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(UserType _userType)
        {
            await _context.UserTypes.AddAsync(_userType);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(UserType _userType)
        {
            var _userTypeToEdit = await GetById(_userType.Id);
            if (_userTypeToEdit != null)
            {
                _userTypeToEdit.Title = _userType.Title;

                await _context.SaveChangesAsync();
            }
        }

        public async Task Remove(int _id)
        {
            var _userTypeToRemove = await GetById(_id);
            if (_userTypeToRemove != null)
            {
                _context.UserTypes.Remove(_userTypeToRemove);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<UserType>> GetAll()
        {
            return await _context.UserTypes
                .ToListAsync();
        }

        public async Task<UserType> GetById(int _id)
        {
            return await _context.UserTypes
                .FirstOrDefaultAsync(s => s.Id == _id);
        }
    }
}
