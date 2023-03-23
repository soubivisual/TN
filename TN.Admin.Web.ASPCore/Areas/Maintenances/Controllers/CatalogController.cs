using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using TN.Admin.Web.ASPCore.Areas.Maintenances.Models;
using TN.Admin.Web.ASPCore.Controllers;
using TN.Admin.Web.ASPCore.DataModels.Dto;

namespace TN.Admin.Web.ASPCore.Areas.Maintenances.Controllers
{
	[Area("Maintenances")]
	[Route("[controller]/[action]")]
	public class CatalogController : AuthBaseController
	{
		private readonly CatalogModel _model = new();

		public async Task<IActionResult> Index()
		{
			await Task.CompletedTask;
			return View(_model);
		}

		[HttpGet]
		public async Task<IActionResult> Create()
		{
			await Task.CompletedTask;
			return View(_model.Catalog);
		}

		[HttpPost]
		public async Task<IActionResult> Create(CatalogDto catalogDto)
		{
			if (!ModelState.IsValid)
				return View();

			_model.Catalog = catalogDto;
			await Task.CompletedTask;
			return View(nameof(Index), _model);
		}

		[HttpGet]
		public async Task<IActionResult> Update(Guid? id)
		{
			await Task.CompletedTask;
			return View(_model.Catalog);
		}

		[HttpPost]
		public async Task<IActionResult> Update(CatalogDto catalogDto)
		{
			if (!ModelState.IsValid)
				return View();

			await Task.CompletedTask;
			return View(nameof(Index), _model);
		}

		[HttpGet]
		public async Task<IActionResult> Delete(Guid? id)
		{
			await Task.CompletedTask;
			return View(_model.Catalog);
		}

		[HttpPost]
		public async Task<IActionResult> Delete(CatalogDto catalogDto)
		{
			if (!ModelState.IsValid)
				return View();

			await Task.CompletedTask;
			return View(nameof(Index), _model);
		}

		[HttpGet]
		public async Task<IActionResult> Detail(Guid? id)
		{
			await Task.CompletedTask;
			return View(_model.Catalog);
		}

	}
}
