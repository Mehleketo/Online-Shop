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
    public class ContactDetailService : IContactDetailService
    {
        private ApplicationDbContext _context;

        public ContactDetailService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(ContactDetail _contactDetail)
        {
            await _context.ContactDetails.AddAsync(_contactDetail);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(ContactDetail _contactDetail)
        {
            var _contactDetailToEdit = await GetById(_contactDetail.Id);
            if (_contactDetailToEdit != null)
            {
                _contactDetailToEdit.CellNumber = _contactDetail.CellNumber;
                _contactDetailToEdit.WorkNumber = _contactDetail.WorkNumber;
                _contactDetailToEdit.HomeNumber = _contactDetail.HomeNumber;
                _contactDetailToEdit.DateCreated = _contactDetail.DateCreated;
                _contactDetailToEdit.UserId = _contactDetail.UserId;

                await _context.SaveChangesAsync();
            }
        }

        public async Task Remove(int _id)
        {
            var _contactDetailToRemove = await GetById(_id);
            if (_contactDetailToRemove != null)
            {
                _context.ContactDetails.Remove(_contactDetailToRemove);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ContactDetail>> GetAll()
        {
            return await _context.ContactDetails
                .ToListAsync();
        }

        public async Task<ContactDetail> GetById(int _id)
        {
            return await _context.ContactDetails
                .FirstOrDefaultAsync(s => s.Id == _id);
        }

        public async Task<IEnumerable<ContactDetail>> GetByUserId(string _userId)
        {
            return await _context.ContactDetails
                .Where(s => s.UserId == _userId)
                .ToListAsync();
        }
    }
}
