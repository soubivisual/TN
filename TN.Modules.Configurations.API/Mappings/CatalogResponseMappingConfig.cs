using Mapster;
using TN.Modules.Buildings.Shared.Dtos;
using TN.Modules.Configurations.API.Responses;

namespace TN.Modules.Configurations.API.Mappings
{
    internal sealed class CatalogResponseMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CatalogDto, CatalogResponse>()
                .Map(dest => dest.Payload, src => src);
        }
    }
}
