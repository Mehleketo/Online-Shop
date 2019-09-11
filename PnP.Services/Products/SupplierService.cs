using PnP.Data;
using PnP.Data.Interfaces;
using PnP.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PnP.Services.Products
{
    public class SupplierService : ISupplierService
    {
        private ApplicationDbContext _context;

        public SupplierService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(Supplier _supplier)
        {
            await _context.Suppliers.AddAsync(_supplier);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(Supplier _supplier)
        {
            var _supplierToEdit = await GetById(_supplier.Id);
            if (_supplierToEdit != null)
            {
                _supplierToEdit.CompanyName = _supplier.CompanyName;
                _supplierToEdit.ContactName = _supplier.ContactName;
                _supplierToEdit.ContactTitle = _supplier.ContactTitle;
                _supplierToEdit.Address = _supplier.Address;
                _supplierToEdit.City = _supplier.City;
                _supplierToEdit.Province = _supplier.Province;
                _supplierToEdit.EmailAddress = _supplier.EmailAddress;
                _supplierToEdit.PhoneNumber = _supplier.PhoneNumber;
                _supplierToEdit.FaxNumber = _supplier.FaxNumber;
                _supplierToEdit.HomePage = _supplier.HomePage;
                _supplierToEdit.Slug = _supplier.Slug;

                await _context.SaveChangesAsync();
            }
        }

        public async Task Remove(int _id)
        {
            var _supplierToRemove = await GetById(_id);
            if (_supplierToRemove != null)
            {
                _context.Suppliers.Remove(_supplierToRemove);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Supplier>> GetAll()
        {
            return await _context.Suppliers
                .Include(s => s.Products)
                .ToListAsync();
        }

        public async Task<Supplier> GetById(int _id)
        {
            return await _context.Suppliers
                .Include(s => s.Products)
                .FirstOrDefaultAsync(s => s.Id == _id);
        }

        public async Task<Supplier> GetBySlug(string _slug)
        {
            return await _context.Suppliers
                .Include(s => s.Products)
                .FirstOrDefaultAsync(s => s.Slug == _slug);
        }
    }
}
