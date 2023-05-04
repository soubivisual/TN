using TN.Admin.Web.ASPCore.DataModels.Dto;
using TN.Admin.Web.ASPCore.Miscellaneous;

namespace TN.Admin.Web.ASPCore.Areas.Shared.Models
{
    public class CoreProcessTraceModel
    {
		public CoreProcessTraceDto CoreProcessTrace { get; set; }
        public List<CoreProcessTraceDto> CoreProcessTraces { get; set; } = new List<CoreProcessTraceDto>() { 
            new CoreProcessTraceDto { 
             Date = DateTime.Now,
             Title = "Trace",
             Content = @"{
    ""glossary"": {
        ""title"": ""example glossary"",
		""GlossDiv"": {
            ""title"": ""S"",
			""GlossList"": {
                ""GlossEntry"": {
                    ""ID"": ""SGML"",
					""SortAs"": ""SGML"",
					""GlossTerm"": ""Standard Generalized Markup Language"",
					""Acronym"": ""SGML"",
					""Abbrev"": ""ISO 8879:1986"",
					""GlossDef"": {
                        ""para"": ""A meta-markup language, used to create markup languages such as DocBook."",
						""GlossSeeAlso"": [""GML"", ""XML""]
                    },
					""GlossSee"": ""markup""
                }
            }
        }
    }
}",
             CoreProcessId = Guid.Parse("E82D4FB5-87AD-47D2-AF39-EDBA1F793007"),
             Type = Constants.CoreProcessTraceType.Transaction
			},
            new CoreProcessTraceDto {
             Date = DateTime.Now.AddHours(-1),
             Title = Constants.CoreProcessTraceType.ApplicationLog,
             Content = "Exception in Configuration File. Cannot access a disposed context instance. BLBA BALBABA ",
             CoreProcessId = Guid.Parse("E82D4FB5-87AD-47D2-AF39-EDBA1F793007"),
             Type = Constants.CoreProcessTraceType.ApplicationLog, 
             MoreInfo = new Dictionary<string, string> () {
                 {"Id","1234" },
                 {"IP", "172.23.17.243"},
                 {"Message", "Invitamus me testatur sed quod non dum animae tuae lacrimis ut libertatem deum rogus aegritudinis causet" }
             }
            },
			new CoreProcessTraceDto {
			 Date = DateTime.Now.AddHours(-1.5),
			 Title = Constants.CoreProcessTraceType.TraceLog,
			 Content = @"{
    ""glossary"": {
        ""title"": ""example glossary"",
		""GlossDiv"": {
            ""title"": ""S"",
			""GlossList"": {
                ""GlossEntry"": {
                    ""ID"": ""SGML"",
					""SortAs"": ""SGML"",
					""GlossTerm"": ""Standard Generalized Markup Language"",
					""Acronym"": ""SGML"",
					""Abbrev"": ""ISO 8879:1986"",
					""GlossDef"": {
                        ""para"": ""A meta-markup language, used to create markup languages such as DocBook."",
						""GlossSeeAlso"": [""GML"", ""XML""]
                    },
					""GlossSee"": ""markup""
                }
            }
        }
    }
}",
			 CoreProcessId = Guid.Parse("E82D4FB5-87AD-47D2-AF39-EDBA1F793007"),
			 Type = Constants.CoreProcessTraceType.TraceLog,
			 MoreInfo = new Dictionary<string, string> () {
				 {"Id","1234" },
				 {"IP", "172.23.17.66"},
				 {"Message", "Message was found!!" }
			 }
			},
			new CoreProcessTraceDto {
			 Date = DateTime.Now.AddHours(-3),
			 Title = Constants.CoreProcessTraceType.UserHistory,
			 Content = "Invitamus me testatur sed quod non dum animae tuae lacrimis ut libertatem deum rogus aegritudinis causet.Invitamus me testatur sed quod non dum animae tuae lacrimis ut libertatem deum rogus aegritudinis causet.Invitamus m ",
			 CoreProcessId = Guid.NewGuid(),
			 Type = Constants.CoreProcessTraceType.UserHistory
			}
		};
    }
}
