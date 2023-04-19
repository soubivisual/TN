using System.Linq.Expressions;
using TN.Modules.Identities.Domain.Roles.Entities;

namespace TN.Modules.Identities.Domain.Claims.Repositories
{
    public interface IClaimRepository
    {
        Task<IReadOnlyList<Claim>> GetAllAsync();

        Task<Claim> GetAsync(int id);

        Task<Claim> FindAsync(Expression<Func<Claim, bool>> expression);

        Task AddAsync(Claim Claim);

        Task UpdateAsync(Claim Claim);
    }
}
