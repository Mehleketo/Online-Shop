using PnP.Data;
using PnP.Data.Interfaces;
using PnP.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PnP.Services.Products
{
    public class ProductReviewService : IProductReviewService
    {
        private ApplicationDbContext _context;

        public ProductReviewService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(ProductReview _review)
        {
            await _context.ProductReviews.AddAsync(_review);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(ProductReview _review)
        {
            var _reviewToEdit = await GetById(_review.Id);
            if (_reviewToEdit != null)
            {
                _reviewToEdit.Title = _review.Title;
                _reviewToEdit.Comment = _review.Comment;
                _reviewToEdit.Rating = _review.Rating;
                _reviewToEdit.DateCreated = _review.DateCreated;
                _reviewToEdit.ProductId = _review.ProductId;
                _reviewToEdit.UserId = _review.UserId;

                await _context.SaveChangesAsync();
            }
        }

        public async Task Remove(int _id)
        {
            var _reviewToRemove = await GetById(_id);
            if (_reviewToRemove != null)
            {
                _context.ProductReviews.Remove(_reviewToRemove);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ProductReview>> GetAll()
        {
            return await _context.ProductReviews
                .Include(r => r.Product)
                .Include(r => r.User)
                .ToListAsync();
        }

        public async Task<ProductReview> GetById(int _id)
        {
            return await _context.ProductReviews
                .Include(r => r.Product)
                .Include(r => r.User)
                .FirstOrDefaultAsync(s => s.Id == _id);
        }

        public async Task<IEnumerable<ProductReview>> GetByProductId(int _productId)
        {
            return await _context.ProductReviews
                .Where(r => r.ProductId == _productId)
                .Include(r => r.Product)
                .Include(r => r.User)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductReview>> GetByUserId(string _userId)
        {
            return await _context.ProductReviews
                .Where(r => r.UserId == _userId)
                .Include(r => r.Product)
                .Include(r => r.User)
                .ToListAsync();
        }
    }
}
