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
    public class IdentificationTypeService : IIdentificationTypeService
    {
        private ApplicationDbContext _context;

        public IdentificationTypeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(IdentificationType _identificationType)
        {
            await _context.IdentificationTypes.AddAsync(_identificationType);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(IdentificationType _identificationType)
        {
            var _identificationTypeToEdit = await GetById(_identificationType.Id);
            if (_identificationTypeToEdit != null)
            {
                _identificationTypeToEdit.Title = _identificationType.Title;

                await _context.SaveChangesAsync();
            }
        }

        public async Task Remove(int _id)
        {
            var _identificationTypeToRemove = await GetById(_id);
            if (_identificationTypeToRemove != null)
            {
                _context.IdentificationTypes.Remove(_identificationTypeToRemove);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<IdentificationType>> GetAll()
        {
            return await _context.IdentificationTypes
                .ToListAsync();
        }

        public async Task<IdentificationType> GetById(int _id)
        {
            return await _context.IdentificationTypes
                .FirstOrDefaultAsync(s => s.Id == _id);
        }
    }
}
