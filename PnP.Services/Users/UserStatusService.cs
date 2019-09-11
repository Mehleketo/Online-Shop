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
    public class UserStatusService : IUserStatusService
    {
        private ApplicationDbContext _context;

        public UserStatusService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(UserStatus _userStatus)
        {
            await _context.UserStatuses.AddAsync(_userStatus);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(UserStatus _userStatus)
        {
            var _userStatusToEdit = await GetById(_userStatus.Id);
            if (_userStatusToEdit != null)
            {
                _userStatusToEdit.Title = _userStatus.Title;

                await _context.SaveChangesAsync();
            }
        }

        public async Task Remove(int _id)
        {
            var _userStatusToRemove = await GetById(_id);
            if (_userStatusToRemove != null)
            {
                _context.UserStatuses.Remove(_userStatusToRemove);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<UserStatus>> GetAll()
        {
            return await _context.UserStatuses
                .ToListAsync();
        }

        public async Task<UserStatus> GetById(int _id)
        {
            return await _context.UserStatuses
                .FirstOrDefaultAsync(s => s.Id == _id);
        }
    }
}
