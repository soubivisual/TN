using TN.Modules.Buildings.Application.Configuration;
using TN.Modules.Buildings.Shared.Mapping;
using TN.Modules.Remittances.Domain.Remittances.Repositories;

namespace TN.Modules.Remittances.Application.Remittances.Queries.GetRemittance
{
    internal class GetRemittanceQueryHandler : IQueryHandler<GetRemittanceQuery, RemittanceDto>
    {
        private readonly IRemittanceRepository _remittanceRepository;
        private readonly IMapping _mapping;

        public GetRemittanceQueryHandler(IRemittanceRepository remittanceRepository, IMapping mapping)
        {
            _remittanceRepository = remittanceRepository;
            _mapping = mapping;
        }

        public async Task<RemittanceDto> Handle(GetRemittanceQuery request, CancellationToken cancellationToken)
        {
            var remittance = await _remittanceRepository.GetAsync(request.RemittanceId);
            return _mapping.Map<RemittanceDto>(remittance);
        }
    }
}
