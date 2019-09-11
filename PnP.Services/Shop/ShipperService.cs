using PnP.Data;
using PnP.Data.Interfaces;
using PnP.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PnP.Services.Shop
{
    public class ShipperService : IShipperService
    {
        private ApplicationDbContext _context;

        public ShipperService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Shipper _shipper)
        {
            await _context.Shippers.AddAsync(_shipper);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(Shipper _shipper)
        {
            var _shipperToEdit = await GetById(_shipper.Id);
            if (_shipperToEdit != null)
            {
                _shipperToEdit.CompanyName = _shipper.CompanyName;
                _shipperToEdit.EmailAddress = _shipper.EmailAddress;
                _shipperToEdit.PhoneNumber = _shipper.PhoneNumber;
                _shipperToEdit.Slug = _shipper.Slug;

                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveAsync(int _id)
        {
            var _productToRemove = await GetById(_id);
            if (_productToRemove != null)
            {
                _context.Shippers.Remove(_productToRemove);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Shipper>> GetAllAsync()
        {
            return await _context.Shippers
                .ToListAsync();
        }

        public async Task<Shipper> GetById(int _id)
        {
            return await _context.Shippers
                .FirstOrDefaultAsync(s => s.Id == _id);
        }

        public async Task<Shipper> GetBySlug(string _slug)
        {
            return await _context.Shippers
                .FirstOrDefaultAsync(s => s.Slug == _slug);
        }
    }
}
