namespace TN.Admin.Web.ASPCore.Miscellaneous
{
	public class Functions
	{
		public static object Cast(object source, object destiny)
		{
			var sourceProperties = source.GetType().GetProperties();

			foreach (var property in destiny.GetType().GetProperties().Where(p => p.MemberType == System.Reflection.MemberTypes.Property && p.CanRead && p.CanWrite))
			{
				var src = sourceProperties.FirstOrDefault(p => p.Name == property.Name);
				if (src != null)
				{
					try
					{
						object value = src.GetValue(source);
						property.SetValue(destiny, value);
					}
					catch { }
				}
			}

			return destiny;
		}
	}
}
