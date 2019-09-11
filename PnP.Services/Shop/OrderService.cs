using PnP.Data;
using PnP.Data.Interfaces;
using PnP.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PnP.Services.Shop
{
    public class OrderService : IOrderService
    {
        private ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Order _order)
        {
            await _context.Orders.AddAsync(_order);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(Order _order)
        {
            var __orderToEdit = await GetById(_order.Id);
            if (__orderToEdit != null)
            {
                __orderToEdit.DateCreated = _order.DateCreated;
                __orderToEdit.StatusId = _order.StatusId;
                __orderToEdit.TrolleyId = _order.TrolleyId;
                __orderToEdit.UserId = _order.UserId;

                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveAsync(int _id)
        {
            var _orderToRemove = await GetById(_id);
            if (_orderToRemove != null)
            {
                _context.Orders.Remove(_orderToRemove);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _context.Orders
                .Include(s => s.Status)
                .Include(s => s.Trolley)
                .Include(s => s.User)
                .ToListAsync();
        }

        public async Task<Order> GetById(int _id)
        {
            return await _context.Orders
                .Include(s => s.Status)
                .Include(s => s.Trolley)
                .Include(s => s.User)
                .FirstOrDefaultAsync(s => s.Id == _id);
        }

        public async Task<IEnumerable<Order>> GetByUserIdAsync(string _userId)
        {
            return await _context.Orders
                .Where(s => s.UserId == _userId)
                .Include(s => s.Status)
                .Include(s => s.Trolley)
                .Include(s => s.User)
                .ToListAsync();
        }
    }
}
