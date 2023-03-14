using TN.Modules.Buildings.Application.Contracts;

namespace TN.Modules.Remittances.Application.Remittances.Queries.GetRemittance
{
    public sealed record GetRemittanceQuery(long RemittanceId) : IQuery<RemittanceDto>
    {
    }
}
