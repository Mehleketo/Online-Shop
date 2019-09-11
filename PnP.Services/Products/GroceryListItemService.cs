using PnP.Data;
using PnP.Data.Interfaces;
using PnP.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PnP.Services.Products
{
    public class GroceryListItemService : IGroceryListItemService
    {
        private ApplicationDbContext _context;

        public GroceryListItemService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(GroceryListItem _groceryListItem)
        {
            await _context.GroceryListItems.AddAsync(_groceryListItem);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(GroceryListItem _groceryListItem)
        {
            var _groceryListItemToEdit = await GetById(_groceryListItem.Id);
            if (_groceryListItemToEdit != null)
            {
                _groceryListItemToEdit.Quantity = _groceryListItem.Quantity;
                _groceryListItemToEdit.DateCreated = _groceryListItem.DateCreated;
                _groceryListItemToEdit.GroceryListId = _groceryListItem.GroceryListId;
                _groceryListItemToEdit.ProductId = _groceryListItem.ProductId;

                await _context.SaveChangesAsync();
            }
        }

        public async Task Remove(int _id)
        {
            var _groceryListItemToRemove = await GetById(_id);
            if (_groceryListItemToRemove != null)
            {
                _context.GroceryListItems.Remove(_groceryListItemToRemove);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<GroceryListItem>> GetAll()
        {
            return await _context.GroceryListItems
                .Include(g => g.GroceryList)
                .Include(g => g.Product)
                .ToListAsync();
        }

        public async Task<IEnumerable<GroceryListItem>> GetByGroceryListId(int _groceryListId)
        {
            return await _context.GroceryListItems
                .Where(g => g.GroceryListId == _groceryListId)
                .Include(g => g.GroceryList)
                .Include(g => g.Product)
                .ToListAsync();
        }

        public async Task<GroceryListItem> GetById(int _id)
        {
            return await _context.GroceryListItems
                .Include(g => g.GroceryList)
                .Include(g => g.Product)
                .FirstOrDefaultAsync(g => g.Id == _id);
        }
    }
}
