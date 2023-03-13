using PubSubDomain.Domain;
using PubSubDomain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace PubSubInfrastructure.Services
{
	public class ErrorHandlerService : BaseService, IErrorHandlerService
	{
		public bool HandleError(Exception ex)
		{
			var message = GetErrorMessage(ex);
			MessageBox.Show(message);

#if DEBUG

			Console.WriteLine(message);

#endif
			return true;
		}

		private static string GetErrorMessage(Exception x)
		{
			string value = string.Format(ConstantValues.ErrorMessageFormat,
				x.GetType(),
				x.Message,
				x.StackTrace);
			return value;
		}
	}
}
