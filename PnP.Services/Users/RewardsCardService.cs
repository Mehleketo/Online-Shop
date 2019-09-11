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
    public class RewardsCardService : IRewardsCardService
    {
        private ApplicationDbContext _context;

        public RewardsCardService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(RewardsCard _rewardsCard)
        {
            await _context.RewardsCards.AddAsync(_rewardsCard);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(RewardsCard _rewardsCard)
        {
            var _rewardsCardCardToEdit = await GetById(_rewardsCard.Id);
            if (_rewardsCardCardToEdit != null)
            {
                _rewardsCardCardToEdit.CardNumber = _rewardsCard.CardNumber;
                _rewardsCardCardToEdit.DateCreated = _rewardsCard.DateCreated;
                _rewardsCardCardToEdit.UserId = _rewardsCard.UserId;

                await _context.SaveChangesAsync();
            }
        }

        public async Task Remove(int _id)
        {
            var _rewardsCardToRemove = await GetById(_id);
            if (_rewardsCardToRemove != null)
            {
                _context.RewardsCards.Remove(_rewardsCardToRemove);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<RewardsCard>> GetAll()
        {
            return await _context.RewardsCards
                .ToListAsync();
        }

        public async Task<RewardsCard> GetById(int _id)
        {
            return await _context.RewardsCards
                .FirstOrDefaultAsync(s => s.Id == _id);
        }

        public async Task<IEnumerable<RewardsCard>> GetByUserId(string _userId)
        {
            return await _context.RewardsCards
                .Where(s => s.UserId == _userId)
                .ToListAsync();
        }
    }
}
