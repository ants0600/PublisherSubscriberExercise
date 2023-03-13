using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSubDomain.Services
{
	public interface IErrorHandlerService : IService
	{
		bool HandleError(Exception ex);
	}
}
