using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TN.Admin.Web.ASPCore.DataModels.Dto
{
    public class CoreProcessTraceDto
    {
        public Guid? CoreProcessId { get; set; }

        [DisplayName("Date")]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [DisplayName("Type")]
        public string Type { get; set; } = string.Empty;

        [DisplayName("Title")]
        public string Title { get; set; } = string.Empty;

        [DisplayName("MoreInfo")]
        public Dictionary<string, string> MoreInfo { get; set; } = new Dictionary<string, string>();

        //[UIHint("CodeEditor")]
        [DisplayName("Content")]
        public string Content { get; set; } = string.Empty;

	}
}
