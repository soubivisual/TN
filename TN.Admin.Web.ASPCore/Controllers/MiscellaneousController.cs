using Microsoft.AspNetCore.Mvc;

namespace TN.Admin.Web.ASPCore.Controllers
{
	public class MiscellaneousController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Error500(string? coreProcessId = null)
		{
			ViewBag.CoreProcessId = coreProcessId;

			return View();
		}

		public IActionResult Error404()
		{
			return View();
		}

		//public IActionResult Error(int? statusCode = null, string? coreProcessId = null)
		//{
		//	ViewBag.CoreProcessId = coreProcessId;
			
		//	return View(statusCode.HasValue ? $"Error{statusCode.Value}" : "Error500");
		//}
	}
}
