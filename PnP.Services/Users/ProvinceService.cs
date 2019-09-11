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
    public class ProvinceService : IProvinceService
    {
        private ApplicationDbContext _context;

        public ProvinceService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(Province _province)
        {
            await _context.Provinces.AddAsync(_province);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(Province _province)
        {
            var _provinceToEdit = await GetById(_province.Id);
            if (_provinceToEdit != null)
            {
                _provinceToEdit.Title = _province.Title;

                await _context.SaveChangesAsync();
            }
        }

        public async Task Remove(int _id)
        {
            var _provinceToRemove = await GetById(_id);
            if (_provinceToRemove != null)
            {
                _context.Provinces.Remove(_provinceToRemove);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Province>> GetAll()
        {
            return await _context.Provinces
                .ToListAsync();
        }

        public async Task<Province> GetById(int _id)
        {
            return await _context.Provinces
                .FirstOrDefaultAsync(s => s.Id == _id);
        }
    }
}
