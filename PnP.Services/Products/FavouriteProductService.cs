using PnP.Data;
using PnP.Data.Interfaces;
using PnP.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PnP.Services.Products
{
    public class FavouriteProductService : IFavouriteProductService
    {
        private ApplicationDbContext _context;

        public FavouriteProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(FavouriteProduct _favourite)
        {
            await _context.FavouriteProducts.AddAsync(_favourite);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(int _id)
        {
            var _favouriteToRemove = await GetById(_id);
            if (_favouriteToRemove != null)
            {
                _context.FavouriteProducts.Remove(_favouriteToRemove);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<FavouriteProduct>> GetAll()
        {
            return await _context.FavouriteProducts
                .Include(f => f.User)
                .Include(f => f.Product)
                .ToListAsync();
        }

        public async Task<FavouriteProduct> GetById(int _id)
        {
            return await _context.FavouriteProducts
                 .Include(f => f.User)
                 .Include(f => f.Product)
                 .FirstOrDefaultAsync(s => s.Id == _id);
        }

        public async Task<IEnumerable<FavouriteProduct>> GetByUserId(string _userId)
        {
            return await _context.FavouriteProducts
                .Where(s => s.UserId == _userId)
                .Include(f => f.User)
                .Include(f => f.Product)
                .ToListAsync();
        }
    }
}
