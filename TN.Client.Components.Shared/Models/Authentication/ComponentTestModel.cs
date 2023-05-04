using System;
using System.ComponentModel.DataAnnotations;

namespace TN.Client.Components.Shared.Models.Authentication
{
    internal sealed class ComponentTestModel
    {
        
        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Username { get; set; }

        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]

        public string Password { get; set; }
        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]

        public string Description { get; set; }
        [Required]
        public bool IsChecked { get; set; }
        [Required]
        public string SecondPassword { get; set; }
        public OptionTest ModelCombo { get; set; }
        public Guid? ModelComboID { get; set; } = null;

        [Display(Name = "Fecha", Prompt = "Seleccione la fecha")]
        public DateTime? Date { get; set; } = DateTime.Now;

        [Display(Name = "Fecha y hora", Prompt = "Seleccione la fecha y hora")]
        public DateTime? DateWithTime { get; set; } = DateTime.Now;

        [Display(Name = "Fecha y hora", Prompt = "Seleccione la fecha y hora")]
        public DateTime? DateRange { get; set; } = DateTime.Now;

        [Display(Name = "Fecha y hora", Prompt = "Seleccione la fecha y hora")]
        public DateTime? BeginDate { get; set; }

        [Display(Name = "Fecha y hora", Prompt = "Seleccione la fecha y hora")]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Switch element")]
        public bool BoolCheckbox { get; set; }
    }
}

