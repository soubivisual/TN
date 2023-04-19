using Mapster;
using TN.Modules.Buildings.Shared.Dtos;
using TN.Modules.Identities.API.Responses;

namespace TN.Modules.Identities.API.Mappings
{
    internal sealed class CatalogResponseMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<UserDto, UserResponse>()
                .Map(dest => dest.Payload, src => src);
        }
    }
}
