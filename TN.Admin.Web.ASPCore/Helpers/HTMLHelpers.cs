using Microsoft.AspNetCore.Mvc.Rendering;

namespace TN.Admin.Web.ASPCore
{
	public static class HTMLHelpers
	{
		public static string IsSelected(this IHtmlHelper html, string controller = null, string action = null, string area = null, string id = null, string cssClass = null)
		{
			if (String.IsNullOrEmpty(cssClass))
				cssClass = "active";

			string currentArea = html.GetArea();
			string currentController = html.GetController();
			string currentAction = html.GetAction();
			string currentId = html.GetId();


			if (String.IsNullOrEmpty(area))
				area = currentArea;

			if (String.IsNullOrEmpty(controller))
				controller = currentController;

			if (String.IsNullOrEmpty(action))
				action = currentAction;

			if (String.IsNullOrEmpty(id))
				id = currentId;

			string asignedClass = controller == currentController && action == currentAction && area == currentArea && id == currentId ? cssClass : String.Empty;
			return asignedClass;
		}

		public static string GetArea(this IHtmlHelper html)
		{
			return (string)html.ViewContext.RouteData.Values["area"];
		}

		public static string GetController(this IHtmlHelper html)
		{
			return (string)html.ViewContext.RouteData.Values["controller"];
		}

		public static string GetAction(this IHtmlHelper html)
		{
			return (string)html.ViewContext.RouteData.Values["action"];
		}

		public static string GetQueryString(this IHtmlHelper html, string key)
		{
			return html.ViewContext.HttpContext.Request.Query[key].FirstOrDefault();
		}

		public static string GetId(this IHtmlHelper html)
		{
			return html.ViewContext.HttpContext.Request.Query["id"].FirstOrDefault();
		}

		public static string GetQueryType(this IHtmlHelper html)
		{
			return html.ViewContext.HttpContext.Request.Query["type"].FirstOrDefault();
		}

		public static string GetDescription(this IHtmlHelper html)
		{
			return html.ViewContext.HttpContext.Request.Query["description"].FirstOrDefault();
		}

		public static string GetAreaDescription(this IHtmlHelper html)
		{
			return html.GetArea();
		}
	}
}
