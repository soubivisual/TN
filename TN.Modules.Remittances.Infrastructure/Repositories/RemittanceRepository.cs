using Microsoft.EntityFrameworkCore;
using TN.Modules.Remittances.Domain.Remittances.Entities;
using TN.Modules.Remittances.Domain.Remittances.Repositories;
using TN.Modules.Remittances.Infrastructure.DataAccess;

namespace TN.Modules.Remittances.Infrastructure.Repositories
{
    internal class RemittanceRepository : IRemittanceRepository
    {
        private readonly RemittancesDbContext _context;

        public RemittanceRepository(RemittancesDbContext context)
        {
            _context = context;
        }

        public Task<Remittance> GetAsync(long id)
            => _context.Remittances
                .AsNoTracking()
                .FirstOrDefaultAsync(q => q.Id == id);

        public async Task AddAsync(Remittance remittance)
        {
            await _context.Remittances.AddAsync(remittance);
            await _context.SaveChangesAsync();
        }
    }
}
