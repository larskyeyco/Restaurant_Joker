using Blazor_joker.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blazor_joker.Data.Services
{
    public class ShoppingCartService
    {
        readonly ApplicationDbContext _context;
        public ShoppingCartService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<ShoppingCart>> GetShoppingCartsAsync()
        {
            return await _context.ShoppingCarts.ToListAsync();
        }
        public async Task<ShoppingCart> GetShoppingCartByIdAsync(int id)
        {
            return await _context.ShoppingCarts.FindAsync(id);
        }
        public async Task<ShoppingCart> InsertShoppingCartAsync(ShoppingCart shoppingCart)
        {
            _context.ShoppingCarts.Add(shoppingCart);
            await _context.SaveChangesAsync();
            return shoppingCart;
        }
        public async Task<ShoppingCart> UpdateShoppingCartAsync(int id, ShoppingCart sc)
        {
            var shoppingCart = await _context.ShoppingCarts.FindAsync(id);
            if (shoppingCart == null)
                return null;
            shoppingCart.Count = sc.Count;
            _context.ShoppingCarts.Update(shoppingCart);
            await _context.SaveChangesAsync();
            return shoppingCart;
        }
        public async Task<ShoppingCart> DeleteShoppingCart(int id)
        {
            var shoppingCart = await _context.ShoppingCarts.FindAsync(id);
            if (shoppingCart == null)
                return null;
            _context.ShoppingCarts.Remove(shoppingCart);
            await _context.SaveChangesAsync();
            return shoppingCart;
        }
        public async Task<List<ShoppingCart>> SummaryShoppingCartsAsync()
        {
            return await _context.ShoppingCarts.Include(y => y.CompanyItem).ToListAsync();
        }
    }
}