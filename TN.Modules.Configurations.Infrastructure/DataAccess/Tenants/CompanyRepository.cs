using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TN.Modules.Configurations.Domain.Tenants.Entities;
using TN.Modules.Configurations.Domain.Tenants.Repositories;

namespace TN.Modules.Configurations.Infrastructure.DataAccess.Companys
{
    internal sealed class CompanyRepository : ICompanyRepository
    {
        private readonly ConfigurationsDbContext _context;

        public CompanyRepository(ConfigurationsDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Company>> GetAllAsync()
        {
            var companiess = await _context.Companies
                .AsNoTracking()
                .ToListAsync();

            return companiess;
        }

        public Task<Company> GetAsync(int id)
        {
            return _context.Companies
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<Company> FindAsync(Expression<Func<Company, bool>> expression)
        {
            return _context.Companies
                .AsNoTracking()
                .Where(expression)
                .SingleOrDefaultAsync();
        }

        public async Task AddAsync(Company companies)
        {
            await _context.Companies.AddAsync(companies);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Company companies)
        {
            _context.Companies.Update(companies);
            await _context.SaveChangesAsync();
        }
    }
}
