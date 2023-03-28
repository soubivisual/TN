using TN.Modules.Buildings.Shared.Api;
using TN.Modules.Buildings.Shared.Time;
using TN.Shared.Utils.Misc;

namespace TN.Modules.Buildings.Shared.Mapper
{
    public class Mapping : MapsterMapper.Mapper, IMapping
    {
        private readonly IClock _clock;

        public Mapping(IClock clock)
        {
            _clock = clock;
        }

        public new TDestination Map<TDestination>(object source)
        {
            if (source == null)
            {
                return default;
            }

            var response = base.Map<TDestination>(source);

            if (response.GetType().BaseType.IsGenericType && 
                response.GetType().BaseType.GetGenericTypeDefinition() == typeof(BaseResponse<>))
            {
                ((dynamic)response).Timestamp = _clock.CurrentTimestamp();
            }

            return response;
        }
    }
}
