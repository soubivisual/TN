using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using TN.Admin.Web.ASPCore.Miscellaneous;

namespace TN.Admin.Web.ASPCore.Helpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("default-button")]
	public class DefaultButtonTagHelper : TagHelper
	{
		[HtmlAttributeName("id")]
		public string Id { get; set; }

		[HtmlAttributeName("name")]
		public string Name { get; set; }

		[HtmlAttributeName("text")]
		public string Text { get; set; }

		[HtmlAttributeName("url")]
		public string Url { get; set; }

		[HtmlAttributeName("class")]
		public string Class { get; set; }

		[HtmlAttributeName("style")]
		public string Style { get; set; }

		[HtmlAttributeName("icon")]
		public string Icon { get; set; }

		[HtmlAttributeName("tooltip")]
		public string Tooltip { get; set; }

		[HtmlAttributeName("additional")]
		public Dictionary<string, object> Additional { get; set; }

		[HtmlAttributeName("disabled")]
		public bool Disabled { get; set; }

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			output.TagName = "a";

			if (!string.IsNullOrEmpty(Id))
				output.Attributes.SetAttribute("id", Id);
			if (!string.IsNullOrEmpty(Name))
				output.Attributes.SetAttribute("name", Name);
			if (!string.IsNullOrEmpty(Class))
				output.Attributes.SetAttribute("class", Class + (Disabled ? " disabled" : ""));
			if (!string.IsNullOrEmpty(Style))
				output.Attributes.SetAttribute("style", Style);
			if (!string.IsNullOrEmpty(Url))
				output.Attributes.SetAttribute("href", Url);
			if (!string.IsNullOrEmpty(Icon) || !string.IsNullOrEmpty(Text))
				output.Content.SetHtmlContent($@"<i class=""{Icon}""></i> {Text}");
			if (!string.IsNullOrEmpty(Tooltip))
			{
				output.Attributes.SetAttribute("data-toggle", "tooltip");
				output.Attributes.SetAttribute("title", Tooltip);
				output.Attributes.SetAttribute("data-placement", "top");
			}
			if (Additional != null && Additional.Any())
			{
				foreach (var data in Additional)
					output.Attributes.SetAttribute($"data-{data.Key}", data.Value);
			}
			if (Disabled)
				output.Attributes.SetAttribute("disabled", "disabled");
		}
	}

	[HtmlTargetElement("default-table-button")]
	public class DefaultTableButtonTagHelper : TagHelper
	{
		[HtmlAttributeName("id")]
		public string Id { get; set; }

		[HtmlAttributeName("name")]
		public string Name { get; set; }

		[HtmlAttributeName("text")]
		public string Text { get; set; }

		[HtmlAttributeName("url")]
		public string Url { get; set; }

		[HtmlAttributeName("class")]
		public string Class { get; set; }

		[HtmlAttributeName("style")]
		public string Style { get; set; }

		[HtmlAttributeName("icon")]
		public string Icon { get; set; }

		[HtmlAttributeName("tooltip")]
		public string Tooltip { get; set; }

		[HtmlAttributeName("disabled")]
		public bool Disabled { get; set; }

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			output.TagName = "a";

			if (!string.IsNullOrEmpty(Id))
				output.Attributes.SetAttribute("id", Id);
			if (!string.IsNullOrEmpty(Name))
				output.Attributes.SetAttribute("name", Name);
			if (!string.IsNullOrEmpty(Class))
				output.Attributes.SetAttribute("class", Class + (Disabled ? " disabled" : ""));
			if (!string.IsNullOrEmpty(Style))
				output.Attributes.SetAttribute("style", Style);
			if (!string.IsNullOrEmpty(Url))
				output.Attributes.SetAttribute("href", Url);
			if (!string.IsNullOrEmpty(Icon) || !string.IsNullOrEmpty(Text))
				output.Content.SetHtmlContent($@"<span class=""{Icon}""></span> {Text}");
			if (!string.IsNullOrEmpty(Tooltip))
			{
				output.Attributes.SetAttribute("data-toggle", "tooltip");
				output.Attributes.SetAttribute("title", Tooltip);
				output.Attributes.SetAttribute("data-placement", "top");
			}
			if (Disabled)
				output.Attributes.SetAttribute("disabled", "disabled");
		}
	}

	[HtmlTargetElement("default-submit")]
	public class DefaultSubmitTagHelper : TagHelper
	{
		[HtmlAttributeName("id")]
		public string Id { get; set; }

		[HtmlAttributeName("name")]
		public string Name { get; set; }

		[HtmlAttributeName("text")]
		public string Text { get; set; }

		[HtmlAttributeName("class")]
		public string Class { get; set; }

		[HtmlAttributeName("style")]
		public string Style { get; set; }

		[HtmlAttributeName("icon")]
		public string Icon { get; set; }

		[HtmlAttributeName("value")]
		public string Value { get; set; }

		[HtmlAttributeName("ladda")]
		public string LaddaStyle { get; set; }

		[HtmlAttributeName("additional")]
		public Dictionary<string, object> Additional { get; set; }

		[HtmlAttributeName("disabled")]
		public bool Disabled { get; set; }

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			output.TagName = "button";

			if (!string.IsNullOrEmpty(Id))
				output.Attributes.SetAttribute("id", Id);
			if (!string.IsNullOrEmpty(Name))
				output.Attributes.SetAttribute("name", Name);
			if (!string.IsNullOrEmpty(Class))
				output.Attributes.SetAttribute("class", Class + (Disabled ? " disabled" : ""));
			if (!string.IsNullOrEmpty(Style))
				output.Attributes.SetAttribute("style", Style);
			if (!string.IsNullOrEmpty(Icon) || !string.IsNullOrEmpty(Text))
				output.Content.SetHtmlContent($@"<i class=""{Icon}""></i> {Text}");
			if (!string.IsNullOrEmpty(Value))
				output.Attributes.SetAttribute("value", Value);
			if (Additional != null && Additional.Any())
			{
				foreach (var data in Additional)
					output.Attributes.SetAttribute($"data-{data.Key}", data.Value);
			}
			if (Disabled)
				output.Attributes.SetAttribute("disabled", "disabled");
			if (!string.IsNullOrEmpty(LaddaStyle))
				output.Attributes.SetAttribute("data-style", LaddaStyle);
			else
				output.Attributes.SetAttribute("data-style", "zoom-out");
		}
	}

	[HtmlTargetElement("search-button")]
	public class SearchButtonTagHelper : DefaultSubmitTagHelper
	{
		[HtmlAttributeName("disabled")]
		public bool Disabled { get; set; }

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			Id = "searchButton";
			Name = "searchButton";
			Text = "Buscar";
			Class = "btn btn-default btn-md ladda-button";
			Style = null;
			Icon = "fa fa-search";
			base.Disabled = this.Disabled;
			base.Process(context, output);
		}
	}

	[HtmlTargetElement("save-button")]
	public class SaveButtonTagHelper : DefaultSubmitTagHelper
	{
		[HtmlAttributeName("disabled")]
		public bool Disabled { get; set; }

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			Id = "saveButton";
			Name = "saveButton";
			Text = "Guardar";
			Class = "btn btn-success btn-md ladda-button";
			Style = null;
			Icon = "fa fa-save";
			base.Disabled = this.Disabled;
			base.Process(context, output);
		}
	}

	[HtmlTargetElement("execute-button")]
	public class ExecuteButtonTagHelper : DefaultSubmitTagHelper
	{
		[HtmlAttributeName("disabled")]
		public bool Disabled { get; set; }

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			Id = "executeButton";
			Name = "executeButton";
			Text = "Ejecutar";
			Class = "btn btn-success btn-md ladda-button";
			Style = null;
			Icon = "fa fa-check";
			base.Disabled = this.Disabled;
			base.Process(context, output);
		}
	}

	[HtmlTargetElement("delete-button")]
	public class DeleteButtonTagHelper : DefaultSubmitTagHelper
	{
		[HtmlAttributeName("disabled")]
		public bool Disabled { get; set; }

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			Id = "deleteButton";
			Name = "deleteButton";
			Text = "Eliminar";
			Class = "btn btn-danger btn-md ladda-button";
			Style = null;
			Icon = "fa fa-trash-alt";
			base.Disabled = this.Disabled;
			base.Process(context, output);
		}
	}

	[HtmlTargetElement("new-button")]
	public class NewButtonTagHelper : DefaultButtonTagHelper
	{
		[HtmlAttributeName("url")]
		public new string Url { get; set; }

		[HtmlAttributeName("disabled")]
		public new bool Disabled { get; set; }

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			Id = "newButton";
			Name = "newButton";
			Text = "Nuevo";
			base.Url = this.Url;
			Class = "btn btn-success btn-md margin-bottom-5";
			Style = "";
			Icon = "fa fa-plus";
			base.Disabled = this.Disabled;
			base.Process(context, output);
		}
	}

	[HtmlTargetElement("edit-button")]
	public class EditButtonTagHelper : DefaultButtonTagHelper
	{
		[HtmlAttributeName("url")]
		public new string Url { get; set; }

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			Id = "editButton";
			Name = "editButton";
			Text = "Editar";
			base.Url = this.Url;
			Class = "btn btn-warning btn-md";
			Style = null;
			Icon = "fa fa-edit";
			base.Process(context, output);
		}
	}

	[HtmlTargetElement("cancel-button")]
	public class CancelButtonTagHelper : DefaultButtonTagHelper
	{
		[HtmlAttributeName("url")]
		public new string Url { get; set; }

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			Id = "cancelButton";
			Name = "cancelButton";
			Text = "Cancelar";
			base.Url = "javascript:history.go(-1)";
			Class = "btn btn-default btn-md";
			Style = null;
			Icon = "fa fa-times";
			base.Process(context, output);
		}
	}

	[HtmlTargetElement("info-button")]
	public class InfoButtonTagHelper : DefaultButtonTagHelper
	{
		[HtmlAttributeName("url")]
		public new string Url { get; set; }

		[HtmlAttributeName("text")]
		public new string Text { get; set; }

		[HtmlAttributeName("style")]
		public new string Style { get; set; }

		[HtmlAttributeName("icon")]
		public new string Icon { get; set; }

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			var uniqueid = Guid.NewGuid();

			Id = "infoButton_" + uniqueid;
			Name = "infoButton_" + uniqueid;
			base.Text = this.Text;
			base.Url = this.Url;
			Class = "btn btn-info";
			base.Style = this.Style;
			base.Icon = this.Icon;
			base.Process(context, output);
		}
	}

	[HtmlTargetElement("success-button")]
	public class SuccessButtonTagHelper : DefaultButtonTagHelper
	{
		[HtmlAttributeName("url")]
		public new string Url { get; set; }

		[HtmlAttributeName("text")]
		public new string Text { get; set; }

		[HtmlAttributeName("style")]
		public new string Style { get; set; }

		[HtmlAttributeName("icon")]
		public new string Icon { get; set; }

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			var uniqueid = Guid.NewGuid();

			Id = "successButton_" + uniqueid;
			Name = "successButton_" + uniqueid;
			base.Text = this.Text;
			base.Url = this.Url;
			Class = "btn btn-success";
			base.Style = this.Style;
			base.Icon = this.Icon;
			base.Process(context, output);
		}
	}

	[HtmlTargetElement("warning-button")]
	public class WarningButtonTagHelper : DefaultButtonTagHelper
	{
		[HtmlAttributeName("url")]
		public new string Url { get; set; }

		[HtmlAttributeName("text")]
		public new string Text { get; set; }

		[HtmlAttributeName("style")]
		public new string Style { get; set; }

		[HtmlAttributeName("icon")]
		public new string Icon { get; set; }

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			var uniqueid = Guid.NewGuid();

			Id = "warningButton_" + uniqueid;
			Name = "warningButton_" + uniqueid;
			base.Text = this.Text;
			base.Url = this.Url;
			Class = "btn btn-warning";
			base.Style = this.Style;
			base.Icon = this.Icon;
			base.Process(context, output);
		}
	}

	[HtmlTargetElement("danger-button")]
	public class DangerButtonTagHelper : DefaultButtonTagHelper
	{
		[HtmlAttributeName("url")]
		public new string Url { get; set; }

		[HtmlAttributeName("text")]
		public new string Text { get; set; }

		[HtmlAttributeName("style")]
		public new string Style { get; set; }

		[HtmlAttributeName("icon")]
		public new string Icon { get; set; }

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			var uniqueid = Guid.NewGuid();

			Id = "dangerButton_" + uniqueid;
			Name = "dangerButton_" + uniqueid;
			base.Text = this.Text;
			base.Url = this.Url;
			Class = "btn btn-danger";
			base.Style = this.Style;
			base.Icon = this.Icon;
			base.Process(context, output);
		}
	}

	[HtmlTargetElement("table-details-button")]
	public class TableDetailsButtonTagHelper : DefaultTableButtonTagHelper
	{
		[HtmlAttributeName("url")]
		public new string Url { get; set; }

		[HtmlAttributeName("disabled")]
		public new bool Disabled { get; set; }

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			Id = "detailsButton";
			Name = "detailsButton";
			Text = " Detalles";
			base.Url = this.Url;
			Class = "btn btn-info btn-sm";
			Style = null;
			Icon = "fa fa-info";
			//Tooltip = "Detalle";
			base.Disabled = this.Disabled;

			base.Process(context, output);
		}
	}

	[HtmlTargetElement("table-edit-button")]
	public class TableEditButtonTagHelper : DefaultTableButtonTagHelper
	{
		[HtmlAttributeName("url")]
		public new string Url { get; set; }

		[HtmlAttributeName("disabled")]
		public new bool Disabled { get; set; }

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			Id = "editButton";
			Name = "editButton";
			Text = " Editar";
			base.Url = this.Url;
			Class = "btn btn-warning btn-sm";
			Style = null;
			Icon = "fa fa-edit";
			//Tooltip = "Editar";
			base.Disabled = this.Disabled;

			base.Process(context, output);
		}
	}

	[HtmlTargetElement("table-delete-button")]
	public class TableDeleteButtonTagHelper : DefaultTableButtonTagHelper
	{
		[HtmlAttributeName("url")]
		public new string Url { get; set; }

		[HtmlAttributeName("disabled")]
		public new bool Disabled { get; set; }

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			Id = "deleteButton";
			Name = "deleteButton";
			Text = " Eliminar";
			base.Url = this.Url;
			Class = "btn btn-danger btn-sm";
			Style = null;
			Icon = "fa fa-trash-o";
			//Tooltip = "Eliminar";
			base.Disabled = this.Disabled;

			base.Process(context, output);
		}
	}

	[HtmlTargetElement("table-trace-button")]
	public class TableTraceButtonTagHelper : DefaultTableButtonTagHelper
	{
		[HtmlAttributeName("url")]
		public new string Url { get; set; }

		[HtmlAttributeName("disabled")]
		public new bool Disabled { get; set; }

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			Id = "traceButton";
			Name = "traceButton";
			base.Text = " Trace";
			base.Url = this.Url;
			Class = "btn btn-primary btn-sm";
			Style = null;
			base.Icon = "fa fa-share-alt";
			//Tooltip = "Trace";
			base.Disabled = this.Disabled;

			base.Process(context, output);
		}
	}

	[HtmlTargetElement("table-default-button")]
	public class TableDefaultButtonTagHelper : DefaultTableButtonTagHelper
	{
		[HtmlAttributeName("url")]
		public new string Url { get; set; }

		[HtmlAttributeName("text")]
		public new string Text { get; set; }

		[HtmlAttributeName("icon")]
		public new string Icon { get; set; }

		[HtmlAttributeName("disabled")]
		public new bool Disabled { get; set; }

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			Id = "defaultButton";
			Name = "defaultButton";
			base.Text = Text;
			base.Url = this.Url;
			Class = "btn btn-default btn-sm";
			Style = "padding: 5px 10px; font-size: 12px; line-height: 1.5; border-radius: 3px;";
			base.Icon = Icon;
			base.Disabled = this.Disabled;

			base.Process(context, output);
		}
	}

	[HtmlTargetElement("input", Attributes = "asp-for,readonly")]
	public class UserInputTagHelper : TagHelper
	{
		public override int Order { get; } = int.MaxValue;

		[HtmlAttributeName("asp-for")]
		public ModelExpression For { get; set; }

		[HtmlAttributeName("readonly")]
		public bool Readonly { get; set; }

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			base.Process(context, output);

			if (Readonly)
				output.Attributes.SetAttribute("readonly", null);
		}
	}

	[HtmlTargetElement("code-editor", Attributes = "asp-for")]
	public class CodeEditorTagHelper : TagHelper
	{
		[HtmlAttributeName("asp-for")]
		public ModelExpression For { get; set; }

		[HtmlAttributeName("readonly")]
		public bool ReadOnly { get; set; }

		[HtmlAttributeName("format-to")]
		public string FormatStyle { get; set; }

		[HtmlAttributeName("class")]
		public string Class { get; set; }

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			string data = string.Empty;
			var guid = Guid.NewGuid();
			output.TagName = "pre";

			output.Attributes.SetAttribute("id", $"{For.ModelExplorer.Container.ModelType.Name}_{For.Name}_{guid}");
			output.Attributes.SetAttribute("name", $"{For.ModelExplorer.Container.ModelType.Name}.{For.Name}_{guid}");
			output.Attributes.SetAttribute("data-plugin", "ace");
			output.Attributes.SetAttribute("data-mode", FormatStyle);
			output.Attributes.SetAttribute("style", "width: 100%;");
			output.Attributes.SetAttribute("class", "ace-editor " + Class);

			if (For.Model != null && For.Model.ToString().IsJson())
				data = For.Model.ToString().FormatJson();
			else if (For.Model != null && For.Model.ToString().IsXML())
				data = For.Model.ToString().FormatXML();
			else
				data = For.Model?.ToString();
			
			if (ReadOnly)
				output.Attributes.SetAttribute("class", "ace-editor");

			output.Content.SetHtmlContent(data);
		}
	}

	[HtmlTargetElement("input-checkbox", Attributes = "asp-for")]
	public class InputCheckBoxTagHelper : TagHelper
	{
		[HtmlAttributeName("asp-for")]
		public ModelExpression For { get; set; }

		[HtmlAttributeName("disabled")]
		public bool Disabled { get; set; }

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			var isChecked = false;
			var checkedItem = string.Empty;

			if (For.Model != null)
			{
				isChecked = (bool)For.Model;
				checkedItem = isChecked ? @"checked=""checked""" : "";
			}

			var disabled = context.AllAttributes.ContainsName("disabled") ? "disabled" : "";

			var checkbox = $@"<div class=""checkbox"">
                                    <label>
                                        <input class=""check-box checkbox-slider"" type=""checkbox"" value=""true"" id=""{For.ModelExplorer.Container.ModelType.Name}_{For.Name}"" name=""{For.ModelExplorer.Container.ModelType.Name}.{For.Name}"" {checkedItem} {disabled}>
                                        <span class=""text""></span>
                                    </label>
                                </div>";

			output.Content.SetHtmlContent(checkbox);
		}
	}

	[HtmlTargetElement("input-switch", Attributes = "asp-for")]
	public class InputSwitchTagHelper : TagHelper
	{
		[HtmlAttributeName("asp-for")]
		public ModelExpression For { get; set; }

		[HtmlAttributeName("class")]
		public string Class { get; set; }

		[HtmlAttributeName("text")]
		public string Text { get; set; }

		[HtmlAttributeName("disabled")]
		public bool Disabled { get; set; }

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			var checkedItem = string.Empty;

			if (For.Model != null)
				checkedItem = ((bool)For.Model == true ? @"checked=""checked""" : "");

			var disabled = context.AllAttributes.ContainsName("disabled") ? "disabled" : "";

			var @switch = $@"<div class=""form-group"">
                                <div class=""switch {Class ?? "switch-warning"} d-inline m-r-10"">
                                  <input type=""checkbox"" id=""{For.ModelExplorer.Container.ModelType.Name}_{For.Name}"" name=""{For.ModelExplorer.Container.ModelType.Name}.{For.Name}"" {checkedItem} {disabled}>
                                  <label class=""cr"" for=""{For.ModelExplorer.Container.ModelType.Name}_{For.Name}""></label>
                                </div>
                                <label>{Text}</label>
                              </div>";

			output.Content.SetHtmlContent(@switch);
		}
	}
}
