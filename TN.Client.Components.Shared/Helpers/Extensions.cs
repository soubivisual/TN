using Microsoft.AspNetCore.Components.Forms;
using System.Linq.Expressions;
using System.Reflection;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TN.Client.Components.Shared.Helpers;
using TN.Client.Components.Shared.Attributes;
using TN.Shared.Utils.Misc;
using Microsoft.JSInterop;
using TN.Client.Components.Shared.Models.Misc;

namespace TN.Client.Components.Shared.Helpers
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

        public static ValueTask LoadTNTooltip(this IJSRuntime js, string position) =>
            js.InvokeVoidAsync(nameof(LoadTNTooltip), position);

        public static ValueTask LoadTNPopover(this IJSRuntime js, string position) =>
            js.InvokeVoidAsync(nameof(LoadTNPopover), position);

        public static ValueTask SetLimitDatetime(this IJSRuntime js, bool isBeginDate, string beginDate, string endDate) =>
            js.InvokeVoidAsync(nameof(SetLimitDatetime), isBeginDate, beginDate, endDate);

        public static ValueTask DateTimePickerMinDate(this IJSRuntime js, DateTime? selectedDate, DateTime? maxDate, string format) =>
            js.InvokeVoidAsync(nameof(DateTimePickerMinDate), selectedDate, maxDate, format);

        public static ValueTask DateTimePickerMaxDate(this IJSRuntime js, DateTime? selectedDate,  DateTime? minDate, string format) =>
            js.InvokeVoidAsync(nameof(DateTimePickerMaxDate), selectedDate, minDate, format);

        public static ValueTask InitializeSelectChoices(this IJSRuntime js, string id, bool isSearchEnabled, string searchPlaceholder) =>
            js.InvokeVoidAsync(nameof(InitializeSelectChoices), id, isSearchEnabled, searchPlaceholder);

        public static ValueTask AddEventListener(this IJSRuntime js, string id, string eventName, string script) =>
            js.InvokeVoidAsync(nameof(AddEventListener), id, eventName, script);

        public static ValueTask<bool> IsMobile(this IJSRuntime js) =>
            js.InvokeAsync<bool>(nameof(IsMobile));

        public static ValueTask CreateDatePicker(this IJSRuntime js, string elementId,string format, string minDate, string maxDate, bool isRangeDate = false, bool isBeginDate = true) =>
            js.InvokeVoidAsync(nameof(CreateDatePicker), elementId, format, minDate, maxDate, isRangeDate, isBeginDate);

        public static ValueTask UpdateLimitDate(this IJSRuntime js, string elementId, string minDate, string maxDate) =>
            js.InvokeVoidAsync(nameof(CreateDatePicker), elementId, minDate, maxDate);

        public static ValueTask CreateDateRange(this IJSRuntime js, string elementId) =>
            js.InvokeVoidAsync(nameof(CreateDateRange), elementId);

        public static ValueTask<object> GetDateValue(this IJSRuntime js, string elementId, string dateFormat) =>
            js.InvokeAsync<object>(nameof(GetDateValue), elementId, dateFormat);

        public static ValueTask BindBlazorProperty(this IJSRuntime js, string id, string value = null) =>
            js.InvokeVoidAsync(nameof(BindBlazorProperty), id, value);

        public static ValueTask ToggleMenu(this IJSRuntime js) =>
            js.InvokeVoidAsync(nameof(ToggleMenu));

        public static ValueTask SlideToggleMenuItem(this IJSRuntime js, Guid id) =>
            js.InvokeVoidAsync(nameof(SlideToggleMenuItem), id);

        public static ValueTask ResetSlideToggleMenuItem(this IJSRuntime js) =>
            js.InvokeVoidAsync(nameof(ResetSlideToggleMenuItem));

        public static ValueTask Vibrate(this IJSRuntime js, int seconds) =>
            js.InvokeVoidAsync(nameof(Vibrate),seconds);

        public static ValueTask ScrollPosition(this IJSRuntime js, int x, int y) =>
            js.InvokeVoidAsync(nameof(ScrollPosition), x, y);

        public static ValueTask SwalConfirm<TValue>(this IJSRuntime js, string confirmTitle, string confirmText, string confirmButtonText, string successTitle, string successText, TValue classReference, string methodName, object data) where TValue : class =>
            js.InvokeVoidAsync(nameof(SwalConfirm),
                confirmTitle,
                confirmText,
                confirmButtonText,
                successTitle,
                successText,
                DotNetObjectReference.Create(classReference),
                methodName,
                data);

        public static ValueTask<bool> SwalConfirmTransaction(this IJSRuntime js, string confirmTitle, string confirmText, string confirmButtonText) =>
            js.InvokeAsync<bool>(nameof(SwalConfirmTransaction),
                confirmTitle,
                confirmText,
                confirmButtonText);

        public static ValueTask SwalInfo(this IJSRuntime js, string title, string text, string confirmButtonText, object classReference = null, string methodName = null, object data = null) =>
            js.InvokeVoidAsync(nameof(SwalInfo),
                title,
                text,
                confirmButtonText,
                classReference == null ? null : DotNetObjectReference.Create(classReference),
                methodName,
                data);

        public static ValueTask SwalSuccess(this IJSRuntime js, string title, string text, string confirmButtonText, object classReference = null, string methodName = null, object data = null) =>
            js.InvokeVoidAsync(nameof(SwalSuccess),
                title,
                text,
                confirmButtonText,
                classReference == null ? null : DotNetObjectReference.Create(classReference),
                methodName,
                data);

        public static ValueTask SwalWarning(this IJSRuntime js, string title, string text, string confirmButtonText, object classReference = null, string methodName = null, object data = null) =>
            js.InvokeVoidAsync(nameof(SwalWarning),
                title,
                text,
                confirmButtonText,
                classReference == null ? null : DotNetObjectReference.Create(classReference),
                methodName,
                data);

        public static ValueTask SwalError(this IJSRuntime js, string title, string text, string confirmButtonText, object classReference = null, string methodName = null, object data = null) =>
            js.InvokeVoidAsync(nameof(SwalError),
                title,
                text,
                confirmButtonText,
                classReference == null ? null : DotNetObjectReference.Create(classReference),
                methodName,
                data);

        public static ValueTask SwalException(this IJSRuntime js, string title, string text, string code, string type, string uuid, string timestamp, string confirmButtonText, string cancelButtonText = null, object classReference = null, string methodName = null, object data = null, string redirectUrl = null) =>
            js.InvokeVoidAsync(nameof(SwalException),
                title,
                text,
                code,
                type,
                uuid,
                timestamp,
                confirmButtonText,
                cancelButtonText,
                classReference == null ? null : DotNetObjectReference.Create(classReference),
                methodName,
                data,
                redirectUrl);

        public static ValueTask SwalLogout(this IJSRuntime js, string title, string text, string confirmButtonText) =>
            js.InvokeVoidAsync(nameof(SwalLogout),
                title,
                text,
                confirmButtonText);

        public static ValueTask<bool> Swal2FA(this IJSRuntime js, string title, string text, string confirmButtonText, string cancelButtonText, object classReference, string methodName, object data = null) =>
            js.InvokeAsync<bool>(nameof(Swal2FA),
                title,
                text,
                confirmButtonText,
                cancelButtonText,
                DotNetObjectReference.Create(classReference),
                methodName,
                data);

        public static ValueTask CreateGoogleMap(this IJSRuntime js, string key, LocationData currentLocation, List<LocationData> locations) =>
            js.InvokeVoidAsync(nameof(CreateGoogleMap), key, currentLocation, locations);

        public static ValueTask SetGoogleMapMarkers(this IJSRuntime js, string key) =>
            js.InvokeVoidAsync(nameof(SetGoogleMapMarkers), key);

    }
}
