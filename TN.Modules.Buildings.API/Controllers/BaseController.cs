using Microsoft.AspNetCore.Mvc;
using TN.Shared.Utils.Misc;

namespace TN.Modules.Buildings.API.Controllers
{
    public class BaseController : ControllerBase
    {
        private Guid? coreProcessId = null;
        public Guid CoreProcessId
        {
            get
            {
                if (!coreProcessId.HasValue)
                {
                    Request.Headers.TryGetValue("CoreProcessId", out var coreProcessIdHeader);

                    if (!string.IsNullOrEmpty(coreProcessIdHeader))
                        coreProcessId = coreProcessIdHeader.ToString().ToGuid();
                    else
                        coreProcessId = Guid.NewGuid();

                    HttpContext.Items.TryAdd("CoreProcessId", coreProcessId);
                }

                return coreProcessId.Value;
            }
        }
    }
}
