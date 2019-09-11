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
    public class OrderStatusService : IOrderStatusService
    {
        private ApplicationDbContext _context;

        public OrderStatusService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(OrderStatus _orderStatus)
        {
            await _context.OrderStatuses.AddAsync(_orderStatus);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(OrderStatus _orderStatus)
        {
            var __orderStatusToEdit = await GetById(_orderStatus.Id);
            if (__orderStatusToEdit != null)
            {
                __orderStatusToEdit.Title = _orderStatus.Title;

                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveAsync(int _id)
        {
            var __orderStatusToRemove = await GetById(_id);
            if (__orderStatusToRemove != null)
            {
                _context.OrderStatuses.Remove(__orderStatusToRemove);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<OrderStatus>> GetAllAsync()
        {
            return await _context.OrderStatuses
                .ToListAsync();
        }

        public async Task<OrderStatus> GetById(int _id)
        {
            return await _context.OrderStatuses
                .FirstOrDefaultAsync(s => s.Id == _id);
        }
    }
}
