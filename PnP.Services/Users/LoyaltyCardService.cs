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
    public class LoyaltyCardService : ILoyaltyCardService
    {
        private ApplicationDbContext _context;

        public LoyaltyCardService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(LoyaltyCard _loyaltyCard)
        {
            await _context.LoyaltyCards.AddAsync(_loyaltyCard);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(LoyaltyCard _loyaltyCard)
        {
            var _loyaltyCardToEdit = await GetById(_loyaltyCard.Id);
            if (_loyaltyCardToEdit != null)
            {
                _loyaltyCardToEdit.CardNumber = _loyaltyCard.CardNumber;
                _loyaltyCardToEdit.DateCreated = _loyaltyCard.DateCreated;
                _loyaltyCardToEdit.UserId = _loyaltyCard.UserId;

                await _context.SaveChangesAsync();
            }
        }

        public async Task Remove(int _id)
        {
            var _loyaltyCardToRemove = await GetById(_id);
            if (_loyaltyCardToRemove != null)
            {
                _context.LoyaltyCards.Remove(_loyaltyCardToRemove);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<LoyaltyCard>> GetAll()
        {
            return await _context.LoyaltyCards
                .ToListAsync();
        }

        public async Task<LoyaltyCard> GetById(int _id)
        {
            return await _context.LoyaltyCards
                .FirstOrDefaultAsync(s => s.Id == _id);
        }

        public async Task<IEnumerable<LoyaltyCard>> GetByUserId(string _userId)
        {
            return await _context.LoyaltyCards
                .Where(s => s.UserId == _userId)
                .ToListAsync();
        }
    }
}
