using Blazor_joker.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blazor_joker.Data.Services
{
    public class OrderInformationService
    {
        readonly ApplicationDbContext _context;
        public OrderInformationService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<OrderInformation>> GetOrderInformationsAsync()
        {
            return await _context.OrderInformations.ToListAsync();
        }
        public async Task<OrderInformation> GetOrderInformationByIdAsync(int id)
        {
            return await _context.OrderInformations.FindAsync(id);
        }
        public async Task<OrderInformation> InsertOrderInformationsAsync(OrderInformation orderInformation)
        {
            _context.OrderInformations.Add(orderInformation);
            await _context.SaveChangesAsync();
            return orderInformation;
        }
        public async Task<OrderInformation> UpdateOrderInformationAsync(int id, OrderInformation oi)
        {
            var orderInformation = await _context.OrderInformations.FindAsync(id);
            if (orderInformation == null)
                return null;
            orderInformation.Name = oi.Name;
            orderInformation.Address = oi.Address;
            orderInformation.PhoneNumber = oi.PhoneNumber;
            orderInformation.AdditionalInstructions = oi.AdditionalInstructions;
            orderInformation.IndetityUserId = oi.IndetityUserId;
            _context.OrderInformations.Update(orderInformation);
            await _context.SaveChangesAsync();
            return orderInformation;
        }
        public async Task<OrderInformation> DeleteOrderInformationAsync(int id)
        {
            var orderInformation = await _context.OrderInformations.FindAsync(id);
            if (orderInformation == null)
                return null;
            _context.OrderInformations.Remove(orderInformation);
            await _context.SaveChangesAsync();
            return orderInformation;
        }

    }
}