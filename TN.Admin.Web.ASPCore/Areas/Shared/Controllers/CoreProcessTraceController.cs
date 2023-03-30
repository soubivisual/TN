using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TN.Admin.Web.ASPCore.Areas.Shared.Models;
using TN.Admin.Web.ASPCore.Controllers;
using TN.Admin.Web.ASPCore.DataModels.Dto;

namespace TN.Admin.Web.ASPCore.Areas.Shared.Controllers
{
    [Area("Shared")]
    [Route("[controller]/[action]")]
    public class CoreProcessTraceController : AuthBaseController
    {
        private CoreProcessTraceModel _model = new();

		[HttpGet]
		public async Task<IActionResult> Index(Guid? coreProcessId, long? transactionId)
		{
			var coreProcessTrace = _model.CoreProcessTraces;

			try
			{
				//if (!coreProcessId.HasValue)
				//	throw new ValidationException("Bad Input");

				//var coreProcessTrace = await coreProcessTraceManager.GetCoreProcessTrace(coreProcessId.Value, transactionId);

				if (coreProcessTrace == null)
					throw new ValidationException("Core Process Trace no encontrado");

			}
			catch (ValidationException ex)
			{
				ErrorMessage = ex.Message;
			}

			await Task.CompletedTask;
			return View(coreProcessTrace);
		}
	}
}
