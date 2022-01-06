using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blazor_joker.Data.Services
{
    public class UserService
    {
        readonly ApplicationDbContext _context;
        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<IdentityUser>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<IdentityUser> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }
        public async Task<IdentityUser> LockUnlockAsync(string id, IdentityUser c)
        {
            var identityUser = await _context.Users.FindAsync(id);
            if (identityUser == null)
                return null;
            identityUser.LockoutEnd = c.LockoutEnd;
            _context.Users.Update(identityUser);
            await _context.SaveChangesAsync();
            return identityUser;
        }
        public async Task<IdentityUser> DeleteUserAsync(string id)
        {
            var identityUser = await _context.Users.FindAsync(id);
            if (identityUser == null)
                return null;
            _context.Users.Remove(identityUser);
            await _context.SaveChangesAsync();
            return identityUser;
        }

    }
}