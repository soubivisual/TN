using Microsoft.AspNetCore.Mvc;

namespace TN.Admin.Web.ASPCore.Controllers
{
	public class MiscellaneousController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Error500()
		{
			return View();
		}

		public IActionResult Error404()
		{
			return View();
		}

		public IActionResult Error(int? statusCode = null)
		{
			if (statusCode.HasValue)
			{
				if (statusCode == 403 || statusCode == 404 || statusCode == 500)
				{
					var viewName = "Error" + statusCode.ToString();
					return View(viewName);
				}
			}

			return View("Error500");
		}
	}
}
