using Microsoft.AspNetCore.Components.Forms;
using System.Linq.Expressions;
using System.Reflection;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TN.Client.Components.Shared.Helpers;
using TN.Client.Components.Shared.Attributes;
using TN.Shared.Utils.Misc;

namespace TN.Client.Web.BlazorShared.Helpers
{
    public static class Extensions
    {
        public static object GetPropertyValue(this object source, string propertyName) =>
            source.GetType().GetProperty(propertyName)?.GetValue(source, null);

        public static string GetName(this FieldIdentifier fieldIdentifier) =>
            $"{fieldIdentifier.Model.GetName()}_{fieldIdentifier.FieldName}";

        public static string GetDisplayName(this Expression body)
        {
            var expression = (MemberExpression)body;
            var display = expression.Member.GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute;
            var displayName = expression.Member.GetCustomAttribute(typeof(DisplayNameAttribute)) as DisplayNameAttribute;
            return display?.Name ?? displayName?.DisplayName ?? expression.Member.Name ?? "No display name found";
        }

        public static string GetDisplayPrompt(this Expression body)
        {
            var expression = (MemberExpression)body;
            var display = expression.Member.GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute;
            return display?.GetPrompt() ?? display?.Name ?? expression.Member.Name ?? "No prompt found";
        }

        public static int GetMaximumLength(this Expression body)
        {
            var expression = (MemberExpression)body;
            var stringLength = expression.Member.GetCustomAttribute(typeof(StringLengthAttribute)) as StringLengthAttribute;
            return stringLength?.MaximumLength ?? ApplicationConstant.TextBoxMaximumLength;
        }

        public static string GetMask(this Expression body)
        {
            var expression = (MemberExpression)body;
            var mask = expression.Member.GetCustomAttribute(typeof(MaskAttribute)) as MaskAttribute;
            return mask?.Mask;
        }

        public static string GetRegex(this Expression body)
        {
            var expression = (MemberExpression)body;
            var regex = expression.Member.GetCustomAttribute(typeof(RegularExpressionAttribute)) as RegularExpressionAttribute;
            return regex?.Pattern;
        }

        public static bool IsRequired(this Expression body)
        {
            var expression = (MemberExpression)body;
            var required = expression.Member.GetCustomAttribute(typeof(RequiredAttribute)) as RequiredAttribute;
            return required != null;
        }
    }
}
