using System.Net;

namespace TN.Admin.Web.ASPCore.Exceptions
{
	public class BaseException : Exception
	{
        public BaseException(string message) : base(message)
        {
        }
	}
}
