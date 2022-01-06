using Blazor_joker.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blazor_joker.Data.Services
{
    public class OrderHistoryService
    {
        readonly ApplicationDbContext _context;
        public OrderHistoryService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<OrderHistory>> GetOrderHistoriesAsync()
        {
            return await _context.OrderHistories.ToListAsync();
        }
        public async Task<OrderHistory> GetOrderHistoryById(int id)
        {
            return await _context.OrderHistories.FindAsync(id);
        }
        public async Task<OrderHistory> InsertOrderHistoryAsync(OrderHistory orderHistory)
        {
            _context.OrderHistories.Add(orderHistory);
            await _context.SaveChangesAsync();
            return orderHistory;
        }
        public async Task<OrderHistory> UpdateOrderHistoryAsync(int id, OrderHistory oh)
        {
            var orderHistory = await _context.OrderHistories.FindAsync(id);
            if (orderHistory == null)
                return null;
            orderHistory.Name = oh.Name;
            orderHistory.Count = oh.Count;
            orderHistory.Price = oh.Price;
            _context.OrderHistories.Update(orderHistory);
            await _context.SaveChangesAsync();
            return orderHistory;
        }
        public async Task<OrderHistory> DeleteOrderHistoryAsync(int id)
        {
            var orderHistory = await _context.OrderHistories.FindAsync(id);
            if (orderHistory == null)
                return null;
            _context.OrderHistories.Remove(orderHistory);
            await _context.SaveChangesAsync();
            return orderHistory;
        }
    }
}