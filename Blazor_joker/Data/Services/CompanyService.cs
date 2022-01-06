using Blazor_joker.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blazor_joker.Data.Services
{
    public class CompanyService
    {
        readonly ApplicationDbContext _context;
        public CompanyService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Company>> GetCompaniesAsync()
        {
            return await _context.Companies.ToListAsync();
        }
        public async Task<Company> GetCompanyByIdAsync(int id)
        {
            return await _context.Companies.FindAsync(id);
        }
        public async Task<Company> InsertCompanyAsync(Company company)
        {
            _context.Companies.Add(company);
            await _context.SaveChangesAsync();
            return company;
        }
        public async Task<Company> UpdateCompanyAsync(int id, Company c)
        {
            var company = await _context.Companies.FindAsync(id);
            if (company == null)
                return null;
            company.Name = c.Name;
            company.DisplayOrder = c.DisplayOrder;
            _context.Companies.Update(company);
            await _context.SaveChangesAsync();
            return company;
        }
        public async Task<Company> DeleteCompanyAsync(int id)
        {
            var company = await _context.Companies.FindAsync(id);
            if (company == null)
                return null;
            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();
            return company;
        }
    }
}