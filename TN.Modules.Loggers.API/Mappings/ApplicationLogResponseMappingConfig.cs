using Mapster;
using TN.Modules.Buildings.Shared.Dtos;
using TN.Modules.Loggers.API.Responses;

namespace TN.Modules.Loggers.API.Mappings
{
    internal sealed class ApplicationLogResponseMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<ApplicationLogDto, ApplicationLogResponse>()
                .Map(dest => dest.Payload, src => src);
        }
    }
}
