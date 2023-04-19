using Microsoft.EntityFrameworkCore;
using TN.Modules.Remittances.Domain.Remittances.Aggregates;
using TN.Modules.Remittances.Domain.Remittances.Repositories;

namespace TN.Modules.Remittances.Infrastructure.DataAccess.Remittances
{
    internal class RemittanceRepository : IRemittanceRepository
    {
        private readonly RemittancesDbContext _context;

        public RemittanceRepository(RemittancesDbContext context)
        {
            _context = context;
        }

        public Task<Remittance> GetAsync(long id)
        {
            return _context.Remittances
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(Remittance remittance)
        {
            await _context.Remittances.AddAsync(remittance);
            await _context.SaveChangesAsync();
        }
    }
}
