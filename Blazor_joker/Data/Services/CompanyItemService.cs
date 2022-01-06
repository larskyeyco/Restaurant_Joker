using Blazor_joker.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blazor_joker.Data.Services
{
    public class CompanyItemService
    {
        readonly ApplicationDbContext _context;
        public CompanyItemService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<CompanyItem>> GetCompanyItemsAsync()
        {
            return await _context.CompanyItems.Include(y=> y.Company).ToListAsync();
        }
        public async Task<CompanyItem> GetCompanyItemByIdAsync(int id)
        {
            return await _context.CompanyItems.FindAsync(id);
        }
        public async Task<CompanyItem> InsertCompanyItemAsync(CompanyItem companyItem)
        {
            _context.CompanyItems.Add(companyItem);
            await _context.SaveChangesAsync();
            return companyItem;
        }
        public async Task<CompanyItem> UpdateCompanyItemAsync(int id, CompanyItem ci)
        {
            var companyItem = await _context.CompanyItems.FindAsync(id);
            if (companyItem == null)
                return null;
            companyItem.Name = ci.Name;
            companyItem.Description = ci.Description;
            companyItem.Image = ci.Image;
            companyItem.Price = ci.Price;
            companyItem.CompanyId = ci.CompanyId;
            _context.CompanyItems.Update(companyItem);
            await _context.SaveChangesAsync();
            return companyItem;
        }
        public async Task<CompanyItem> DeleteCompanyItemAsync(int id)
        {
            var companyItem = await _context.CompanyItems.FindAsync(id);
            if (companyItem == null)
                return null;
            _context.CompanyItems.Remove(companyItem);
            await _context.SaveChangesAsync();
            return companyItem;
        }
    }
}