using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TN.Modules.Buildings.Shared.Controllers
{
    [Authorize]
    [ApiController]
    public abstract class AuthBaseController : BaseController
    {
        
    }
}
