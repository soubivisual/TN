using Microsoft.AspNetCore.Mvc;

namespace TN.Admin.Web.ASPCore.Areas.Maintenances.Controllers
{
    public class CatalogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
