using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace TN.Admin.Services.API.Controllers
{
	public class ErrorsController : ControllerBase
	{
		[Route("/error")]
		public IActionResult Error()
		{
			Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
			return Problem(detail: exception?.Message, instance: HttpContext?.Request?.Path);
		}
	}
}
