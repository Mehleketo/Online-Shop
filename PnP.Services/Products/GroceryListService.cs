using PnP.Data;
using PnP.Data.Interfaces;
using PnP.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PnP.Services.Products
{
    public class GroceryListService : IGroceryListService
    {
        private ApplicationDbContext _context;

        public GroceryListService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(GroceryList _groceryList)
        {
            await _context.GroceryLists.AddAsync(_groceryList);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(GroceryList _groceryList)
        {
            var _productToEdit = await GetById(_groceryList.Id);
            if (_productToEdit != null)
            {
                _productToEdit.Title = _groceryList.Title;
                _productToEdit.DateCreated = _groceryList.DateCreated;
                _productToEdit.UserId = _groceryList.UserId;

                await _context.SaveChangesAsync();
            }
        }

        public async Task Remove(int _id)
        {
            var _groceryListToRemove = await GetById(_id);
            if (_groceryListToRemove != null)
            {
                _context.GroceryLists.Remove(_groceryListToRemove);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<GroceryList>> GetAll()
        {
            return await _context.GroceryLists
                .Include(g => g.User)
                .Include(g => g.GroceryListItems)
                .ToListAsync();
        }

        public async Task<IEnumerable<GroceryList>> GetByUserId(string _userId)
        {
            return await _context.GroceryLists
                .Where(s => s.UserId == _userId)
                .Include(g => g.User)
                .Include(g => g.GroceryListItems)
                .ToListAsync();
        }

        public async Task<GroceryList> GetById(int _id)
        {
            return await _context.GroceryLists
                .Include(g => g.User)
                .Include(g => g.GroceryListItems)
                .FirstOrDefaultAsync(s => s.Id == _id);
        }
    }
}
