using TN.Modules.Buildings.Shared.Queries;

namespace TN.Modules.Remittances.Application.Remittances.Queries.GetRemittance
{
    public sealed record GetRemittanceQuery(long RemittanceId) : IQuery<RemittanceDto>
    {
    }
}
