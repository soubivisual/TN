using Microsoft.AspNetCore.Mvc;

namespace TN.Admin.Web.ASPCore.Controllers
{
	public class AuthBaseController : Controller
	{
		public String? ErrorMessage
		{
			get => TempData["ErrorMessage"] is null ? String.Empty : TempData["ErrorMessage"]?.ToString();
			set => TempData["ErrorMessage"] = value; 
		}

        public String? WarningMessage
        {
            get =>  TempData ["WarningMessage"] is null ? String.Empty : TempData["WarningMessage"]?.ToString(); 
            set => TempData["WarningMessage"] = value; 
        }

        public String? SuccessMessage
        {
            get =>  TempData ["SuccessMessage"] is null ? String.Empty : TempData["SuccessMessage"]?.ToString(); 
            set => TempData["SuccessMessage"] = value; 
        }

        public String? InfoMessage
        {
            get =>   TempData ["InfoMessage"] is null ? String.Empty : TempData["InfoMessage"]?.ToString(); 
            set =>  TempData["InfoMessage"] = value; 
        }
    }
}
