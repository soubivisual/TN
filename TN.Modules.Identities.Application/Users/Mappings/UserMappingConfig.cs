using Mapster;

namespace TN.Modules.Identities.Application.Users.Mappings
{
    internal sealed class UserMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            //config.NewConfig<AddUserCommand, User>()
            //    .Map(dest => dest.Name, src => "esta es una prueba " + src.Name);
        }
    }
}
