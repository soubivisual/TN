namespace TN.Admin.Web.ASPCore.Miscellaneous
{
	public class Constants
	{
		public class General
		{
			public const string SiteName = "TN";
			public const string Commands = "Acciones";
			public const string DropDownPlaceHolderText = "-- Elija un valor --";
			public const string VersionPrefix = "ver_";
			public const int ChangePasswordDays = 90;
			public const int RowCount = 100;
			public const int CoreProcessTraceRowCount = 100;
			public const int TimestampMaxAllowedInMinutes = 10;
			public const string CoreProcessHiddenKey = "!->";
			public static readonly TimeSpan CacheResetTime = new TimeSpan(0, 15, 0);
			public static readonly Guid DropDownDefaultEmptyValue = Guid.Parse("0D20BB32-133D-4196-9D2E-6B80986BAF3D");
		}

		public class Areas
		{
			public const string Maintenances = "Mantenimientos";
		}

		public class Controllers
		{
			public const string Catalog = "Catálogo";
		}

		public class Actions
		{
			public const string Index = "Inicio";
			public const string Create = "Crear";
			public const string Update = "Actualizar";
			public const string Delete = "Eliminar";
			public const string Detail = "Detalle";
		}

		public class FormatType
        {
            public const string FullDateTimeFormat = "dddd dd/MM/yyyy HH:mm:ss";
            public const string DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
            public const string DateFormat = "yyyy-MM-dd";
            public const string TimeFormat = "hh:mm:ss.fff";
            public const string AnnotationDateFormat = "{0:yyyy-MM-dd}";
            public const string DecimalFormat = "#,0.00";
        }

        public class OperationType
        {
            public const string DefaultOperation = "Default";
            public const string DetailsOperation = "Info";
            public const string DeleteOperation = "Delete";
            public const string CreateOperation = "Create";
            public const string UpdateOperation = "Update";
            public const string TraceOperation = "Trace";
        }
        public  class CatalogType
		{
			public const string GeneralStatus = "GeneralStatus";
			public const string SMTPConfig = "SMTPConfig";
			public const string SMTPDefault = "SMTPDefault";
			public const string GeneralSetting = "GeneralSetting";
		}

		public  class RouteName
		{
			public const string Home = "home";
			public const string NotFound = "not_found";
		}

		public class CodEditorFormatStyle
		{
			public const string Json = "json";
			public const string Xml = "xml";
			public const string Html = "html";
			public const string Css = "text/css";
		}
	}
}
